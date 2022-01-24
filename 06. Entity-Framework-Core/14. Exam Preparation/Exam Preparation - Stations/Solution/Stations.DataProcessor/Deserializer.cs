using System;
using Stations.Data;
using Stations.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Stations.DataProcessor.Dto.Import;
using Stations.Models.Enums;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Stations.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
		{
            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(jsonString);  
            HashSet<string> stationNames = new HashSet<string>();
            List<Station> validStations = new List<Station>();
            StringBuilder sb = new StringBuilder();

            foreach (var station in stations)
            {
                if(station.Town == null)
                {
                    station.Town = station.Name;
                }

                if(!IsValid(station) || stationNames.Contains(station.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                stationNames.Add(station.Name);
                validStations.Add(station);
                sb.AppendLine(string.Format(SuccessMessage, station.Name));
            }

            context.Stations.AddRange(validStations);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
		}

		public static string ImportClasses(StationsDbContext context, string jsonString)
		{
            List<SeatingClass> seatingClasses = JsonConvert.DeserializeObject<List<SeatingClass>>(jsonString);
            HashSet<string> seatingClassNames = new HashSet<string>();
            HashSet<string> abbreviations = new HashSet<string>();
            List<SeatingClass> validSeatingClasses = new List<SeatingClass>();
            StringBuilder sb = new StringBuilder();

            foreach (var seatingClass in seatingClasses)
            {
                if (!IsValid(seatingClass) || 
                    seatingClassNames.Contains(seatingClass.Name) || 
                    abbreviations.Contains(seatingClass.Abbreviation))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                abbreviations.Add(seatingClass.Abbreviation);
                seatingClassNames.Add(seatingClass.Name);
                validSeatingClasses.Add(seatingClass);
                sb.AppendLine(string.Format(SuccessMessage, seatingClass.Name));
            }

            context.SeatingClasses.AddRange(validSeatingClasses);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		public static string ImportTrains(StationsDbContext context, string jsonString)
		{
            const string delimiter = "=>";

            List<TrainImportDto> trains = JsonConvert.DeserializeObject<List<TrainImportDto>>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            Dictionary<string, int> seatClasses = context.SeatingClasses.ToDictionary(x => x.Name + delimiter + x.Abbreviation, y => y.Id);
            HashSet<string> trainNumbers = new HashSet<string>();
            List<Train> validTrains = new List<Train>();
            StringBuilder sb = new StringBuilder();

            foreach (var train in trains)
            {
                if (!IsValid(train) || trainNumbers.Contains(train.TrainNumber))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool allSeatsAreValid = train.Seats
                   .All(s => IsValid(s) && seatClasses.ContainsKey(s.Name + delimiter + s.Abbreviation));
                if (!allSeatsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool trainTypeIsValid = Enum.TryParse<TrainType>(train.Type, out TrainType type);
                if (!trainTypeIsValid)
                {
                    type = TrainType.HighSpeed;
                }

                Train validTrain = new Train()
                {
                    Type = type,
                    TrainNumber = train.TrainNumber,
                    TrainSeats = train.Seats.Select(s => new TrainSeat()
                    {
                        SeatingClassId = seatClasses[s.Name + delimiter + s.Abbreviation],
                        Quantity = s.Quantity.Value
                    })
                    .ToList()
                };

                trainNumbers.Add(train.TrainNumber);
                validTrains.Add(validTrain);
                sb.AppendLine(string.Format(SuccessMessage, train.TrainNumber));
            }

            context.Trains.AddRange(validTrains);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		public static string ImportTrips(StationsDbContext context, string jsonString)
		{
            Dictionary<string, int> stations = context.Stations.ToDictionary(x => x.Name, y => y.Id);
            Dictionary<string, int> trains = context.Trains.ToDictionary(x => x.TrainNumber, y => y.Id);

            List<TripImportDto> trips = JsonConvert.DeserializeObject<List<TripImportDto>>(jsonString);
            List<Trip> validTrips = new List<Trip>();
            StringBuilder sb = new StringBuilder();

            foreach (var trip in trips)
            {
                if (!IsValid(trip) 
                    || !stations.ContainsKey(trip.OriginStation) 
                    || !stations.ContainsKey(trip.DestinationStation)
                    || !trains.ContainsKey(trip.Train))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                TripStatus status = TripStatus.OnTime;
                if(trip.Status != null)
                {
                    status = Enum.Parse<TripStatus>(trip.Status);
                }

                TimeSpan? timeDiffernce = null;
                if(trip.TimeDifference != null)
                {
                    timeDiffernce = TimeSpan.ParseExact(trip.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                Trip validTrip = new Trip()
                {
                    OriginStationId = stations[trip.OriginStation],
                    DestinationStationId = stations[trip.DestinationStation],
                    ArrivalTime = DateTime.ParseExact(trip.ArrivalTime, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    DepartureTime = DateTime.ParseExact(trip.DepartureTime, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    TrainId = trains[trip.Train],
                    Status = status,
                    TimeDifference = timeDiffernce
                };

                if (!IsValid(validTrip))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                validTrips.Add(validTrip);
                sb.AppendLine($"Trip from {trip.OriginStation} to {trip.DestinationStation} imported.");
            }
            
            context.Trips.AddRange(validTrips);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
            XmlSerializer serializer = new XmlSerializer(typeof(CardImportDto[]), new XmlRootAttribute("Cards"));
            var cards = (CardImportDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            List<CustomerCard> validCards = new List<CustomerCard>();
            StringBuilder sb = new StringBuilder();

            foreach (var card in cards)
            {
                if (!IsValid(card))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CardType type = CardType.Normal;
                if(card.CardType != null)
                {
                    type = Enum.Parse<CardType>(card.CardType);
                }

                CustomerCard customerCard = new CustomerCard(card.Name, card.Age, type);

                validCards.Add(customerCard);
                sb.AppendLine(string.Format(SuccessMessage, card.Name));
            }

            context.Cards.AddRange(validCards);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		public static string ImportTickets(StationsDbContext context, string xmlString)
		{
            Dictionary<string, int> cards = context.Cards.ToDictionary(x => x.Name, y => y.Id);
            XmlSerializer serializer = new XmlSerializer(typeof(ImportTicketDto[]), new XmlRootAttribute("Tickets"));
            var tickets = (ImportTicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            List<Ticket> validTickets = new List<Ticket>();
            StringBuilder sb = new StringBuilder();

            foreach (var ticket in tickets)
            {
                if (!IsValid(ticket) || !IsValid(ticket.Trip))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                DateTime departureDate = DateTime.ParseExact(ticket.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Trip trip = context.Trips
                    .Include(t => t.Train)
                    .FirstOrDefault(t => t.OriginStation.Name == ticket.Trip.OriginStation
                    && t.DestinationStation.Name == ticket.Trip.DestinationStation
                    && t.DepartureTime == departureDate);

                if(trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Train train = trip.Train;

                string classAbbreviation = ticket.SeatingPlace.Substring(0, 2);
                bool validClassAbbreviation = train.TrainSeats.Any(s => s.SeatingClass.Abbreviation == classAbbreviation);
                int seatsCount = train.TrainSeats.
                    Where(s => s.SeatingClass.Abbreviation == classAbbreviation)
                    .Sum(s => s.Quantity);
                string seatNumberAsString = ticket.SeatingPlace.Substring(2, ticket.SeatingPlace.Length - 2);
                int seatNumber = int.Parse(seatNumberAsString);

                bool isValidNumber = seatNumber > 0 && seatNumber <= seatsCount;

                if(!validClassAbbreviation || !isValidNumber)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Ticket validTicket = new Ticket()
                {
                    Price = ticket.Price,
                    SeatingPlace = ticket.SeatingPlace,
                    TripId = trip.Id,
                };

                if (ticket.Card?.Name != null)
                {
                    if (cards.ContainsKey(ticket.Card.Name))
                    {
                        validTicket.CustomerCardId = cards[ticket.Card.Name];
                    }
                    else
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                validTickets.Add(validTicket);
                sb.AppendLine($"Ticket from {ticket.Trip.OriginStation} to {ticket.Trip.DestinationStation} " +
                    $"departing at {ticket.Trip.DepartureTime} imported.");
            }

            context.Tickets.AddRange(validTickets);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var context = new ValidationContext(entity);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, context, results, true);
            return isValid;
        }
    }
}
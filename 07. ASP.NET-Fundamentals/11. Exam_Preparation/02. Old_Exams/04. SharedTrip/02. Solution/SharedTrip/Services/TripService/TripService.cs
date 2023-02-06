﻿using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services.TripService
{
    public class TripService : ITripService
    {
        private IRepository repository;

        public TripService(IRepository _repository)
        {
            repository = _repository;
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = repository.All<Trip>()
                .Select(t => new TripViewModel()
                {
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    Id = t.Id,
                    Description = t.Description
                })
                .ToList();

            return trips;
        }

        public ICollection<string> Create(TripInputViewModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                errors.Add("StartPoint is required");
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                errors.Add("EndPoint is required");
            }

            if (string.IsNullOrWhiteSpace(model.DepartureTime))
            {
                errors.Add("DepartureTime is required");
            }

            if (string.IsNullOrWhiteSpace(model.Description))
            {
                errors.Add("Description is required");
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                errors.Add("Sests must be between 2 and 6");
            }

            if (errors.Any())
            {
                return errors;
            }

            try
            {
                Trip trip = new Trip()
                {
                    StartPoint = model.StartPoint,
                    EndPoint = model.EndPoint,
                    DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = model.Seats,
                    Description = model.Description,
                    ImagePath = model.ImagePath
                };

                repository.Add(trip);
                repository.SaveChanges();
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }
    }
}

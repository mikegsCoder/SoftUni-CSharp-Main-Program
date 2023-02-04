using SharedTrip.Data.Common;
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
    }
}

using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services.TripService
{
    public interface ITripService
    {
        IEnumerable<TripViewModel> GetAll();

        ICollection<string> Create(TripInputViewModel model);

        TripViewModel GetById(string tripId, string userId);

        ICollection<string> AddUserToTrip(string tripId, string userId);
    }
}

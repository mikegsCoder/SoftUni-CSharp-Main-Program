using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services.TripService
{
    public interface ITripService
    {
        IEnumerable<TripViewModel> GetAll();

        ICollection<string> Create(TripInputViewModel model);
    }
}

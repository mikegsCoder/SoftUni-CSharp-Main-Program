using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Services.TripService;
using SharedTrip.ViewModels;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private ITripService service;

        public TripsController(ITripService _service) 
        {   
            service = _service;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = new AllTripsViewModels()
            { 
                TripsViewModels = service.GetAll() 
            };

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(TripInputViewModel model)
        {
            var errors = service.Create(model);

            if (errors.Any())
            {
                AllErrorsViewModel errorModels = new AllErrorsViewModel()
                {
                    AllErrorsViewModels = errors.Select(e => new ErrorViewModel(e))
                };

                return View(errorModels, "/Error");
            }

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = service.GetById(tripId, User.Id);

            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var errors = service.AddUserToTrip(tripId, User.Id);

            if (errors.Any())
            {
                AllErrorsViewModel errorModels = new AllErrorsViewModel()
                {
                    AllErrorsViewModels = errors.Select(e => new ErrorViewModel(e))
                };

                return View(errorModels, "/Error");
            }

            return Redirect("/");
        }
    }
}

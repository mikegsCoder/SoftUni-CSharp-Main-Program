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
    }
}

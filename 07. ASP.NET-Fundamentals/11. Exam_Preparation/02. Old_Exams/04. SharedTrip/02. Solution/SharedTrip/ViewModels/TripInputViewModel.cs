using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.ViewModels
{
    public class TripInputViewModel
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string DepartureTime { get; set; }
        public int Seats { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a StartPoint – a string (required)
//•	Has a EndPoint – a string (required)
//•	Has a DepartureTime – a datetime (required) 
//•	Has a Seats – an integer with min value 2 and max value 6 (required)
//•	Has a Description – a string with max length 80 (required)
//•	Has a ImagePath – a string
//•	Has UserTrips collection – a UserTrip type


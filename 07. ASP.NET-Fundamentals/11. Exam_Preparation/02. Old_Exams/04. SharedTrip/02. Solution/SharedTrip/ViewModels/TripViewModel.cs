﻿namespace SharedTrip.ViewModels
{
    public class TripViewModel
    {
        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public string DepartureTime { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public bool IsJoined { get; set; } = false;
    }
}

using Stations.Models.Attributes;
using Stations.Models.Enums;
using System;

namespace Stations.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public int OriginStationId { get; set; }
        public Station OriginStation { get; set; }

        public int DestinationStationId { get; set; }
        public Station DestinationStation { get; set; }

        public DateTime DepartureTime { get; set; }

        [AfterDepartureTime(nameof(DepartureTime))]
        public DateTime ArrivalTime { get; set; }

        public int TrainId { get; set; }
        public Train Train { get; set; }

        public TripStatus Status { get; set; } = TripStatus.OnTime;

        public TimeSpan? TimeDifference { get; set; }
    }
}

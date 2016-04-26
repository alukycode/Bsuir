using System;
using System.Collections.Generic;

namespace Railway.Web.Models.SelectCar
{
    public class SelectCarViewModel
    {
        public string StartStationName { get; set; }

        public string DestinationStationName { get; set; }

        public int TrainId { get; set; }

        public string TrainNumber { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public TimeSpan TripDuration { get; set; }

        public IList<CarTypesData> CarTypes { get; set; }

        public class CarTypesData
        {
            public string CarTypeName { get; set; }

            public int Cost { get; set; }

            public IList<CarData> Cars { get; set; }

            public class CarData
            {
                public int Index { get; set; }

                public int SeatCount { get; set; } //todo: можно было бы учитывать lower/upper/lowerside/upperside места

                public IList<int> SeatIndexes { get; set; }
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Railway.Web.Models.SelectTrain
{
    public class SelectTrainViewModel
    {
        public string StartStationName { get; set; }

        public string DestionationStationName { get; set; }

        public DateTime DepartureDate { get; set; }

        public IList<TrainData> Trains { get; set; }

        public class TrainData
        {
            public string TrainNumber { get; set; }

            public bool IsExpress { get; set; }

            public bool IsDeLuxe { get; set; }

            public bool IsElectronicRegistrationAvailable { get; set; }

            public DateTime DepartureTime { get; set; }

            public DateTime ArrivalTime { get; set; }

            public TimeSpan TripTime { get; set; }

            public IList<CarData> Cars { get; set; }

            public class CarData
            {
                public string CarTypeName { get; set; }

                public int AvailableSeatCount { get; set; }

                public long Cost { get; set; }
            }
        }
    }
}
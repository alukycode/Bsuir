using System;
using System.Collections.Generic;
using Railway.Data.Entities;

namespace Railway.Web.Models.Railway
{
    public class SelectTrainViewModel
    {
        public SelectTrainRequestModel RequestModel { get; set; }

        public SelectTrainFormModel FormModel { get; set; }

        public IList<TrainData> Trains { get; set; }

        public IList<CarType> CarTypes { get; set; }

        public class TrainData
        {
            public int DailyRouteId { get; set; }
            public string TrainNumber { get; set; }
            public bool IsExpress { get; set; }
            public bool IsDeLuxe { get; set; }
            public bool IsElectronicRegistrationAvailable { get; set; }
            public DateTime DepartureTime { get; set; }
            public DateTime ArrivalTime { get; set; }
            public TimeSpan TripTime { get; set; }
            public IList<CarTypeData> Cars { get; set; }

            public class CarTypeData
            {
                public string CarTypeName { get; set; }
                public int AvailableSeatCount { get; set; }
                public double Cost { get; set; }
            }
        }
    }
}
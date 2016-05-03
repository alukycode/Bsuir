using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Railway.Data.Entities;

namespace Railway.Web.Models.Railway
{
    public class ConfirmOrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripDestinationDate { get; set; }
        public string TrainNumber { get; set; }
        
        public double TotalCost { get; set; }
        public string TripStartStationName { get; set; }
        public string TripDestinationStationName { get; set; }
        public virtual IList<PassengerData> OrderPassengers { get; set; }

        public class PassengerData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DocumentTypeName { get; set; }
            public string DocumentNumber { get; set; }
            public int SeatIndex { get; set; }
            public int CarIndex { get; set; }
        }
    }
}
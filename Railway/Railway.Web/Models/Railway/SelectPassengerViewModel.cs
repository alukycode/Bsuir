using System;
using System.Collections.Generic;

namespace Railway.Web.Models.Railway
{
    public class SelectPassengerViewModel
    {
        public IList<PassengerData> SavedPassengers { get; set; }

        public IList<IdentificationTypeData> DocumentTypes { get; set; }

        public string SubmitUrl { get; set; }
        public int MinSeat { get; set; }
        public int MaxSeat { get; set; }

        public int DailyRouteId { get; set; }
        public int StartStationId { get; set; }
        public int DestinationStationId { get; set; }
        public int CarId { get; set; }

        //public SelectPassengerFormModel FormModel { get; set; }

        public class PassengerData
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int DocumentTypeId  { get; set; }

            public string DocumentTypeName { get; set; }

            public string DocumentNumber { get; set; }
        }

        public class IdentificationTypeData
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
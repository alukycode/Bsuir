using System;

namespace Railway.Web.Models.Railway
{
    public class SelectRouteFormModel
    {
        public string DepartureStation { get; set; }

        public string DestinationStation { get; set; }

        public DateTime DepartureDate { get; set; }

        //public bool OnlyWithElectronicRegistration { get; set; }
    }
}
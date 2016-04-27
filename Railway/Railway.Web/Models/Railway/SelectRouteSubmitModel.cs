using System;

namespace Railway.Web.Models.Railway
{
    public class SelectRouteSubmitModel
    {
        public string DepartureStation { get; set; }

        public string DestionationStation { get; set; }

        public DateTime DepartureDate { get; set; }

        public bool OnlyWithElectronicRegistration { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Railway.Web.Models.Railway
{
    public class SelectPassengerRequestModel
    {
        public int StartStationId { get; set; }

        public int DestinationStationId { get; set; }

        public int DailyRouteId { get; set; }

        public int CarId { get; set; }
    }
}
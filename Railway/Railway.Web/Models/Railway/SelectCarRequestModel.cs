using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Railway.Web.Models.Railway
{
    public class SelectCarRequestModel
    {
        public int StartStationId { get; set; }

        public int DestinationStationId { get; set; }

        public int DailyRouteId { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Railway.Models.Models
{
    public partial class DailyRoute
    {
        public int DailyRouteId { get; set; }

        public DateTime StartDateTime { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}

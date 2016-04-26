using System;

namespace Railway.Data.Models
{
    public class DailyRoute
    {
        public int DailyRouteId { get; set; }

        public DateTime StartDateTime { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}

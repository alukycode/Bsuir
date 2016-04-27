using System;
using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class DailyRoute
    {
        public int DailyRouteId { get; set; }

        public DateTime StartDateTime { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }

    public class DailyRouteConfiguration : EntityTypeConfiguration<DailyRoute>
    {
        public DailyRouteConfiguration()
        {
            HasRequired(x => x.Route)
                .WithMany();
        }
    }
}

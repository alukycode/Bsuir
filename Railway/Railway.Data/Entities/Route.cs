using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class Route
    {
        public Route()
        {
            RouteStations = new HashSet<RouteStation>();
        }

        public int RouteId { get; set; }

        public int TrainId { get; set; }
        public virtual Train Train { get; set; }

        public virtual ICollection<RouteStation> RouteStations { get; set; }
    }

    public class RouteConfiguration : EntityTypeConfiguration<Route>
    {
        public RouteConfiguration()
        {
            HasRequired(x => x.Train);

            HasMany(x => x.RouteStations)
                .WithRequired()
                .HasForeignKey(x => x.RouteId)
                .WillCascadeOnDelete(true);
        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class RouteStation
    {
        public int RouteStationId { get; set; }

        public int MinutesFromStart { get; set; }
        public int StationOrder { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        public int StationId { get; set; }
        public virtual Station Station { get; set; }
    }


    public class RouteStationConfiguration : EntityTypeConfiguration<RouteStation>
    {
        public RouteStationConfiguration()
        {
            HasRequired(x => x.Route).WithMany().HasForeignKey(x => x.RouteId).WillCascadeOnDelete(false);
            HasRequired(x => x.Station).WithMany().WillCascadeOnDelete(false);
        }
    }

}

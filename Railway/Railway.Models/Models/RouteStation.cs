namespace Railway.Models.Models
{
    public partial class RouteStation
    {
        public int RouteStationId { get; set; }

        public int MinutesFromStart { get; set; }

        public int StationOrder { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        public int StationId { get; set; }
        public virtual Station Station { get; set; }
    }
}

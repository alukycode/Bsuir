using System.Collections.Generic;

namespace Railway.Models.Models
{
    public partial class Route
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
}

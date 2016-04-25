using System.Collections.Generic;

namespace Railway.Models.Models
{
    public partial class CarType
    {
        public int CarTypeId { get; set; }

        public string TypeName { get; set; }
        public double CostRate { get; set; }
        public int SeatCount { get; set; }
    }
}

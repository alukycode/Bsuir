using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public int CarIndex { get; set; }

        public int CarTypeId { get; set; }
        public virtual CarType CarType { get; set; }

        public virtual int TrainId { get; set; }
        public virtual Train Train { get; set; }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        public int CarIndex { get; set; }

        public int CarTypeId { get; set; }
        public virtual CarType CarType { get; set; }

        public int TrainId { get; set; }
        public virtual Train Train { get; set; }
    }

    public class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            HasRequired(x => x.CarType).WithMany().HasForeignKey(x => x.CarTypeId).WillCascadeOnDelete(false);
            HasRequired(x => x.Train).WithMany().HasForeignKey(x => x.TrainId).WillCascadeOnDelete(false);
        }
    }
}

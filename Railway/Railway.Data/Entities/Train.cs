using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class Train
    {
        public Train()
        {
            Cars = new HashSet<Car>();
        }

        public int TrainId { get; set; }

        public string TrainNumber { get; set; }
        public bool IsElectronicRegistrationAvailable { get; set; }
        public bool IsExpress { get; set; }
        public bool IsDeLuxe { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }

    public class TrainConfiguration : EntityTypeConfiguration<Train>
    {
        public TrainConfiguration()
        {
            HasMany(x => x.Cars).WithRequired().HasForeignKey(x => x.TrainId).WillCascadeOnDelete(true);
        }
    }
}

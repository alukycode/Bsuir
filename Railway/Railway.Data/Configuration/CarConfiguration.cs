using System.Data.Entity.ModelConfiguration;
using Railway.Data.Models;

namespace Railway.Data.Configuration
{
    public class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            ToTable("Cars");
            HasRequired(x => x.CarType)
                .WithOptional()
                .WillCascadeOnDelete(false);
        }
    }
}

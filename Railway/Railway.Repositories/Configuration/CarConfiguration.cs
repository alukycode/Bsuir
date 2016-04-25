using System.Data.Entity.ModelConfiguration;
using Railway.Models.Models;

namespace Railway.Repositories.Configuration
{
    public class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            ToTable("Cars");
            Property(x => x.CarTypeId).IsRequired();
        }
    }
}

using System.Data.Entity;
using Railway.Models.Models;
using Railway.Repositories.Configuration;

namespace Railway.Repositories
{
    public class RailwayContext : DbContext
    {
        public RailwayContext() : base("RailwayDatabaseConnection") { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarConfiguration());
        }
    }
}

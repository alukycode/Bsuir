using System.Data.Entity;
using Railway.Data.Configuration;
using Railway.Data.Models;

namespace Railway.Data
{
    public class RailwayContext : DbContext
    {
        public RailwayContext() : base("RailwayDatabaseConnection") { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<OrderPassenger> OrderPassengers { get; set; }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<DailyRoute> DailyRoutes { get; set; }
        public virtual DbSet<Distance> Distances { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteStation> RouteStations { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CarConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderPassengerConfiguration());
        }
    }
}

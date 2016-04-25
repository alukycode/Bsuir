namespace EfProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdoNetEntityDataModel : DbContext
    {
        public AdoNetEntityDataModel()
            : base("name=RailwayDatabaseConnection")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<DailyRoute> DailyRoutes { get; set; }
        public virtual DbSet<Distance> Distances { get; set; }
        public virtual DbSet<OrderPassenger> OrderPassengers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteStation> RouteStations { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.CarIndex)
                .IsFixedLength();

            modelBuilder.Entity<DailyRoute>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.DailyRoute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderPassenger>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.DailyRoutes)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Distances)
                .WithRequired(e => e.Station)
                .HasForeignKey(e => e.DestinationStationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Distances1)
                .WithRequired(e => e.Station1)
                .HasForeignKey(e => e.StartStationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Station)
                .HasForeignKey(e => e.TripDestinationStationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Orders1)
                .WithRequired(e => e.Station1)
                .HasForeignKey(e => e.TripStartStationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Passengers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

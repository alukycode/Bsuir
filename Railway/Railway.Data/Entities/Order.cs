using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class Order
    {
        public Order()
        {
            OrderPassengers = new HashSet<OrderPassenger>();
        }

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripDestinationDate { get; set; }
        public string TrainNumber { get; set; }
        public int PaymentSystem { get; set; }
        public bool ElectronicRegistration { get; set; }
        public double TotalCost { get; set; }

        public int DailyRouteId { get; set; }
        public virtual DailyRoute DailyRoute { get; set; }

        public int TripStartStationId { get; set; }
        public virtual Station TripStartStation { get; set; }

        public int TripDestinationStationId { get; set; }
        public virtual Station TripDestinationStation { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderPassenger> OrderPassengers { get; set; }
    }

    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasMany(x => x.OrderPassengers).WithRequired(x => x.Order).WillCascadeOnDelete();
            HasRequired(x => x.DailyRoute).WithMany().WillCascadeOnDelete(false);

            HasRequired(x => x.TripStartStation)
                .WithMany()
                .HasForeignKey(x => x.TripStartStationId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.TripDestinationStation)
                .WithMany()
                .HasForeignKey(x => x.TripDestinationStationId)
                .WillCascadeOnDelete(false);
        }
    }
}

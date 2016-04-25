namespace EfProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderPassengers = new HashSet<OrderPassenger>();
        }

        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public int DailyRouteId { get; set; }

        public int TripStartStationId { get; set; }

        public int TripDestinationStationId { get; set; }

        public DateTime? TripStartDate { get; set; }

        public DateTime? TripDestionationDate { get; set; }

        [StringLength(10)]
        public string TrainNumber { get; set; }

        public int PaymentSystemId { get; set; }

        public bool ElectronicRegistration { get; set; }

        public virtual DailyRoute DailyRoute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPassenger> OrderPassengers { get; set; }

        public virtual Station Station { get; set; }

        public virtual Station Station1 { get; set; }

        public virtual User User { get; set; }
    }
}

namespace EfProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Passenger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passenger()
        {
            OrderPassengers = new HashSet<OrderPassenger>();
        }

        public int PassengerId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public int IdentificationTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentificationNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPassenger> OrderPassengers { get; set; }

        public virtual User User { get; set; }
    }
}

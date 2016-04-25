namespace EfProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderPassenger
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PassengerId { get; set; }

        public int CarId { get; set; }

        public int SeatIndex { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public virtual Order Order { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}

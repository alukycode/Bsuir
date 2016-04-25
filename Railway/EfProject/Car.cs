namespace EfProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Car
    {
        public int CarId { get; set; }

        [Required]
        [StringLength(10)]
        public string TrainNumber { get; set; }

        [StringLength(10)]
        public string CarIndex { get; set; }

        public int CarTypeId { get; set; }

        public virtual CarType CarType { get; set; }

        public virtual Train Train { get; set; }
    }
}

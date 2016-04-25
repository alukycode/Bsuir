namespace Railway.Models.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public int CarIndex { get; set; }

        public int CarTypeId { get; set; }
        public virtual CarType CarType { get; set; }
    }
}

namespace Railway.Models.Models
{
    public partial class OrderPassenger
    {
        public int OrderPassengerId { get; set; }

        public int CarId { get; set; }
        public int SeatIndex { get; set; }
        public double Cost { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}

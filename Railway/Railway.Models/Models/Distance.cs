namespace Railway.Models.Models
{
    public partial class Distance
    {
        public int DistanceId { get; set; } // todo: remove and set primary key on stations

        public double DistanceValue { get; set; }

        public int StartStationId { get; set; }
        public virtual Station StartStation { get; set; }

        public int DestinationStationId { get; set; }
        public virtual Station DestinationStation { get; set; }
    }
}
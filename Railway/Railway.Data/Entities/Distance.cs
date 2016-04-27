using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class Distance
    {
        public int DistanceId { get; set; }

        public double DistanceValue { get; set; }

        public int StartStationId { get; set; }
        public virtual Station StartStation { get; set; }

        public int DestinationStationId { get; set; }
        public virtual Station DestinationStation { get; set; }
    }

    public class DistanceConfiguration : EntityTypeConfiguration<Distance>
    {
        public DistanceConfiguration()
        {
            HasRequired(x => x.StartStation)
                .WithMany()
                .HasForeignKey(x => x.StartStationId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.DestinationStation)
                .WithMany()
                .HasForeignKey(x => x.DestinationStationId)
                .WillCascadeOnDelete(false);
        }
    }
}
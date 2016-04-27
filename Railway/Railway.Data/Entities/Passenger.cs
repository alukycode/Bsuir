using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class Passenger
    {
        public int PassengerId { get; set; }

        public string FullName { get; set; }
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class PassengerConfiguration : EntityTypeConfiguration<Passenger>
    {
        public PassengerConfiguration()
        {
            HasRequired(x => x.User).WithMany();
        }
    }
}

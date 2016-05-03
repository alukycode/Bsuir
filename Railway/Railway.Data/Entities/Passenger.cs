using System.Data.Entity.ModelConfiguration;

namespace Railway.Data.Entities
{
    public class Passenger
    {
        public int PassengerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }

        public int IdentificationTypeId { get; set; }
        public virtual IdentificationType IdentificationType { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class PassengerConfiguration : EntityTypeConfiguration<Passenger>
    {
        public PassengerConfiguration()
        {
            HasRequired(x => x.User).WithMany();
            HasRequired(x => x.IdentificationType).WithMany();
        }
    }
}

using System.Collections.Generic;

namespace Railway.Models.Models
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }

        public string FullName { get; set; }
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}

using System.Collections.Generic;

namespace Railway.Models.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Passengers = new HashSet<Passenger>();
        }

        public int UserId { get; set; }

        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}

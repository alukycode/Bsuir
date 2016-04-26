using System.Collections.Generic;

namespace Railway.Data.Models
{
    public class Train
    {
        public Train()
        {
            Cars = new HashSet<Car>();
        }

        public int TrainId { get; set; }

        public string TrainNumber { get; set; }
        public bool IsElectronicRegistrationAvailable { get; set; }
        public bool IsExpress { get; set; }
        public bool IsDeLuxe { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}

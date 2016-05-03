using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Entities
{
    public class IdentificationType
    {
        public int IdentificationTypeId { get; set; }

        public string Name { get; set; }
    }
}

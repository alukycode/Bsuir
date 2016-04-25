using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Railway.Web.Models.SelectRoute
{
    public class SelectRouteViewModel
    {
        public string NextStepUrl { get; set; }

        public IList<SimpleDropdownOptions> Stations { get; set; }

        public class SimpleDropdownOptions
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
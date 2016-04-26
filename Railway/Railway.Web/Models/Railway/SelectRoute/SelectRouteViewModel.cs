using System.Collections.Generic;

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
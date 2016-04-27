using System.Collections.Generic;

namespace Railway.Web.Models.Railway
{
    public class SelectRouteViewModel
    {
        public string NextStepUrl { get; set; }
        public List<List<string>> AvailableRoutes { get; set; }
    }
}
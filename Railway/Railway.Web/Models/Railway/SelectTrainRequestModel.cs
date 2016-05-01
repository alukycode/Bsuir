using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Railway.Web.Models.Railway
{
    public class SelectTrainRequestModel
    {
        public int StartStationId { get; set; }

        public int DestinationStationId { get; set; }

        public DateTime DepartureDate { get; set; }
    }
}
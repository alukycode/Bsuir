using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Railway.Web.Models.SelectTrain
{
    public class SelectTrainSubmitModel
    {
        public int DailyRouteId { get; set; }

        public int TrainId { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Railway.Web.Models.Railway
{
    public class SelectCarViewModel
    {
        public IList<CarTypeData> CarTypes { get; set; }

        public IList<CarData> Cars { get; set; }

        public class CarData
        {
            public int CarId { get;  set;}

            public int CarTypeId { get;  set;}

            public int Index { get; set; }

            public int SeatCount { get; set; }

            public IList<int> SeatIndexes { get; set; }
        }

        public class CarTypeData
        {
            public int CarTypeId { get; set; }

            public string CarTypeName { get; set; }

            public double Cost { get; set; }
        }

        public SelectCarFormModel FormModel { get; set; }
    }
}
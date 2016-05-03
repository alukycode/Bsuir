using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Railway.Web.Models.Railway
{
    public class SelectPassengerResponseModel
    {
        public bool Success { get; set; }

        public string RedirectUrl { get; set; }

        public string Message { get; set; }
    }
}
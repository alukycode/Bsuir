using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Railway.Web.Models.Home;

namespace Railway.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel();
            return View(viewModel);
        }
    }
}
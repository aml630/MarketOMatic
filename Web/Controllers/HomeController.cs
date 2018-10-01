using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new MarketOMaticEntities())
            {
                var test = db.Sites.ToList();

                return View("Home", test);
            };
        }
    }
}
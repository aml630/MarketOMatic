using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new MarketOMaticEntities())
            {
                var thisSite = db.Sites.Include("PinterestBoards").FirstOrDefault();

                return View("Home", thisSite);
            }
        }

        public ActionResult React()
        {
            return View("React");
        }
    }
}
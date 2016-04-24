using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace houserent.Controllers
{
    public class ListController : Controller
    {
        //
        // GET: /List/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewList()
        {
            return View();
        }

    }
}

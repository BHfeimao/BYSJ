using PM25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM25.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult DetailBT(int id)
        {
            return View();
        }
        public ActionResult DetailIF(int id)
        {
            return View();
        }
        public ActionResult DetailNEW(int id)
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PM25.Models;

namespace PM25.Controllers
{
    public class MoreController : Controller
    {
        // GET: More
        public ActionResult Show(int? id )
        {
            ViewBag.ID = id;
            return View();
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM25.Controllers
{
    public class PediasController : Controller
    {
        // GET: Pedias
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int? id)
        {
            ViewBag.ID = id;
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.ID = id;
            return View();
        }

        public ActionResult Details(int? id)
        {
            ViewBag.ID = id;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM25.Controllers
{
    public class NowsController : Controller
    {
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Up(HttpPostedFileBase upfile)
        {
            //檢查是否有選擇檔案
            if (upfile != null)
            {
                //檢查檔案大小要限制也可以在這裡做
                if (upfile.ContentLength > 0)
                {
                    string savedName = Path.Combine(Server.MapPath("~/Temp/"), upfile.FileName);
                    upfile.SaveAs(savedName);
                    Session["name"] = upfile.FileName;
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        // GET: Nows
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.name = Session["name"];
            return View();
        }

        public ActionResult Delete(int? id)
        {
            ViewBag.ID = id;
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.name = Session["name"];
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
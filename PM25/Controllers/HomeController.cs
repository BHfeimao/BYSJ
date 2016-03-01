using PM25.InterfaceFile.Pedias;
using PM25.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM25.DTO.Pedias;
using PM25.DTO.BodyTems;
using PM25.DTO.Infras;
using PM25.DTO.IllnessStus;
using PM25.DTO.InfraStus;
using PM25.DTO.News;
using PM25.DTO.Nows;
using PM25.DTO;

namespace PM25.Controllers
{
    public class HomeController : Controller
    {
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public ActionResult Index()
        {
            //var data = new Infras().GetAllInfra();
            //ViewBag.img = data[0].img;
            //ViewBag.ss = data[0].summary;
            //ViewBag.dd = data[0].detail;
            //var success = new BodyTems().InsertBodyTem("123","infra1","这里是内容02");
            //var success = new Pedias().DeletePedia(11);
            //var success = new Infras().DeleteInfra(1);
            //var data = new News().GetNewById(3);
            //ViewBag.tt = data.img;
            //ViewBag.text = data.summary;
            //ViewBag.dd = data.detail;
            //ViewBag.id = data.ID;
            return View();           
        }

        public ActionResult More(int? id)
        {
            ViewBag.ID = id > 0 ? id : 0;
            return View();
        }
       
        public ActionResult Bodytem(int? id)
        {
            ViewBag.ID = id > 0 ? id : 0;
            return View();
        }

        public ActionResult Infra(int? id)
        {
            ViewBag.ID = id > 0 ? id : 0;
            return View();
        }

        public ActionResult Now(int? id)
        {
            ViewBag.ID = id > 0 ? id : 0;
            return View();
        }

        public ActionResult Down(string name)
        {
            //我要下載的檔案位置
            string filepath = Server.MapPath("~/Temp/"+name );
            //取得檔案名稱
            string filename = System.IO.Path.GetFileName(filepath);
            //讀成串流
            Stream iStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            //回傳出檔案
            return File(iStream, "application/zip", filename);
        }

        public ActionResult New(int? id)
        {
            ViewBag.ID = id > 0 ? id : 0;
            return View();
        }

        public ActionResult InfraStu(int? id)
        {
            ViewBag.ID = id > 0 ? id : 0;
            return View();
        }

        public ActionResult IllnessStu(int? id)
        {
            ViewBag.ID = id > 0 ? id : 0;
            return View();
        }

        #region 百科知识
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetAllPedia()
        {
            return Json(new Pedias().GetAllPedia(), JsonRequestBehavior.AllowGet); 
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool InsertPedia(Pedia data)
        {
            return new Pedias().InsertPedia(data.title, data.text);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool DeletePedia(int ID)
        {
            return new Pedias().DeletePedia(ID);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool UpdataPedia(Pedia data)
        {
            return new Pedias().UpdataPedia(data.ID, data.title, data.text);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetPediaById(int ID)
        {
            return Json(new Pedias().GetPediaById(ID),JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 体温与疾病

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetAllBodyTem()
        {
            return Json(new BodyTems().GetAllBodyTem(), JsonRequestBehavior.AllowGet); 
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool DeleteBodyTem(int ID)
        {
            return new BodyTems().DeleteBodyTem(ID);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool InsertBodyTem(BodyTem data)
        {
            return new BodyTems().InsertBodyTem(data.img, data.summary, data.detail);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool UpdataBodyTem(BodyTem data)
        {
            return new BodyTems().UpdataBodyTem(data.ID, data.img, data.summary, data.detail);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetBodyTemById(int ID)
        {
            return Json(new BodyTems().GetBodyTemById(ID),JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 疾病知识

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetAllIllnessStu()
        {
            return Json(new IllnessStus().GetAllIllnessStu(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool DeleteIllnessStu(int ID)
        {
            return new IllnessStus().DeleteIllnessStu(ID);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetIllnessStuById(int ID)
        {
            return Json(new IllnessStus().GetIllnessStuById(ID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool InsertIllnessStu(IllnessStu data)
        {
            return new IllnessStus().InsertIllnessStu(data.img, data.summary, data.detail);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool UpdataIllnessStu(IllnessStu data)
        {
            return new IllnessStus().UpdataIllnessStu(data.ID, data.img, data.summary, data.detail);
        }

        #endregion

        #region 红外医学应用

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetAllInfra()
        {
            return Json(new Infras().GetAllInfra(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool DeleteInfra(int ID)
        {
            return new Infras().DeleteInfra(ID);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool InsertInfra(Infra data)
        {
            return new Infras().InsertInfra(data.img, data.summary, data.detail);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool UpdataInfra(Infra data)
        {
            return new Infras().UpdataInfra(data.ID, data.img, data.summary, data.detail);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetInfraById(int ID)
        {
            return Json(new Infras().GetInfraById(ID), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 红外知识

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetAllInfraStu()
        {
            return Json(new InfraStus().GetAllInfraStu(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool DeleteInfraStu(int ID)
        {
            return new InfraStus().DeleteInfraStu(ID);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetInfraStuById(int ID)
        {
            return Json(new InfraStus().GetInfraStuById(ID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool InsertInfraStu(InfraStu data)
        {
            return new InfraStus().InsertInfraStu(data.img, data.summary, data.detail);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool UpdataInfraStu(InfraStu data)
        {
            return new InfraStus().UpdataInfraStu(data.ID, data.img, data.summary, data.detail);
        }

        #endregion

        #region 新闻动态

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetAllNew()
        {
            return Json(new News().GetAllNew(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public bool DeleteNew(int ID)
        {
            return new News().DeleteNew(ID);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetNewById(int ID)
        {
            return Json(new News().GetNewById(ID),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public bool InsertNew(New data)
        {
            return new News().InsertNew(data.img, data.summary, data.detail);
        }

        [HttpPost]
        [ValidateInput(false)]
        public bool UpdataNew(New data)
        {
            return new News().UpdataNew(data.ID, data.img, data.summary, data.detail);
        }

        #endregion

        #region 前沿研究

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetAllNow()
        {
            return Json(new Nows().GetAllNow(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool DeleteNow(int ID)
        {
            return new Nows().DeleteNow(ID);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool InsertNow(Now data)
        {
            return new Nows().InsertNow(data.title, data.summary, data.downloadURL);
        }
        [HttpPost]
        [ValidateInput(false)]
        public bool UpdataNow(Now data)
        {
            return new Nows().UpdataNow(data.ID, data.title, data.summary, data.downloadURL);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GetNowById(int ID)
        {
            return Json(new Nows().GetNowById(ID), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
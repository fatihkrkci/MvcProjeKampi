using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writerInfo = wm.GetByMail(p);
            var contentValues = cm.GetListByWriter(writerInfo.WriterId);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writerInfo = wm.GetByMail(mail);

            p.ContentDate = DateTime.Now;
            p.WriterId = writerInfo.WriterId;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}
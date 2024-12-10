using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            List<SelectListItem> writers = (from x in wm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.WriterName + " " + x.WriterSurname,
                                                   Value = x.WriterId.ToString()
                                               }).ToList();
            ViewBag.Writers = writers;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Now;
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        //public ActionResult DeleteCategory(int id)
        //{
        //    var categoryValue = cm.GetById(id);
        //    cm.CategoryDelete(categoryValue);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult EditWriter(int id)
        //{
        //    var writerValue = wm.GetById(id);
        //    return View(writerValue);
        //}

        //[HttpPost]
        //public ActionResult EditWriter(Writer p)
        //{
        //    WriterValidator validator = new WriterValidator();
        //    ValidationResult results = validator.Validate(p);
        //    if (results.IsValid)
        //    {
        //        wm.WriterUpdate(p);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        foreach (var item in results.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}
    }
}
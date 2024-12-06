using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminStatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var totalCategoryCount = context.Categories.ToList().Count();
            ViewBag.TotalCategoryCount = totalCategoryCount;

            var softwareHeadingsCount = context.Headings.Where(x => x.Category.CategoryName == "Yazılım").ToList().Count();
            ViewBag.SoftwareHeadingsCount = softwareHeadingsCount;

            var writerNameCountWithA = context.Writers.Where(x => x.WriterName.Contains("a")).ToList().Count();
            ViewBag.WriterNameCountWithA = writerNameCountWithA;

            var categoryWithMostHeadings = context.Categories
                                      .Select(c => new
                                      {
                                          CategoryName = c.CategoryName,
                                          HeadingCount = c.Headings.Count
                                      })
                                      .OrderByDescending(c => c.HeadingCount)
                                      .FirstOrDefault();

            ViewBag.CategoryWithMostHeadings = categoryWithMostHeadings.CategoryName;

            var statusTrueCategoryCount = context.Categories.Where(x => x.CategoryStatus == true).ToList().Count();
            var statusFalseCategoryCount = context.Categories.Where(x => x.CategoryStatus == false).ToList().Count();
            var categoryDifference = statusTrueCategoryCount - statusFalseCategoryCount;
            ViewBag.CategoryDifference = categoryDifference;


            return View();
        }
    }
}
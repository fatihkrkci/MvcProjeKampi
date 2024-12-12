using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjeKampi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class RegisterController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            p.AdminRole = "A";
            p.AdminPassword = HashHelper.ComputeHash(p.AdminPassword);
            adm.AdminAdd(p);
            return RedirectToAction("Index", "Login");
        }
    }
}
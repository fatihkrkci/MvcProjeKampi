using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminUserInfo = adm.GetAdmin(p.AdminUsername, p.AdminPassword);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUsername, false);
                Session["AdminUsername"] = adminUserInfo.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                TempData["LoginError"] = "Kullanıcı adı veya şifre hatalı!";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var writerUserInfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                TempData["LoginError"] = "Kullanıcı adı veya şifre hatalı!";
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}
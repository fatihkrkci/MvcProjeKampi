using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator validator = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.GetById(id);
            contactValue.Message = HttpUtility.HtmlDecode(contactValue.Message);
            return View(contactValue);
        }

        public PartialViewResult SidebarPartial()
        {
            var contactCount = cm.GetList().Count();
            ViewBag.ContactCount = contactCount;

            var inboxCount = mm.GetListInbox().Count();
            ViewBag.InboxCount = inboxCount;

            var sendboxCount = mm.GetListSendbox().Count();
            ViewBag.SendboxCount = sendboxCount;

            var unreadMessages = mm.GetListInbox().Where(x => x.IsRead == false).ToList().Count();
            ViewBag.UnreadMessages = unreadMessages;

            return PartialView();
        }
    }
}
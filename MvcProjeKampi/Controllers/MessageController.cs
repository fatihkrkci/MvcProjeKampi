using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator validator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            values.MessageContent = HttpUtility.HtmlDecode(values.MessageContent);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            values.MessageContent = HttpUtility.HtmlDecode(values.MessageContent);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = validator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Now;
                p.MessageContent = HttpUtility.HtmlEncode(p.MessageContent);
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult IsReadTrue(int id)
        {
            var message = mm.GetById(id);
            message.IsRead = true;
            mm.MessageUpdate(message);
            return RedirectToAction("Inbox");
        }

        public ActionResult IsReadFalse(int id)
        {
            var message = mm.GetById(id);
            message.IsRead = false;
            mm.MessageUpdate(message);
            return RedirectToAction("Inbox");
        }
    }
}
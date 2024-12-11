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
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
        }

        public ActionResult GetMessageDetails(int id)
        {
            var messageValue = mm.GetById(id);
            messageValue.MessageContent = HttpUtility.HtmlDecode(messageValue.MessageContent);
            return View(messageValue);
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
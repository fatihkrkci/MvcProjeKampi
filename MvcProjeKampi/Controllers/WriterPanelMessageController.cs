using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator validator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
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
                p.SenderMail = "gizem@hotmail.com";
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
    }
}
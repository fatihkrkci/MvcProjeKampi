using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail)
                .NotEmpty().WithMessage("Alıcı E-Postası Boş Geçilemez!")
                .EmailAddress().WithMessage("Geçerli bir E-Posta Adresi Giriniz!");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Konu en az 3 Karakter Olmalı!")
                .MaximumLength(100).WithMessage("Konu en fazla 100 Karakter Olmalı!");

            RuleFor(x => x.MessageContent)
                .NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez!");
        }
    }
}

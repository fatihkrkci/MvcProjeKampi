using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("E-Posta Adresi Boş Geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 Karakter Olmalı!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu en az 3 Karakter Olmalı!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu en fazla 50 Karakter Olmalı!");
        }
    }
}

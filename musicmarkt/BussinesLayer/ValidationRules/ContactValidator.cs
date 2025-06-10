using EntitiLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("konu Adını  boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Kullanıcı Adını  boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("lütfen 50 karakterden fazla değer girişi yapmayın");
        }
    }
}

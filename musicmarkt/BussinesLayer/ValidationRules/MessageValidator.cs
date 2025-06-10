using EntitiLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
       public MessageValidator() 
        {
            RuleFor(x => x.ReciverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını  boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı  boş geçemezsiniz");           
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("lütfen 100 karakterden fazla değer girişi yapmayın");
        }
    }
}

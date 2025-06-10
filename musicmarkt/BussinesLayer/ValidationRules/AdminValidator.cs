using EntitiLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator() 
        {
            RuleFor(x => x.AdminUsername).NotEmpty().WithMessage("kullanıcı adını Boş Geçemezsin");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("şifreyi boş geçemezsiniz");
        }
    }
}

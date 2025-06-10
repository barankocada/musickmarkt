using EntitiLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class ArtistValidator: AbstractValidator<Artist>
    {
        public ArtistValidator()
        {
            RuleFor(x => x.ArtistName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsin");
            RuleFor(x => x.ArtistSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.ArtistAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz");
            RuleFor(x => x.ArtistName).MinimumLength(3).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.ArtistSurname).MaximumLength(50).WithMessage("lütfen 50 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.ArtistTitle).MaximumLength(20).WithMessage("lütfen 20 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.ArtistTitle).NotEmpty().WithMessage("Yazar Ünvanı Boş Geçemezsin");
        }
    }
}

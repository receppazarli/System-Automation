using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.ValidationRules.FluentValidation
{
    public class UserAuthorizationValidator:AbstractValidator<User>
    {
        public UserAuthorizationValidator()
        {
            RuleFor(x => x.klnc_ad).NotEmpty().WithMessage("Kullanıcı Adı alanı boş olamaz");
            RuleFor(x => x.klnc_yetki).NotEmpty().WithMessage("Kullanıcı yetki alanı boş olamaz");
        }
    }
}

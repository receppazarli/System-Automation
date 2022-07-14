using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.ValidationRules.FluentValidation
{
    public class TypeValidator :AbstractValidator<Type1>
    {
        public TypeValidator()
        {
            RuleFor(x => x.TypeName).NotEmpty().WithMessage("Tür Ad alanı boş olamaz.");
            RuleFor(x => x.Unit).NotEmpty().WithMessage("Birim alanı boş olamaz.");
        }
    }
}

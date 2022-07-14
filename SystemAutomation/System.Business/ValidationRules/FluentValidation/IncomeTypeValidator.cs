using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.ValidationRules.FluentValidation
{
    public class IncomeTypeValidator:AbstractValidator<IncomeType>
    {
        public IncomeTypeValidator()
        {
            RuleFor(x => x.IncomeName).NotEmpty().WithMessage("Gelir Türü Ad alanı boş olamaz");
        }
    }
}

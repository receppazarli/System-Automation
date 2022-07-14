using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.ValidationRules.FluentValidation
{
    public class ExpenseTypeValidator:AbstractValidator<ExpenseType>
    {
        public ExpenseTypeValidator()
        {
            RuleFor(x => x.ExpenseTypeName).NotEmpty().WithMessage("Gider Türü Ad alanı boş olamaz");
        } 
    }
}

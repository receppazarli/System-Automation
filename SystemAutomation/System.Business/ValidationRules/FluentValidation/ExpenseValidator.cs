using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.ValidationRules.FluentValidation
{
    public class ExpenseValidator:AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {
            RuleFor(x => x.ExpenseTypeId).NotEmpty().WithMessage("Gider Türü alanı boş olamaz.");
            RuleFor(x => x.WhomPerson).NotEmpty().WithMessage("Kime yapıldı alanı boş olamaz.");
            RuleFor(x => x.WhoEmployee).NotEmpty().WithMessage("Kim yaptı alanı boş olamaz");
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("Tür alanı boş olamaz");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Miktar alanı boş olamaz");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("Miktar alanı 0 dan küçük olamaz");
            RuleFor(x => x.ExpenseIssueDate).NotEmpty().WithMessage("Gider çıkış tarih alanı boş olamaz");
            RuleFor(x => x.Explanation).MaximumLength(1000).WithMessage("Açıklama alanı maksimum 1000 karakter olabilir.");

        }
    }
}

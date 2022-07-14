using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.ValidationRules.FluentValidation
{
    public class IncomeValidator :AbstractValidator<Income>
    {
        public IncomeValidator()
        {
            RuleFor(x => x.IncomeTypesId).NotEmpty().WithMessage("Gelir Türü alanı boş olamaz.");
            RuleFor(x => x.GiverPersonId).NotEmpty().WithMessage("Yardımı Yapan Kişi alanı boş olamaz");
            RuleFor(x => x.ReceivingPersonId).NotEmpty().WithMessage("Yardımı Alan Personel alanı boş olamaz.");
            RuleFor(x => x.SpeciesId).NotEmpty().WithMessage("Tür alanı boş olamaz");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Miktar alanı boş olamaz");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("Miktar alanı 0 dan küçük olamaz");
            RuleFor(x => x.DateReceived).NotEmpty().WithMessage("Yardımın Alındığı Tarih alanı boş olamaz");
            RuleFor(x => x.Explanation).MaximumLength(1000).WithMessage("Açıklama alanı maksimum 1000 karakter olabilir.");
        }
    }
}

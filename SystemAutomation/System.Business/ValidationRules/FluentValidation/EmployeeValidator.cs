using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş olamaz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Numarası alanı boş olamaz");
        }
    }
}

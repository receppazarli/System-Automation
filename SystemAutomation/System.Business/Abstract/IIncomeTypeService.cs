using System.Collections.Generic;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface IIncomeTypeService
    {
        List<IncomeType> GetAll();
        void Add(IncomeType incomeType);
        void Update(IncomeType incomeType);
        void Remove(IncomeType incomeType);
    }
}
using System.Collections.Generic;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public interface IIncomeService
    {
        List<Income> GetAll();
        void Add(Income income);
        //void DenemeList();
        void Update(Income income);
       
    }
}
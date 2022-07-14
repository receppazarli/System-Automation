using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Abstract
{
    public interface IExpenseTypeService
    {
        List<ExpenseType> GetAll();
        void Add(ExpenseType expenseType);
        void Update(ExpenseType expenseType);
    }
}

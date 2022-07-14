using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IlimYayma.Business.Abstract;
using IlimYayma.Business.Utilities;
using IlimYayma.Business.ValidationRules.FluentValidation;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private IExpenseDal _expenseDal;

        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }

        public void Add(Expense expense)
        {
            try
            {
                ValidationTool.Validate(new ExpenseValidator(), expense);
                _expenseDal.Add(expense);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Update(Expense expense)
        {
            try
            {
                ValidationTool.Validate(new ExpenseValidator(), expense);
                _expenseDal.Update(expense);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

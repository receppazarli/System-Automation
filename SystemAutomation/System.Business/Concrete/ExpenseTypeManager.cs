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
    public class ExpenseTypeManager : IExpenseTypeService
    {
        private IExpenseTypeDal _expenseTypeDal;

        public ExpenseTypeManager(IExpenseTypeDal expenseTypeDal)
        {
            _expenseTypeDal = expenseTypeDal;
        }

        public List<ExpenseType> GetAll()
        {
            try
            {
                return _expenseTypeDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public void Add(ExpenseType expenseType)
        {
            try
            {
                ValidationTool.Validate(new ExpenseTypeValidator(), expenseType);
                _expenseTypeDal.Add(expenseType);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public void Update(ExpenseType expenseType)
        {
            try
            {
                ValidationTool.Validate(new ExpenseTypeValidator(), expenseType);
                _expenseTypeDal.Update(expenseType);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}

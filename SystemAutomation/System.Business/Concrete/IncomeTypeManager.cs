using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IlimYayma.Business.Utilities;
using IlimYayma.Business.ValidationRules.FluentValidation;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public class IncomeTypeManager : IIncomeTypeService
    {
        private IIncomeTypeDal _incomeTypeDal;

        public IncomeTypeManager(IIncomeTypeDal incomeTypeDal)
        {
            _incomeTypeDal = incomeTypeDal;
        }

        public List<IncomeType> GetAll()
        {
            try
            {
                return _incomeTypeDal.GetAll(x => x.DeleteFlag == false);

            }
            catch (Exception)
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Add(IncomeType incomeType)
        {
            try
            {
                ValidationTool.Validate(new IncomeTypeValidator(), incomeType);
                _incomeTypeDal.Add(incomeType);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public void Update(IncomeType incomeType)
        {
            try
            {
                ValidationTool.Validate(new IncomeTypeValidator(), incomeType);
                _incomeTypeDal.Update(incomeType);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Remove(IncomeType incomeType)
        {
            try
            {
                ValidationTool.Validate(new IncomeTypeValidator(), incomeType);
                _incomeTypeDal.Delete(incomeType);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

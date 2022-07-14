using IlimYayma.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IlimYayma.Business.Utilities;
using IlimYayma.Business.ValidationRules.FluentValidation;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.DataAcces.Concrete.EntityFramework;

namespace IlimYayma.Business.Concrete
{
    public class IncomeManager : IIncomeService
    {
        private IIncomeDal _incomeDal;

        public IncomeManager(IIncomeDal incomeDal)
        {
            _incomeDal = incomeDal;
        }

        public List<Income> GetAll()
        {

            try
            {
                return _incomeDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception )
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public void Add(Income income)
        {
            try
            {
                ValidationTool.Validate(new IncomeValidator(), income);
                _incomeDal.Add(income);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public void Update(Income income)
        {
            try
            {
                ValidationTool.Validate(new IncomeValidator(), income);
                _incomeDal.Update(income);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        //public void DenemeList()
        //{
        //    _incomeDal.DenemeList();
        //}
    }
}

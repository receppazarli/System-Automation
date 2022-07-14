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
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public List<Employee> GetAll()
        {
            try
            {
                return _employeeDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public void Add(Employee employee)
        {
            try
            {
                ValidationTool.Validate(new EmployeeValidator(), employee);
                _employeeDal.Add(employee);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public void Update(Employee employee)
        {
            try
            {
                ValidationTool.Validate(new EmployeeValidator(), employee);
                _employeeDal.Update(employee);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        public void Remove(Employee employee)
        {
            try
            {
                ValidationTool.Validate(new EmployeeValidator(), employee);
                _employeeDal.Delete(employee);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }


    }
}

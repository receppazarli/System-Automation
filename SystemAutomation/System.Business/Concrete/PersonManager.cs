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
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public List<Person> GetAll()
        {
            try
            {
                return _personDal.GetAll(x => x.DeleteFlag == false);

            }
            catch (Exception )
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Add(Person person)
        {
            try
            {
                ValidationTool.Validate(new PersonValidator(), person);
                _personDal.Add(person);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public void Update(Person person)
        {
            try
            {
                ValidationTool.Validate(new PersonValidator(), person);
                _personDal.Update(person);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Remove(Person person)
        {
            try
            {
                ValidationTool.Validate(new PersonValidator(), person);
                _personDal.Delete(person);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}

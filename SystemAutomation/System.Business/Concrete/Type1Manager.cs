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
using Exception = System.Exception;

namespace IlimYayma.Business.Concrete
{
    public class Type1Manager : IType1Service
    {
        private IType1Dal _type1Dal;

        public Type1Manager(IType1Dal type1Dal)
        {
            _type1Dal = type1Dal;
        }

        public List<Type1> GetAll()
        {
            try
            {
                return _type1Dal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                //Console.WriteLine(e);
                //throw;
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }
        }

        public void Add(Type1 type1)
        {
            try
            {
                ValidationTool.Validate(new TypeValidator(), type1);
                _type1Dal.Add(type1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Update(Type1 type1)
        {
            try
            {
                ValidationTool.Validate(new TypeValidator(), type1);
                _type1Dal.Update(type1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Remove(Type1 type1)
        {
            try
            {
                ValidationTool.Validate(new TypeValidator(), type1);
                _type1Dal.Delete(type1);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

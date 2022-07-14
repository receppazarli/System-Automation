using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using IlimYayma.Business.Utilities;
using IlimYayma.Business.ValidationRules.FluentValidation;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            try
            {
                return _userDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void GetUserId(int key,TextBox txt1,TextBox txt2)
        {
            try
            {
                var createUser = _userDal.GetAll().FirstOrDefault(x => x.Id == key).CreateUser;
                var createDate = _userDal.GetAll().FirstOrDefault(x => x.Id == key).CreateDate;
                txt1.Text = createUser.ToString();
                txt2.Text = createDate.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Add(User user)
        {
            try
            {
                ValidationTool.Validate(new UserValidator(), user);
                _userDal.Add(user);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Update(User user)
        {
            try
            {
                ValidationTool.Validate(new UserValidator(), user);
                _userDal.Update(user);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

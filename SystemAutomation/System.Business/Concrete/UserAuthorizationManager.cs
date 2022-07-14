using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IlimYayma.Business.Abstract;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.Business.Concrete
{
    public class UserAuthorizationManager : IUserAuthorizationService
    {
        private IUserAuthorizationDal _authorizationDal;

        public UserAuthorizationManager(IUserAuthorizationDal authorizationDal)
        {
            _authorizationDal = authorizationDal;
        }

        public List<UserAuthorization> GetAll()
        {
            try
            {
                return _authorizationDal.GetAll(x => x.AuthorizationId != "0");

            }
            catch (Exception )
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}

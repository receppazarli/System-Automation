using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IlimYayma.Business.Concrete;
using IlimYayma.Business.DependencyResolvers;
using IlimYayma.DataAcces.Concrete.EntityFramework;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_User : DevExpress.XtraEditors.XtraForm
    {
        public Frm_User()
        {
            InitializeComponent();
            _userService = InstanceFactory.GetInstance<IUserService>();
        }


        private IUserService _userService;
        private bool Control(string Name, string Pass)
        {
            var sorgu = _userService.GetAll().Where(p => p.klnc_ad == Name && p.klnc_sifre == Pass);

            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void LoadUser()
        {
            _userService.GetUserId(Frm_Login.UserId,txtCreateUser,txtCreateDate);
            txtId.Text = Frm_Login.UserId.ToString();
        }

        private void btnPasswordOpen_Click(object sender, EventArgs e)
        {

            if (txtPassword.Properties.UseSystemPasswordChar == true)
            {
                txtPassword.Properties.UseSystemPasswordChar = false;
                txtNewPassword.Properties.UseSystemPasswordChar = false;

            }
            else if (txtPassword.Properties.UseSystemPasswordChar == false)
            {
                txtPassword.Properties.UseSystemPasswordChar = true;
                txtNewPassword.Properties.UseSystemPasswordChar = true;

            }
        }

        private void Frm_User_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Frm_Login.UserName;
            LoadUser();
        }

        // En son burda kaldımm şifre güncelleme kısmını yapıcam.
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Şifrenizi güncellemek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                if (Control(txtUserName.Text, txtPassword.Text))
                {
                    _userService.Update(new User
                    {
                        Id = Convert.ToInt32(txtId.Text),
                        klnc_ad = txtUserName.Text,
                        klnc_sifre = txtNewPassword.Text,
                        klnc_yetki = Frm_Login.User_Yetki,
                        CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        CreateDate = Convert.ToDateTime(txtCreateDate.Text),
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now

                    });
                    MessageBox.Show("Şifreniz başarılı bir şekilde güncellenmiştir...", "Bilgilendirme",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Şifre Hatalı Lütfen Tekrar Deneyiniz...", "Bilgilendirme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("İşleminiz iptal edilmiştir.", "Bilgilendirme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


           
        }





       
    }
}
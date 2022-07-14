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

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_Login : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Login()
        {
            InitializeComponent();
            _userService = InstanceFactory.GetInstance<IUserService>();
        }

        private IUserService _userService;
        public static int UserId;
        public static string User_Yetki;
        public static string Password;
        public static string UserName;


        void OpenForm2(Form form)
        {
            form.Show();
        }

        private bool Control(string Name, string Pass, int type)
        {
            var sorgu = _userService.GetAll().Where(p => p.klnc_ad == Name && p.klnc_sifre == Pass && p.klnc_yetki == "0");

            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool Control1(string Name, string Pass, int type)
        {
            var sorgu = _userService.GetAll().Where(p => p.klnc_ad == Name && p.klnc_sifre == Pass && p.klnc_yetki == "1");

            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool Control2(string Name, string Pass, int type)
        {
            var sorgu = _userService.GetAll().Where(p => p.klnc_ad == Name && p.klnc_sifre == Pass && p.klnc_yetki == "2");

            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool Control3(string Name, string Pass, int type)
        {
            var sorgu = _userService.GetAll().Where(p => p.klnc_ad == Name && p.klnc_sifre == Pass && p.klnc_yetki == "3");

            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            LoadUserName();


        }

        private void LoadUserName()
        {
            lkuUser.Properties.DataSource = _userService.GetAll();
            lkuUser.Properties.DisplayMember = "klnc_ad";
            lkuUser.Properties.ValueMember = "Id";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            if (Control1(lkuUser.Text, txtPassword.Text, 1))
            {
                User_Yetki = "1";
                Password = txtPassword.Text;
                UserName = lkuUser.Text;
                UserId = Convert.ToInt32(lkuUser.EditValue);
                OpenForm2(new Frm_MainModule());
                this.Hide();
            }
            else if (Control(lkuUser.Text, txtPassword.Text, 0))
            {
                User_Yetki = "0";
                Password = txtPassword.Text;
                UserName = lkuUser.Text;
                UserId = Convert.ToInt32(lkuUser.EditValue);
                OpenForm2(new Frm_MainModule());
                this.Hide();
            }
            else if (Control2(lkuUser.Text, txtPassword.Text, 2))
            {
                User_Yetki = "2";
                Password = txtPassword.Text;
                UserName = lkuUser.Text;
                UserId = Convert.ToInt32(lkuUser.EditValue);
                OpenForm2(new Frm_MainModule());
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre Hatalı Lütfen Tekrar Deneyiniz...", "Bilgilendirme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }

        private void lkuUser_EditValueChanged(object sender, EventArgs e)
        {
            // UserId = Convert.ToInt32(lkuUser.EditValue);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult Confirmation = MessageBox.Show("Kapatmak İstediğinize Emin Misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Confirmation == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
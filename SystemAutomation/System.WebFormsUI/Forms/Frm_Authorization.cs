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
using IlimYayma.Business.Abstract;
using IlimYayma.Business.Concrete;
using IlimYayma.Business.DependencyResolvers;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.DataAcces.Concrete.EntityFramework;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_Authorization : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Authorization()
        {
            InitializeComponent();
            _userService = InstanceFactory.GetInstance<IUserService>();
            _userAuthorizationService = InstanceFactory.GetInstance<IUserAuthorizationService>();
        }

        private readonly IUserService _userService;
        private IUserAuthorizationService _userAuthorizationService;
        private CommonMethods _methods = new CommonMethods();


        private void Frm_Authorization_Load(object sender, EventArgs e)
        {
            LoadUsers();
            Clean();
            LoadUserAuthorization();
            _methods.PanelControl(rpMenu);
        }

        private void LoadUserAuthorization()
        {
            lkuUserAuthorization.Properties.DataSource = _userAuthorizationService.GetAll();
            lkuUserAuthorization.Properties.DisplayMember = "UserAuthorizationName";
            lkuUserAuthorization.Properties.ValueMember = "AuthorizationId";
        }

        private void LoadUsers()
        {

            //grcAuthorization.DataSource = _userService.GetAll();

            using (SystemContext context = new SystemContext())
            {
                var entity = from u in context.Users
                             join ua in context.UserAuthorizations
                                 on u.klnc_yetki equals ua.AuthorizationId
                             select new
                             {

                                 Id = u.Id,
                                 CreateUser = u.CreateUser,
                                 CreateDate = u.CreateDate,
                                 LastUpUser = u.LastUpUser,
                                 LastUpDate = u.LastUpDate,
                                 klnc_ad = u.klnc_ad,
                                 klnc_yetki = ua.UserAuthorizationName,
                                 DeleteFlag = u.DeleteFlag,
                                 klnc_sifre = u.klnc_sifre,


                             };

                grcAuthorization.DataSource = entity.ToList().Where(x => x.DeleteFlag == false && x.klnc_yetki != "Admin");
            }
        }

        void Clean()
        {
            lkuUserAuthorization.EditValue = null;
            txtUserName.Text = "";
            txtId.Text = "";
        }

        
        private void LoadClick()
        {
            if (grwAuthorization.FocusedRowHandle >= 0)
            {
                txtUserName.Text = grwAuthorization.GetFocusedRowCellValue("klnc_ad").ToString();
                lkuUserAuthorization.Text = grwAuthorization.GetFocusedRowCellValue("klnc_yetki").ToString();
                txtId.Text = grwAuthorization.GetFocusedRowCellValue("Id").ToString();
            }
     
        }


        private void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri kaydetmek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    _userService.Add(new User
                    {
                        klnc_ad = txtUserName.Text,
                        klnc_yetki = Convert.ToInt32(lkuUserAuthorization.EditValue).ToString(),
                        klnc_sifre = "1",
                        CreateUser = Convert.ToInt32(Frm_Login.UserId),
                        CreateDate = DateTime.Now,
                        LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadUsers();
                    Clean();
                    //MessageBox.Show("Bilgileriniz başarılı bir şekilde sisteme kaydedilmiştir ", "Bilgilendirme",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşleminiz iptal edilmiştir", "Bilgilendirme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else if (txtId.Text != "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri güncellemek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    _userService.Update(new User
                    {
                        Id = Convert.ToInt32(grwAuthorization.GetRowCellValue(grwAuthorization.FocusedRowHandle, "Id")),
                        klnc_ad = txtUserName.Text,
                        klnc_yetki = Convert.ToInt32(lkuUserAuthorization.EditValue).ToString(),
                        klnc_sifre = grwAuthorization.GetFocusedRowCellValue("klnc_sifre").ToString(),
                        //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        CreateUser = Convert.ToInt32(grwAuthorization.GetFocusedRowCellValue("CreateUser")),
                        CreateDate = Convert.ToDateTime(grwAuthorization.GetFocusedRowCellValue("CreateDate")),
                        LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadUsers();
                    Clean();
                    //MessageBox.Show("Bilgileriniz başarılı bir şekilde  güncellenmiştir ", "Bilgilendirme",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşleminiz iptal edilmiştir", "Bilgilendirme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        

        private void Remove()
        {
            DialogResult Confirmation = MessageBox.Show("Bilgilerinizi silmek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                _userService.Update(new User
                {
                    Id = Convert.ToInt32(grwAuthorization.GetRowCellValue(grwAuthorization.FocusedRowHandle, "Id")),
                    klnc_ad = txtUserName.Text,
                    klnc_yetki = Convert.ToInt32(lkuUserAuthorization.EditValue).ToString(),
                    klnc_sifre = grwAuthorization.GetFocusedRowCellValue("klnc_sifre").ToString(),
                    CreateUser = Convert.ToInt32(grwAuthorization.GetFocusedRowCellValue("CreateUser")),
                    CreateDate = Convert.ToDateTime(grwAuthorization.GetFocusedRowCellValue("CreateDate")),
                    LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                    LastUpDate = DateTime.Now,
                    DeleteFlag = true
                });
                LoadUsers();
                Clean();
                //MessageBox.Show("Bilgileriniz başarılı bir şekilde silinmiştir. ", "Bilgilendirme", MessageBoxButtons.OK,
                //    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("İşleminiz iptal edilmiştir.", "Bilgilendirme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save(); 
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Remove();
        }

        private void btnClean_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Confirmation = MessageBox.Show("Yeni kayıt eklemek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                Clean();
            }
            else
            {
                MessageBox.Show("İşleminiz iptal edilmiştir", "Bilgilendirme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void grcAuthorization_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void btnExcelAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _methods.ExcelAktar(grwAuthorization);
        }

        private void grwAuthorization_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwAuthorization.Focus();
                popupMenu1.ShowPopup(position);
            }
        }
    }
}
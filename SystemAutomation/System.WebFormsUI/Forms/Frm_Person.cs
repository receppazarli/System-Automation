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
using DevExpress.XtraLayout.Utils;
using IlimYayma.Business.Concrete;
using IlimYayma.Business.DependencyResolvers;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_Person : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Person()
        {
            InitializeComponent();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _districtService = InstanceFactory.GetInstance<IDistrictService>();
            _personService = InstanceFactory.GetInstance<IPersonService>();
        }

        private ICityService _cityService;
        private IDistrictService _districtService;
        private IPersonService _personService;

        private CommonMethods _methods = new CommonMethods();

        private void Frm_Person_Load(object sender, EventArgs e)
        {
            LoadPerson();

            Clean();

            LoadCity();

            _methods.PanelControl(rpMenu);

        }

        //private void PanelControl()
        //{
        //    if (Frm_Login.User_Yetki == "0" || Frm_Login.User_Yetki == "1")
        //    {
        //        //btnSave.Visible = true;
        //        //btnClean.Visible = true;
        //        //btnRemove.Visible = true;
        //        //panelControl1.Visible = true;
        //        layoutPanel.Visibility = LayoutVisibility.Always;
        //    }
        //    else if (Frm_Login.User_Yetki == "2")
        //    {
        //        //btnSave.Visible = false;
        //        //btnClean.Visible = false;
        //        //btnRemove.Visible = false;
        //        //panelControl1.Visible = false;
        //        layoutPanel.Visibility = LayoutVisibility.Never;

        //    }

        //}
        private void LoadPerson()
        {
            grcPerson.DataSource = _personService.GetAll();
        }

        // Şehire göre  İlçe listeleme
        private void LoadDistrict()
        {
            lkuDistrict.Properties.DataSource = _districtService.GetAll(Convert.ToInt32(lkuCity.EditValue)).ToList();
            lkuDistrict.Properties.DisplayMember = "DistrictName";
            lkuDistrict.Properties.ValueMember = "Id";
        }

        //Şehirleri lookupedeite listeleme 
        private void LoadCity()
        {
            lkuCity.Properties.DataSource = _cityService.GetAll();
            lkuCity.Properties.DisplayMember = "CityName";
            lkuCity.Properties.ValueMember = "Id";
        }

        private void lkuCity_EditValueChanged(object sender, EventArgs e)
        {
            LoadDistrict();
        }

        void Clean()
        {
            txtNationalityId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEMail.Text = "";
            txtBank.Text = "";
            txtIban.Text = "";
            lkuCity.EditValue = null;
            lkuDistrict.EditValue = null;
            txtAddress.Text = "";
            txtId.Text = "";
        }



        private void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri kaydetmek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    _personService.Add(new Person
                    {
                        NationalityId = txtNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = txtPhone.Text,
                        Email = txtEMail.Text,
                        Bank = txtBank.Text,
                        Iban = txtIban.Text,
                        City = lkuCity.Text,
                        District = lkuDistrict.Text,
                        Address = txtAddress.Text,
                        CreateUser = Frm_Login.UserId,
                        CreateDate = DateTime.Now,
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now
                    });
                    LoadPerson();
                    Clean();
                    //MessageBox.Show("Bilgileriniz başarılı bir şekilde sisteme kaydedilmiştir.", "Bilgilendirme",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşleminiz iptal edilmiştir.", "Bilgilendirme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else if (txtId.Text != "")
            {
                DialogResult confirmation = MessageBox.Show("Bilgileri güncellemek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    _personService.Update(new Person
                    {
                        Id = Convert.ToInt32(grwPerson.GetRowCellValue(grwPerson.FocusedRowHandle, "Id")),
                        NationalityId = txtNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = txtPhone.Text,
                        Email = txtEMail.Text,
                        Bank = txtBank.Text,
                        Iban = txtIban.Text,
                        City = lkuCity.Text,
                        District = lkuDistrict.Text,
                        Address = txtAddress.Text,
                        //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        CreateUser = Convert.ToInt32(grwPerson.GetFocusedRowCellValue("CreateUser")),
                        CreateDate = Convert.ToDateTime(grwPerson.GetFocusedRowCellValue("CreateDate")),
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now
                    });
                    LoadPerson();
                    Clean();

                    //MessageBox.Show("Bilgileriniz başarılı bir şekilde  güncellenmiştir.", "Bilgilendirme",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşleminiz iptal edilmiştir.", "Bilgilendirme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }



        private void LoadClick()
        {
            if (grwPerson.FocusedRowHandle >= 0)
            {
                txtNationalityId.Text = grwPerson.GetFocusedRowCellValue("NationalityId").ToString();
                txtFirstName.Text = grwPerson.GetFocusedRowCellValue("FirstName").ToString();
                txtLastName.Text = grwPerson.GetFocusedRowCellValue("LastName").ToString();
                txtPhone.Text = grwPerson.GetFocusedRowCellValue("Phone").ToString();
                txtEMail.Text = grwPerson.GetFocusedRowCellValue("Email").ToString();
                txtBank.Text = grwPerson.GetFocusedRowCellValue("Bank").ToString();
                txtIban.Text = grwPerson.GetFocusedRowCellValue("Iban").ToString();
                lkuCity.Text = grwPerson.GetFocusedRowCellValue("City").ToString();
                lkuDistrict.Text = grwPerson.GetFocusedRowCellValue("District").ToString();
                txtAddress.Text = grwPerson.GetFocusedRowCellValue("Address").ToString();
                txtId.Text = grwPerson.GetFocusedRowCellValue("Id").ToString();
            }
           
        }


        private void Remove()
        {
            DialogResult confirmation = MessageBox.Show("Bilgilerinizi silmek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                _personService.Update(new Person
                {
                    Id = Convert.ToInt32(grwPerson.GetRowCellValue(grwPerson.FocusedRowHandle, "Id")),
                    NationalityId = txtNationalityId.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Phone = txtPhone.Text,
                    Email = txtEMail.Text,
                    Bank = txtBank.Text,
                    Iban = txtIban.Text,
                    City = lkuCity.Text,
                    //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                    CreateUser = Convert.ToInt32(grwPerson.GetFocusedRowCellValue("CreateUser")),
                    CreateDate = Convert.ToDateTime(grwPerson.GetFocusedRowCellValue("CreateDate")),
                    LastUpDate = DateTime.Now,
                    LastUpUser = Frm_Login.UserId,
                    District = lkuDistrict.Text,
                    Address = txtAddress.Text,
                    DeleteFlag = true
                });
                LoadPerson();
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

        private void grcPerson_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void btnExcelAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _methods.ExcelAktar(grwPerson);
        }

        private void grwPerson_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwPerson.Focus();
                popupMenu1.ShowPopup(position);
            }
        }
    }
}
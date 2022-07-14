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
    public partial class Frm_Employee : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Employee()
        {
            InitializeComponent();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _districtService = InstanceFactory.GetInstance<IDistrictService>();
            _employeeService = InstanceFactory.GetInstance<IEmployeeService>();
        }

        private ICityService _cityService;
        private IDistrictService _districtService;
        private IEmployeeService _employeeService;

        private CommonMethods _methods = new CommonMethods();


        private void Frm_Employee_Load(object sender, EventArgs e)
        {
            LoadCity();

            LoadEmployee();

            Clean();

           _methods.PanelControl(rpMenu);


        }

 

        private void LoadEmployee()
        {
            grcEmployee.DataSource = _employeeService.GetAll();
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

        // Şehir seçildiği zaman o şehirin ilçelerini getiren method
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
            lkuCity.EditValue = null;
            lkuDistrict.EditValue = null;
            txtAddress.Text = "";
            txtId.Text = "";
            txtCreateUser.Text = null;
        }


        private void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri kaydetmek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    _employeeService.Add(new Employee
                    {
                        NationalityId = txtNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = txtPhone.Text,
                        Email = txtEMail.Text,
                        City = lkuCity.Text,
                        District = lkuDistrict.Text,
                        Address = txtAddress.Text,
                        CreateUser = Convert.ToInt32(Frm_Login.UserId),
                        CreateDate = DateTime.Now,
                        LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadEmployee();
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
                DialogResult Confirmation = MessageBox.Show("Bilgileri güncellemek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    _employeeService.Update(new Employee()
                    {
                        Id = Convert.ToInt32(grwEmployee.GetRowCellValue(grwEmployee.FocusedRowHandle, "Id")),
                        NationalityId = txtNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = txtPhone.Text,
                        Email = txtEMail.Text,
                        City = lkuCity.Text,
                        District = lkuDistrict.Text,
                        Address = txtAddress.Text,
                        //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        CreateUser = Convert.ToInt32(grwEmployee.GetFocusedRowCellValue("CreateUser")),
                        CreateDate = Convert.ToDateTime(grwEmployee.GetFocusedRowCellValue("CreateDate")),
                        LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadEmployee();
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
            if (grwEmployee.FocusedRowHandle >= 0)
            {
                txtNationalityId.Text = grwEmployee.GetFocusedRowCellValue("NationalityId").ToString();
                txtFirstName.Text = grwEmployee.GetFocusedRowCellValue("FirstName").ToString();
                txtLastName.Text = grwEmployee.GetFocusedRowCellValue("LastName").ToString();
                txtPhone.Text = grwEmployee.GetFocusedRowCellValue("Phone").ToString();
                txtEMail.Text = grwEmployee.GetFocusedRowCellValue("Email").ToString();
                lkuCity.Text = grwEmployee.GetFocusedRowCellValue("City").ToString();
                lkuDistrict.Text = grwEmployee.GetFocusedRowCellValue("District").ToString();
                txtAddress.Text = grwEmployee.GetFocusedRowCellValue("Address").ToString();
                txtId.Text = grwEmployee.GetFocusedRowCellValue("Id").ToString();
                txtCreateUser.Text = grwEmployee.GetFocusedRowCellValue("CreateUser").ToString();
            }
            
        }


        private void Remove()
        {
            DialogResult Confirmation = MessageBox.Show("Bilgilerinizi silmek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                _employeeService.Update(new Employee()
                {
                    Id = Convert.ToInt32(grwEmployee.GetRowCellValue(grwEmployee.FocusedRowHandle, "Id")),
                    NationalityId = txtNationalityId.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Phone = txtPhone.Text,
                    Email = txtEMail.Text,
                    City = lkuCity.Text,
                    District = lkuDistrict.Text,
                    Address = txtAddress.Text,
                    //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                    CreateUser = Convert.ToInt32(grwEmployee.GetFocusedRowCellValue("CreateUser")),
                    CreateDate = Convert.ToDateTime(grwEmployee.GetFocusedRowCellValue("CreateDate")),
                    LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                    LastUpDate = DateTime.Now,
                    DeleteFlag = true
                });
                LoadEmployee();
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

        private void grcEmployee_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void btnExcelAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _methods.ExcelAktar(grwEmployee);
        }

        private void grwEmployee_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwEmployee.Focus();
                popupMenu1.ShowPopup(position);
            }
        }
    }
}
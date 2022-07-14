using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Svg;
using DevExpress.XtraLayout.Utils;
using IlimYayma.Business.Concrete;
using IlimYayma.Business.DependencyResolvers;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_Type : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Type()
        {
            InitializeComponent();
            _type1Service = InstanceFactory.GetInstance<IType1Service>();
        }

        private IType1Service _type1Service;
        private CommonMethods _methods = new CommonMethods();

        private void Frm_Type_Load(object sender, EventArgs e)
        {
            LoadTypes();
            Clean();
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

        private void LoadTypes()
        {
            grcTypes.DataSource = _type1Service.GetAll();
        }

        void Clean()
        {
            txtTypeName.Text = "";
            txtUnit.Text = "";
            txtId.Text = "";
            txtCreateUser.Text = "";
        }



        private void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri kaydetmek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    _type1Service.Add(new Type1
                    {
                        TypeName = txtTypeName.Text,
                        Unit = txtUnit.Text,
                        CreateUser = Frm_Login.UserId,
                        CreateDate = DateTime.Now,
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadTypes();
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
                    _type1Service.Update(new Type1
                    {
                        Id = Convert.ToInt32(grwTypes.GetRowCellValue(grwTypes.FocusedRowHandle, "Id")),
                        TypeName = txtTypeName.Text,
                        Unit = txtUnit.Text,
                        //TODO bütün alanlar için eklenecek
                        CreateUser = Convert.ToInt32(grwTypes.GetFocusedRowCellValue("CreateUser")),
                        CreateDate = Convert.ToDateTime(grwTypes.GetFocusedRowCellValue("CreateDate")),
                        //  CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadTypes();
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
            if (grwTypes.FocusedRowHandle >= 0)
            {
                txtTypeName.Text = grwTypes.GetFocusedRowCellValue("TypeName").ToString();
                txtUnit.Text = grwTypes.GetFocusedRowCellValue("Unit").ToString();
                txtId.Text = grwTypes.GetFocusedRowCellValue("Id").ToString();
                txtCreateUser.Text = grwTypes.GetFocusedRowCellValue("CreateUser").ToString();
            }
            
        }


        private void Remove()
        {
            DialogResult Confirmation = MessageBox.Show("Bilgilerinizi silmek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                _type1Service.Update(new Type1
                {
                    Id = Convert.ToInt32(grwTypes.GetRowCellValue(grwTypes.FocusedRowHandle, "Id")),
                    TypeName = txtTypeName.Text,
                    Unit = txtUnit.Text,
                    //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                    CreateUser = Convert.ToInt32(grwTypes.GetFocusedRowCellValue("CreateUser")),
                    CreateDate = Convert.ToDateTime(grwTypes.GetFocusedRowCellValue("CreateDate")),
                    LastUpUser = Frm_Login.UserId,
                    LastUpDate = DateTime.Now,
                    DeleteFlag = true
                });
                LoadTypes();
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

        

        private void grwTypes_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void btnExcelAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _methods.ExcelAktar(grwTypes);
        }

        private void grwTypes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwTypes.Focus();
                popupMenu1.ShowPopup(position);
            }
        }
    }
}
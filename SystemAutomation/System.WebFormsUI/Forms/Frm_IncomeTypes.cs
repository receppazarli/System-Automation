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
    public partial class Frm_IncomeTypes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_IncomeTypes()
        {
            InitializeComponent();
            _incomeTypeService = InstanceFactory.GetInstance<IIncomeTypeService>();
        }

        private IIncomeTypeService _incomeTypeService;

        private CommonMethods _methods = new CommonMethods();


        private void Frm_IncomeTypes_Load(object sender, EventArgs e)
        {
            LoadIncomeTypes();
            Clean();
            _methods.PanelControl(rpMenu);            
        }

        void Clean()
        {
            txtIncomeTypeName.Text = "";
            txtCreateUser.Text = "";
            txtId.Text = "";
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

        private void LoadIncomeTypes()
        {
            grcIncomeTypes.DataSource = _incomeTypeService.GetAll();
        }



        private void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri kaydetmek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    _incomeTypeService.Add(new IncomeType
                    {
                        IncomeName = txtIncomeTypeName.Text,
                        CreateUser = Frm_Login.UserId,
                        CreateDate = DateTime.Now,
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadIncomeTypes();
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
                    _incomeTypeService.Update(new IncomeType
                    {
                        Id = Convert.ToInt32(grwIncomeTypes.GetRowCellValue(grwIncomeTypes.FocusedRowHandle, "Id")),
                        IncomeName = txtIncomeTypeName.Text,
                        //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        CreateUser = Convert.ToInt32(grwIncomeTypes.GetFocusedRowCellValue("CreateUser")),
                        CreateDate = Convert.ToDateTime(grwIncomeTypes.GetFocusedRowCellValue("CreateDate")),
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadIncomeTypes();
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
            if (grwIncomeTypes.FocusedRowHandle >= 0)
            {
                txtIncomeTypeName.Text = grwIncomeTypes.GetFocusedRowCellValue("IncomeName").ToString();
                txtId.Text = grwIncomeTypes.GetFocusedRowCellValue("Id").ToString();
                txtCreateUser.Text = grwIncomeTypes.GetFocusedRowCellValue("CreateUser").ToString();
            }
            
        }


        private void Remove()
        {
            DialogResult Confirmation = MessageBox.Show("Bilgilerinizi silmek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                _incomeTypeService.Update(new IncomeType
                {
                    Id = Convert.ToInt32(grwIncomeTypes.GetRowCellValue(grwIncomeTypes.FocusedRowHandle, "Id")),
                    IncomeName = txtIncomeTypeName.Text,
                    //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                    CreateUser = Convert.ToInt32(grwIncomeTypes.GetFocusedRowCellValue("CreateUser")),
                    CreateDate = Convert.ToDateTime(grwIncomeTypes.GetFocusedRowCellValue("CreateDate")),
                    LastUpUser = Frm_Login.UserId,
                    LastUpDate = DateTime.Now,
                    DeleteFlag = true
                });
                LoadIncomeTypes();
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

        private void grwIncomeTypes_Click(object sender, EventArgs e)
        {
           LoadClick();

        }

        private void btnExcelAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _methods.ExcelAktar(grwIncomeTypes);
        }

        private void grwIncomeTypes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwIncomeTypes.Focus();
                popupMenu1.ShowPopup(position);
            }
        }
    }
}
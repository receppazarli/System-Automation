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
using IlimYayma.Business.Abstract;
using IlimYayma.Business.DependencyResolvers;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_ExpenseType : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_ExpenseType()
        {
            InitializeComponent();
            _expenseTypeService = InstanceFactory.GetInstance<IExpenseTypeService>();

        }
        private IExpenseTypeService _expenseTypeService;
        private CommonMethods _methods = new CommonMethods();


        private void Frm_ExpenseType_Load(object sender, EventArgs e)
        {
            _methods.PanelControl(rpMenu);

            LoadExpenseTypes();

            Clean();
        }

        private void LoadExpenseTypes()
        {
            grcExpenseTypes.DataSource = _expenseTypeService.GetAll();
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

        void Clean()
        {
            txtExpenseTypeName.Text = "";
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
                    _expenseTypeService.Add(new ExpenseType
                    {
                        ExpenseTypeName = txtExpenseTypeName.Text,
                        CreateUser = Frm_Login.UserId,
                        CreateDate = DateTime.Now,
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadExpenseTypes();
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
                    _expenseTypeService.Update(new ExpenseType
                    {
                        Id = Convert.ToInt32(grwExpenseTypes.GetRowCellValue(grwExpenseTypes.FocusedRowHandle, "Id")),
                        ExpenseTypeName = txtExpenseTypeName.Text,
                        //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        CreateUser = Convert.ToInt32(grwExpenseTypes.GetFocusedRowCellValue("CreateUser")),
                        CreateDate = Convert.ToDateTime(grwExpenseTypes.GetFocusedRowCellValue("CreateDate")),
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now,
                        DeleteFlag = false
                    });
                    LoadExpenseTypes();
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



        private void Remove()
        {
            DialogResult Confirmation = MessageBox.Show("Bilgilerinizi silmek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                _expenseTypeService.Update(new ExpenseType
                {
                    Id = Convert.ToInt32(grwExpenseTypes.GetRowCellValue(grwExpenseTypes.FocusedRowHandle, "Id")),
                    ExpenseTypeName = txtExpenseTypeName.Text,
                    CreateUser = Convert.ToInt32(grwExpenseTypes.GetFocusedRowCellValue("CreateUser")),
                    CreateDate = Convert.ToDateTime(grwExpenseTypes.GetFocusedRowCellValue("CreateDate")),
                    LastUpUser = Frm_Login.UserId,
                    LastUpDate = DateTime.Now,
                    DeleteFlag = true
                });
                LoadExpenseTypes();
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





        private void LoadClick()
        {
            if (grwExpenseTypes.FocusedRowHandle >= 0)
            {
                txtExpenseTypeName.Text = grwExpenseTypes.GetFocusedRowCellValue("ExpenseTypeName").ToString();
                txtId.Text = grwExpenseTypes.GetFocusedRowCellValue("Id").ToString();
                txtCreateUser.Text = grwExpenseTypes.GetFocusedRowCellValue("CreateUser").ToString();
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

        private void grcExpenseTypes_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void btnExcelAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _methods.ExcelAktar(grwExpenseTypes);
        }

        private void grwExpenseTypes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwExpenseTypes.Focus();
                popupMenu1.ShowPopup(position);
            }
        }
    }
}
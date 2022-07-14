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
using IlimYayma.Business.Concrete;
using IlimYayma.Business.DependencyResolvers;
using IlimYayma.DataAcces.Concrete.EntityFramework;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_Expenses : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Expenses()
        {
            InitializeComponent();

            _expenseTypeService = InstanceFactory.GetInstance<IExpenseTypeService>();
            _expenseService = InstanceFactory.GetInstance<IExpenseService>();
            _personService = InstanceFactory.GetInstance<IPersonService>();
            _employeeService = InstanceFactory.GetInstance<IEmployeeService>();
            _type1Service = InstanceFactory.GetInstance<IType1Service>();
        }

        private IExpenseService _expenseService;
        private IExpenseTypeService _expenseTypeService;
        private IPersonService _personService;
        private IEmployeeService _employeeService;
        private IType1Service _type1Service;

        private CommonMethods _methods = new CommonMethods();




        private void Frm_Expenses_Load(object sender, EventArgs e)
        {
            LoadExpenseTypes();
            LoadExpenses();
            Clean();
            LoadEmployees();
            LoadPerson();
            LoadTypes();
            _methods.PanelControl(rpMenu);
        }
        private void LoadPerson()
        {
            lkuWhomPerson.Properties.DataSource = _personService.GetAll();
            lkuWhomPerson.Properties.DisplayMember = "FirstName";
            lkuWhomPerson.Properties.ValueMember = "Id";
        }

        private void LoadEmployees()
        {
            lkuWhoEmployee.Properties.DataSource = _employeeService.GetAll();
            lkuWhoEmployee.Properties.DisplayMember = "FirstName";
            lkuWhoEmployee.Properties.ValueMember = "Id";
        }

        private void LoadTypes()
        {
            lkuType.Properties.DataSource = _type1Service.GetAll();
            lkuType.Properties.DisplayMember = "TypeName";
            lkuType.Properties.ValueMember = "Id";
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

        void LoadExpenses()
        {
            try
            {
                using (SystemContext context = new SystemContext())
                {

                    var entity = from e in context.Expenses
                                 join et in context.ExpenseTypes on e.ExpenseTypeId equals et.Id
                                 join em in context.Employees on e.WhoEmployee equals em.Id
                                 join p in context.People on e.WhomPerson equals p.Id
                                 join t in context.Type1 on e.TypeId equals t.Id
                                 select new
                                 {
                                     Id = e.Id,
                                     CreateUser = e.CreateUser,
                                     CreateDate = e.CreateDate,
                                     LastUpUser = e.LastUpUser,
                                     LastUpDate = e.LastUpDate,
                                     Explanation = e.Explanation,
                                     DeleteFlag = e.DeleteFlag,
                                     ExpenseTypeId = et.ExpenseTypeName,
                                     WhomPerson = p.FirstName,
                                     WhoEmployee = em.FirstName,
                                     TypeId = t.TypeName,
                                     Quantity = e.Quantity,
                                     ExpenseIssueDate = e.ExpenseIssueDate
                                 };

                    grcExpense.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgiler yüklenirken hata oluştu. Lütfen tekrar deneyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        void Clean()
        {
            lkuExpenseType.EditValue = 0;
            lkuWhoEmployee.EditValue = 0;
            lkuWhomPerson.EditValue = 0;
            lkuType.EditValue = 0;
            txtQuantity.Text = "";
            memoExplanation.Text = "";
            dteExpenseIssueDate.Text = "";
            txtId.Text = "";
            txtCreateUser.Text = "";
        }
        private void LoadExpenseTypes()
        {
            lkuExpenseType.Properties.DataSource = _expenseTypeService.GetAll();
            lkuExpenseType.Properties.DisplayMember = "ExpenseTypeName";
            lkuExpenseType.Properties.ValueMember = "Id";
        }



        private void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri kaydetmek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    if (txtQuantity.Text != String.Empty)
                    {
                        _expenseService.Add(new Expense
                        {
                            CreateUser = Convert.ToInt32(Frm_Login.UserId),
                            CreateDate = DateTime.Now,
                            LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                            LastUpDate = DateTime.Now,
                            Explanation = memoExplanation.Text,
                            ExpenseTypeId = Convert.ToInt32(lkuExpenseType.EditValue),
                            WhoEmployee = Convert.ToInt32(lkuWhoEmployee.EditValue),
                            WhomPerson = Convert.ToInt32(lkuWhomPerson.EditValue),
                            TypeId = Convert.ToInt32(lkuType.EditValue),
                            Quantity = Convert.ToDouble(txtQuantity.Text),
                            ExpenseIssueDate = dteExpenseIssueDate.DateTime,
                            DeleteFlag = false
                        });
                        LoadExpenses();
                        Clean();
                        //MessageBox.Show("Bilgileriniz başarılı bir şekilde sisteme kaydedilmiştir ", "Bilgilendirme",
                        //    MessageBoxButtons.OK,
                        //    MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Doğrulama Hatası: \n--Miktar Alanı boş olamaz Lütfen kontrol ediniz. ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


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
                    if (txtQuantity.Text != String.Empty)
                    {
                        _expenseService.Update(new Expense
                        {
                            Id = Convert.ToInt32(grwExpense.GetRowCellValue(grwExpense.FocusedRowHandle, "Id")),
                            //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                            CreateUser = Convert.ToInt32(grwExpense.GetFocusedRowCellValue("CreateUser")),
                            CreateDate = Convert.ToDateTime(grwExpense.GetFocusedRowCellValue("CreateDate")),
                            LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                            LastUpDate = DateTime.Now,
                            Explanation = memoExplanation.Text,
                            ExpenseTypeId = Convert.ToInt32(lkuExpenseType.EditValue),
                            WhoEmployee = Convert.ToInt32(lkuWhoEmployee.EditValue),
                            WhomPerson = Convert.ToInt32(lkuWhomPerson.EditValue),
                            TypeId = Convert.ToInt32(lkuType.EditValue),
                            Quantity = Convert.ToDouble(txtQuantity.Text),
                            ExpenseIssueDate = dteExpenseIssueDate.DateTime,
                            DeleteFlag = false
                        });
                        LoadExpenses();
                        Clean();
                        //MessageBox.Show("Bilgileriniz başarılı bir şekilde  güncellenmiştir ", "Bilgilendirme",
                        //    MessageBoxButtons.OK,
                        //    MessageBoxIcon.Information);   
                    }
                    else
                    {
                        MessageBox.Show("Doğrulama Hatası: \n--Miktar Alanı boş olamaz Lütfen kontrol ediniz. ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("İşleminiz iptal edilmiştir", "Bilgilendirme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }


        private void grwExpense_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadClick();
        }

        private void LoadClick()
        {
            if (grwExpense.FocusedRowHandle >= 0)
            {
                lkuExpenseType.Text = grwExpense.GetFocusedRowCellValue("ExpenseTypeId").ToString();
                lkuWhomPerson.Text = grwExpense.GetFocusedRowCellValue("WhomPerson").ToString();
                lkuWhoEmployee.Text = grwExpense.GetFocusedRowCellValue("WhoEmployee").ToString();
                lkuType.Text = grwExpense.GetFocusedRowCellValue("TypeId").ToString();
                txtQuantity.Text = grwExpense.GetFocusedRowCellValue("Quantity").ToString();
                memoExplanation.Text = grwExpense.GetFocusedRowCellValue("Explanation").ToString();
                dteExpenseIssueDate.Text = grwExpense.GetFocusedRowCellValue("ExpenseIssueDate").ToString();
                txtCreateUser.Text = grwExpense.GetFocusedRowCellValue("CreateUser").ToString();
                txtId.Text = grwExpense.GetFocusedRowCellValue("Id").ToString();
            }

        }


        private void Remove()
        {
            DialogResult Confirmation = MessageBox.Show("Bilgilerinizi silmek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                if (txtQuantity.Text != String.Empty)
                {
                    _expenseService.Update(new Expense
                    {
                        Id = Convert.ToInt32(grwExpense.GetRowCellValue(grwExpense.FocusedRowHandle, "Id")),
                        //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        CreateUser = Convert.ToInt32(grwExpense.GetFocusedRowCellValue("CreateUser")),
                        CreateDate = Convert.ToDateTime(grwExpense.GetFocusedRowCellValue("CreateDate")),
                        LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                        LastUpDate = DateTime.Now,
                        Explanation = memoExplanation.Text,
                        ExpenseTypeId = Convert.ToInt32(lkuExpenseType.EditValue),
                        WhoEmployee = Convert.ToInt32(lkuWhoEmployee.EditValue),
                        WhomPerson = Convert.ToInt32(lkuWhomPerson.EditValue),
                        TypeId = Convert.ToInt32(lkuType.EditValue),
                        Quantity = Convert.ToDouble(txtQuantity.Text),
                        ExpenseIssueDate = dteExpenseIssueDate.DateTime,
                        DeleteFlag = true
                    });
                    LoadExpenses();
                    Clean();
                    //MessageBox.Show("Bilgileriniz başarılı bir şekilde silinmiştir. ", "Bilgilendirme", MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Doğrulama Hatası: \n--Miktar Alanı boş olamaz Lütfen kontrol ediniz. ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("İşleminiz iptal edilmiştir.", "Bilgilendirme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private Frm_ExpenseType frmExpenseType = new Frm_ExpenseType();
        private void btnExpenseType_Click(object sender, EventArgs e)
        {
            frmExpenseType = new Frm_ExpenseType();
            frmExpenseType.ShowDialog();
            LoadExpenseTypes();
        }

        private Frm_Person frmPerson = new Frm_Person();
        private void btnWhomPerson_Click(object sender, EventArgs e)
        {
            frmPerson = new Frm_Person();
            frmPerson.ShowDialog();
            LoadPerson();
        }

        private Frm_Employee frmEmployee = new Frm_Employee();
        private void btnWhoEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee = new Frm_Employee();
            frmEmployee.ShowDialog();
            LoadEmployees();
        }

        private Frm_Type frmType = new Frm_Type();
        private void btnType_Click(object sender, EventArgs e)
        {
            frmType = new Frm_Type();
            frmType.ShowDialog();
            LoadTypes();
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


        private void btnExcelAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _methods.ExcelAktar(grwExpense);
        }

        private void grwExpense_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwExpense.Focus();
                popupMenu1.ShowPopup(position);
            }
        }
    }
}
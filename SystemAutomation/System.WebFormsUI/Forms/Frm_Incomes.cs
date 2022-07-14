using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using IlimYayma.Business.Concrete;
using IlimYayma.Business.DependencyResolvers;
using IlimYayma.DataAcces.Concrete.EntityFramework;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_Incomes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Incomes()
        {
            InitializeComponent();
            _incomeService = InstanceFactory.GetInstance<IIncomeService>();
            _incomeTypeService = InstanceFactory.GetInstance<IIncomeTypeService>();
            _personService = InstanceFactory.GetInstance<IPersonService>();
            _employeeService = InstanceFactory.GetInstance<IEmployeeService>();
            _type1Service = InstanceFactory.GetInstance<IType1Service>();

        }

        private IIncomeService _incomeService;
        private IIncomeTypeService _incomeTypeService;
        private IPersonService _personService;
        private IEmployeeService _employeeService;
        private IType1Service _type1Service;


        private CommonMethods _methods = new CommonMethods();



        private void Frm_Incomes_Load(object sender, EventArgs e)
        {
            LoadIncomes();

            //grcIncomes.DataSource = _incomeService.GetAll();

            LoadIncomeTypes();

            LoadPerson();

            LoadEmployees();

            LoadTypes();

            _methods.PanelControl(rpMenu);

            Clean();

            


        }

        //TODO Bütün PanelControl yerlerine Uygulanacak
        //private void PanelControl(RibbonPage ribbonPage)
        //{
        //    if (Frm_Login.User_Yetki == "0" || Frm_Login.User_Yetki == "1")
        //    {
        //        //btnSave.Visibility = BarItemVisibility.Always;
        //        //btnClean.Visibility = BarItemVisibility.Always;
        //        //btnRemove.Visibility = BarItemVisibility.Always;
        //        //IslemlerMenusu.Visible = true;
        //        //ribbonControl1.Visible = true;
        //        ribbonPage.Visible = true;

        //    }
        //    else if (Frm_Login.User_Yetki == "2")
        //    {
        //        //btnSave.Visibility = BarItemVisibility.Never;
        //        //btnClean.Visibility = BarItemVisibility.Never;
        //        //btnRemove.Visibility = BarItemVisibility.Never;
        //        //IslemlerMenusu.Visible = false;
        //        //ribbonControl1.Visible = false;
        //        ribbonPage.Visible = false;
        //    }

        //}



        // Türleri lookupedit'e getirme methodu
        private void LoadTypes()
        {
            lkuType1.Properties.DataSource = _type1Service.GetAll();
            lkuType1.Properties.DisplayMember = "TypeName";
            lkuType1.Properties.ValueMember = "Id";
        }



        private void LoadEmployees()
        {
            lkuReceivingPerson.Properties.DataSource = _employeeService.GetAll();
            lkuReceivingPerson.Properties.DisplayMember = "FirstName";
            lkuReceivingPerson.Properties.ValueMember = "Id";

        }

        // Kişileri lookupedeti'e getiren kod
        private void LoadPerson()
        {
            lkuGiverPerson.Properties.DataSource = _personService.GetAll();
            lkuGiverPerson.Properties.DisplayMember = "FirstName";
            lkuGiverPerson.Properties.ValueMember = "Id";
        }

        // Gelir Türlerini lookupedit'e getiren kod 
        private void LoadIncomeTypes()
        {
            lkuIncomeType.Properties.DataSource = _incomeTypeService.GetAll();
            lkuIncomeType.Properties.DisplayMember = "IncomeName";
            lkuIncomeType.Properties.ValueMember = "Id";
        }

        // Gelirleri GridControle yükleme Methodu

        private void LoadIncomes()
        {
            try
            {
                using (SystemContext context = new SystemContext())
                {
                    var entity = from i in context.Incomes
                                 join e in context.Employees on i.ReceivingPersonId equals e.Id
                                 join it in context.IncomeTypes on i.IncomeTypesId equals it.Id
                                 join p in context.People on i.GiverPersonId equals p.Id
                                 join t in context.Type1 on i.SpeciesId equals t.Id
                                 select new
                                 {
                                     Id = i.Id,
                                     CreateUser = i.CreateUser,
                                     CreateDate = i.CreateDate,
                                     LastUpUser = i.LastUpUser,
                                     LastUpDate = i.LastUpDate,
                                     IncomeTypesId = it.IncomeName,
                                     GiverPersonId = p.FirstName,
                                     ReceivingPersonId = e.FirstName,
                                     SpeciesId = t.TypeName,
                                     Quantity = i.Quantity,
                                     DateReceived = i.DateReceived,
                                     Explanation = i.Explanation,
                                     DeleteFlag = i.DeleteFlag
                                 };

                    grcIncomes.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

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
            lkuReceivingPerson.EditValue = 0;
            lkuIncomeType.EditValue = 0;
            lkuGiverPerson.EditValue = 0;
            lkuType1.EditValue = 0;
            memoExplanation.Text = "";
            txtId.Text = "";
            txtCreateUser.Text = "";
            txtQuantity.Text = "";
            dteDateReceived.Text = "";
        }



        private void grwIncomes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }






        private Frm_IncomeTypes _frmIncomeTypes = new Frm_IncomeTypes();
        private void btnIncomeType_Click(object sender, EventArgs e)
        {
            _frmIncomeTypes = new Frm_IncomeTypes();
            _frmIncomeTypes.ShowDialog();
            LoadIncomeTypes();
        }

        private Frm_Person _frmPerson = new Frm_Person();
        private void btnGiverPerson_Click(object sender, EventArgs e)
        {
            _frmPerson = new Frm_Person();
            _frmPerson.ShowDialog();
            LoadPerson();
        }

        // TODO burası şunu ekleme methodu 
        private Frm_Employee _frmEmployee = new Frm_Employee();
        private void btnReceivingPerson_Click(object sender, EventArgs e)
        {
            _frmEmployee = new Frm_Employee();
            _frmEmployee.ShowDialog();
            LoadEmployees();
        }

        private Frm_Type _frmType = new Frm_Type();
        private void btnType_Click(object sender, EventArgs e)
        {
            _frmType = new Frm_Type();
            _frmType.ShowDialog();
            LoadTypes();
        }

        private void btnRemove_ItemClick(object sender, ItemClickEventArgs e)
        {
            Remove();
        }

        private void Remove()
        {
            DialogResult Confirmation = MessageBox.Show("Bilgilerinizi silmek istediğinize Emin misiniz ?",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                if (txtQuantity.Text != String.Empty)
                {
                    _incomeService.Update(new Income
                    {
                        //TODO Bütün Ekleme Silme Ve Güncellemede GetFocusedRowCellValue Kullanılacak
                        Id = Convert.ToInt32(grwIncomes.GetRowCellValue(grwIncomes.FocusedRowHandle, "Id")),
                        //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                        CreateUser = Convert.ToInt32(grwIncomes.GetFocusedRowCellValue("CreateUser")),
                        CreateDate = Convert.ToDateTime(grwIncomes.GetFocusedRowCellValue("CreateDate")),
                        LastUpUser = Frm_Login.UserId,
                        LastUpDate = DateTime.Now,
                        IncomeTypesId = Convert.ToInt32(lkuIncomeType.EditValue),
                        GiverPersonId = Convert.ToInt32(lkuGiverPerson.EditValue),
                        ReceivingPersonId = Convert.ToInt32(lkuReceivingPerson.EditValue),
                        SpeciesId = Convert.ToInt32(lkuType1.EditValue),
                        Quantity = Convert.ToDouble(txtQuantity.Text),
                        DateReceived = dteDateReceived.DateTime,
                        Explanation = memoExplanation.Text,
                        DeleteFlag = true
                    });
                    LoadIncomes();
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

        //TODO Bütün Butonlardaki işlemler metot ile çağrılacak
        void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri kaydetmek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    if (txtQuantity.Text!=String.Empty)
                    {
                        _incomeService.Add(new Income
                        {
                            CreateUser = Convert.ToInt32(Frm_Login.UserId),
                            CreateDate = DateTime.Now,
                            LastUpUser = Convert.ToInt32(Frm_Login.UserId),
                            LastUpDate = DateTime.Now,
                            IncomeTypesId = Convert.ToInt32(lkuIncomeType.EditValue),
                            GiverPersonId = Convert.ToInt32(lkuGiverPerson.EditValue),
                            ReceivingPersonId = Convert.ToInt32(lkuReceivingPerson.EditValue),
                            SpeciesId = Convert.ToInt32(lkuType1.EditValue),
                            Quantity = Convert.ToDouble(txtQuantity.Text),
                            DateReceived = dteDateReceived.DateTime,
                            Explanation = memoExplanation.Text,
                            DeleteFlag = false
                        });
                        LoadIncomes();
                        Clean();
                        //MessageBox.Show("Bilgileriniz başarılı bir şekilde sisteme kaydedilmiştir ", "Bilgilendirme", MessageBoxButtons.OK,
                        //MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Doğrulama Hatası: \n--Miktar Alanı boş olamaz Lütfen kontrol ediniz. ","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("İşleminiz iptal edilmiştir", "Bilgilendirme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else if (txtCreateUser.Text != "")
            {
                DialogResult Confirmation = MessageBox.Show("Bilgileri güncellemek istediğinize Emin misiniz ?",
                    "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    if (txtQuantity.Text != String.Empty)
                    {
                        _incomeService.Update(new Income
                        {
                            Id = Convert.ToInt32(grwIncomes.GetRowCellValue(grwIncomes.FocusedRowHandle, "Id")),
                            //CreateUser = Convert.ToInt32(txtCreateUser.Text),
                            CreateUser = Convert.ToInt32(grwIncomes.GetFocusedRowCellValue("CreateUser")),
                            CreateDate = Convert.ToDateTime(grwIncomes.GetFocusedRowCellValue("CreateDate")),
                            LastUpUser = Frm_Login.UserId,
                            LastUpDate = DateTime.Now,
                            IncomeTypesId = Convert.ToInt32(lkuIncomeType.EditValue),
                            GiverPersonId = Convert.ToInt32(lkuGiverPerson.EditValue),
                            ReceivingPersonId = Convert.ToInt32(lkuReceivingPerson.EditValue),
                            SpeciesId = Convert.ToInt32(lkuType1.EditValue),
                            Quantity = Convert.ToDouble(txtQuantity.Text),
                            DateReceived = dteDateReceived.DateTime,
                            Explanation = memoExplanation.Text,
                            DeleteFlag = false

                        });
                        LoadIncomes();
                        Clean();
                        //MessageBox.Show("Bilgileriniz başarılı bir şekilde  güncellenmiştir ", "Bilgilendirme", MessageBoxButtons.OK,
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
        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private void btnClean_ItemClick(object sender, ItemClickEventArgs e)
        {//TODO Bütün Yeni kayıtlar bu şeilde yapılacak
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


        private void grwIncomes_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO Click lere eklenecek
                LoadClick();
            }
            catch
            {

            }
        }

        private void LoadClick()
        {
            if (grwIncomes.FocusedRowHandle >= 0)
            {
                lkuIncomeType.Text = grwIncomes.GetFocusedRowCellValue("IncomeTypesId").ToString();
                lkuGiverPerson.Text = grwIncomes.GetFocusedRowCellValue("GiverPersonId").ToString();
                lkuReceivingPerson.Text = grwIncomes.GetFocusedRowCellValue("ReceivingPersonId").ToString();
                lkuType1.Text = grwIncomes.GetFocusedRowCellValue("SpeciesId").ToString();
                txtQuantity.Text = grwIncomes.GetFocusedRowCellValue("Quantity").ToString();
                dteDateReceived.Text = grwIncomes.GetFocusedRowCellValue("DateReceived").ToString();
                memoExplanation.Text = grwIncomes.GetFocusedRowCellValue("Explanation").ToString();
                txtId.Text = grwIncomes.GetFocusedRowCellValue("Id").ToString();
                txtCreateUser.Text = grwIncomes.GetFocusedRowCellValue("CreateUser").ToString();
            }
        }

        //TODO Metot Kullanılacak
        //void ExcelAktar(GridView Gr)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Xlsx|*.xlsx";
        //    saveFileDialog.Title = "Excel Kaydedilecek Yeri Seçin.";
        //    saveFileDialog.ShowDialog();

        //    if (saveFileDialog.FileName != null)
        //    {
        //        Gr.ExportToXlsx(saveFileDialog.FileName);
        //        DialogResult Confirmation = MessageBox.Show("Dosyayı Açmak İster Misiniz ?",
        //            "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (Confirmation == DialogResult.Yes)
        //        {
        //            Process.Start(saveFileDialog.FileName);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Excel Kayıt Edilecek Yer Seçiniz...");
        //    }
        //}

        private void btnExcelAktar_ItemClick(object sender, ItemClickEventArgs e)
        {
           _methods.ExcelAktar(grwIncomes);
        }

        private void grwIncomes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwIncomes.Focus();
                popupMenu1.ShowPopup(position);
            }
        }





        //private Frm_IncomeTypes frmIncomeTypes = new Frm_IncomeTypes();
        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    frmIncomeTypes = new Frm_IncomeTypes();
        //    frmIncomeTypes.ShowDialog();
        //    LoadIncomes();

        //}
    }
}
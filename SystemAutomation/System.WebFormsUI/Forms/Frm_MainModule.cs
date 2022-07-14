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
using DevExpress.XtraBars;
using DevExpress.XtraLayout.Utils;

namespace IlimYayma.WebFormsUI.Forms
{
    public partial class Frm_MainModule : DevExpress.XtraEditors.XtraForm
    {
        public Frm_MainModule()
        {
            InitializeComponent();
        }

        private void MainModule_Load(object sender, EventArgs e)
        {
            PanelControl();
            lblName.Text = Frm_Login.UserName;
        }

        private void PanelControl()
        {
            if (Frm_Login.User_Yetki == "0" || Frm_Login.User_Yetki == "1")
            {
                btnUsers.Visibility = BarItemVisibility.Always;
            }
            else if (Frm_Login.User_Yetki == "2")
            {
                btnUsers.Visibility = BarItemVisibility.Never;
            }

        }


        void OpenForm(Form form)
        {
            form.ShowDialog();
        }
        Frm_Incomes frmIncomes = new Frm_Incomes();
        private void btnIncomes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new Frm_Incomes());
        }

        private void btnEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new Frm_Employee());
        }

        private void btnPeople_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new Frm_Person());
        }

        private void btnIncomeTypes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            OpenForm(new Frm_IncomeTypes());
        }

        private void btnTypes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            OpenForm(new Frm_Type());
        }

        

        private void Frm_MainModule_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExpenses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new Frm_Expenses());
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new Frm_ExpenseType());
        }

        private void btnUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new Frm_Authorization());
        }

        private void btnSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new Frm_User());
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using IlimYayma.WebFormsUI.Forms;

namespace IlimYayma.WebFormsUI
{
    public class CommonMethods
    {
        public void ExcelAktar(GridView Gr)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xlsx|*.xlsx";
            saveFileDialog.Title = "Excel Kaydedilecek Yeri Seçin.";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null)
            {
                try
                {
                    Gr.ExportToXlsx(saveFileDialog.FileName);
                    DialogResult Confirmation = MessageBox.Show("Dosyayı Açmak İster Misiniz ?",
                        "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Confirmation == DialogResult.Yes)
                    {
                        Process.Start(saveFileDialog.FileName);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("İşleminiz iptal edilidi...", "Bilgilendirme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
               
            }
            else
            {
                MessageBox.Show("Excel Kayıt Edilecek Yer Seçiniz.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        public void PanelControl(RibbonPage ribbonPage)
        {
            try
            {
                if (Frm_Login.User_Yetki == "0" || Frm_Login.User_Yetki == "1")
                {
                    //btnSave.Visibility = BarItemVisibility.Always;
                    //btnClean.Visibility = BarItemVisibility.Always;
                    //btnRemove.Visibility = BarItemVisibility.Always;
                    //IslemlerMenusu.Visible = true;
                    //ribbonControl1.Visible = true;
                    ribbonPage.Visible = true;

                }
                else if (Frm_Login.User_Yetki == "2")
                {
                    //btnSave.Visibility = BarItemVisibility.Never;
                    //btnClean.Visibility = BarItemVisibility.Never;
                    //btnRemove.Visibility = BarItemVisibility.Never;
                    //IslemlerMenusu.Visible = false;
                    //ribbonControl1.Visible = false;
                    ribbonPage.Visible = false;
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Sistem Yüklenirken Hata Oluştu. Lütfen Tekrar deneyiniz.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }


        }


        


    }
}

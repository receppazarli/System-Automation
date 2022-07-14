
namespace IlimYayma.WebFormsUI.Forms
{
    partial class Frm_Authorization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Authorization));
            this.tabloAuthorization = new DevExpress.XtraLayout.LayoutControl();
            this.lkuUserAuthorization = new DevExpress.XtraEditors.LookUpEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.grcAuthorization = new DevExpress.XtraGrid.GridControl();
            this.grwAuthorization = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemove = new DevExpress.XtraBars.BarButtonItem();
            this.btnClean = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcelAktar = new DevExpress.XtraBars.BarButtonItem();
            this.rpMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.IslemlerMenusu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabloAuthorization)).BeginInit();
            this.tabloAuthorization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkuUserAuthorization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcAuthorization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwAuthorization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabloAuthorization
            // 
            this.tabloAuthorization.Controls.Add(this.lkuUserAuthorization);
            this.tabloAuthorization.Controls.Add(this.txtId);
            this.tabloAuthorization.Controls.Add(this.txtUserName);
            this.tabloAuthorization.Controls.Add(this.grcAuthorization);
            this.tabloAuthorization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabloAuthorization.Location = new System.Drawing.Point(0, 158);
            this.tabloAuthorization.Name = "tabloAuthorization";
            this.tabloAuthorization.Root = this.Root;
            this.tabloAuthorization.Size = new System.Drawing.Size(731, 300);
            this.tabloAuthorization.TabIndex = 0;
            this.tabloAuthorization.Text = "layoutControl1";
            // 
            // lkuUserAuthorization
            // 
            this.lkuUserAuthorization.Location = new System.Drawing.Point(118, 240);
            this.lkuUserAuthorization.Name = "lkuUserAuthorization";
            this.lkuUserAuthorization.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lkuUserAuthorization.Properties.Appearance.Options.UseFont = true;
            this.lkuUserAuthorization.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuUserAuthorization.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserAuthorizationName", "Yetki Adı"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkuUserAuthorization.Properties.NullText = "Lütfen Seçim Yapınız";
            this.lkuUserAuthorization.Size = new System.Drawing.Size(601, 24);
            this.lkuUserAuthorization.StyleController = this.tabloAuthorization;
            this.lkuUserAuthorization.TabIndex = 2;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(118, 268);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(601, 20);
            this.txtId.StyleController = this.tabloAuthorization;
            this.txtId.TabIndex = 11;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(118, 212);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(601, 24);
            this.txtUserName.StyleController = this.tabloAuthorization;
            this.txtUserName.TabIndex = 1;
            // 
            // grcAuthorization
            // 
            this.grcAuthorization.Location = new System.Drawing.Point(12, 12);
            this.grcAuthorization.MainView = this.grwAuthorization;
            this.grcAuthorization.Name = "grcAuthorization";
            this.grcAuthorization.Size = new System.Drawing.Size(707, 196);
            this.grcAuthorization.TabIndex = 4;
            this.grcAuthorization.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grwAuthorization});
            this.grcAuthorization.Click += new System.EventHandler(this.grcAuthorization_Click);
            // 
            // grwAuthorization
            // 
            this.grwAuthorization.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.grwAuthorization.GridControl = this.grcAuthorization;
            this.grwAuthorization.GroupPanelText = "Gruplamak İçin Sürükleyiniz";
            this.grwAuthorization.Name = "grwAuthorization";
            this.grwAuthorization.OptionsBehavior.Editable = false;
            this.grwAuthorization.OptionsNavigation.UseTabKey = false;
            this.grwAuthorization.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grwAuthorization_MouseDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kullanıcı Adı";
            this.gridColumn2.FieldName = "klnc_ad";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "klnc_sifre";
            this.gridColumn3.FieldName = "klnc_sifre";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Kullanıcı Yetki";
            this.gridColumn4.FieldName = "klnc_yetki";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "DeleteFlag";
            this.gridColumn5.FieldName = "DeleteFlag";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "CreateUser";
            this.gridColumn6.FieldName = "CreateUser";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "CreateDate";
            this.gridColumn7.FieldName = "CreateDate";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "LastUpUser";
            this.gridColumn8.FieldName = "LastUpUser";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "LastUpDate";
            this.gridColumn9.FieldName = "LastUpDate";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem10});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(731, 300);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcAuthorization;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(711, 200);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtUserName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 200);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(711, 28);
            this.layoutControlItem2.Text = "Kullanıcı Adı :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(103, 17);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtId;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 256);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(711, 24);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(103, 13);
            this.layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.Control = this.lkuUserAuthorization;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 228);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(711, 28);
            this.layoutControlItem10.Text = "Kullanıcı Yetkisi :";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(103, 17);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnSave,
            this.btnRemove,
            this.btnClean,
            this.btnExcelAktar});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpMenu});
            this.ribbonControl1.Size = new System.Drawing.Size(731, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Kaydet";
            this.btnSave.Id = 1;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.LargeImage")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Caption = "Sil";
            this.btnRemove.Id = 2;
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.LargeImage")));
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemove_ItemClick);
            // 
            // btnClean
            // 
            this.btnClean.Caption = "Yeni Kayıt";
            this.btnClean.Id = 3;
            this.btnClean.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClean.ImageOptions.Image")));
            this.btnClean.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClean.ImageOptions.LargeImage")));
            this.btnClean.Name = "btnClean";
            this.btnClean.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClean_ItemClick);
            // 
            // btnExcelAktar
            // 
            this.btnExcelAktar.Caption = "Excel\'e Aktar";
            this.btnExcelAktar.Id = 4;
            this.btnExcelAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelAktar.ImageOptions.Image")));
            this.btnExcelAktar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExcelAktar.ImageOptions.LargeImage")));
            this.btnExcelAktar.Name = "btnExcelAktar";
            this.btnExcelAktar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcelAktar_ItemClick);
            // 
            // rpMenu
            // 
            this.rpMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.IslemlerMenusu,
            this.ribbonPageGroup1});
            this.rpMenu.Name = "rpMenu";
            this.rpMenu.Text = "Menü";
            // 
            // IslemlerMenusu
            // 
            this.IslemlerMenusu.ItemLinks.Add(this.btnSave);
            this.IslemlerMenusu.ItemLinks.Add(this.btnRemove);
            this.IslemlerMenusu.ItemLinks.Add(this.btnClean);
            this.IslemlerMenusu.Name = "IslemlerMenusu";
            this.IslemlerMenusu.Text = "İşlemler";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExcelAktar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            this.ribbonPageGroup1.Visible = false;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 458);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(731, 24);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.btnExcelAktar);
            this.popupMenu1.ItemLinks.Add(this.btnRemove);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl1;
            // 
            // Frm_Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 482);
            this.Controls.Add(this.tabloAuthorization);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Authorization";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Kullanıcı Yetkilendirme";
            this.Load += new System.EventHandler(this.Frm_Authorization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabloAuthorization)).EndInit();
            this.tabloAuthorization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkuUserAuthorization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcAuthorization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwAuthorization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl tabloAuthorization;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraGrid.GridControl grcAuthorization;
        private DevExpress.XtraGrid.Views.Grid.GridView grwAuthorization;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.LookUpEdit lkuUserAuthorization;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup IslemlerMenusu;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnRemove;
        private DevExpress.XtraBars.BarButtonItem btnClean;
        private DevExpress.XtraBars.BarButtonItem btnExcelAktar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}
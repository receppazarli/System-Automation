
namespace IlimYayma.WebFormsUI.Forms
{
    partial class Frm_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_User));
            this.tabloUser = new DevExpress.XtraLayout.LayoutControl();
            this.panelInfo = new DevExpress.XtraEditors.PanelControl();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCreateDate = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutPanelInfo = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnUpdatePassword = new DevExpress.XtraEditors.SimpleButton();
            this.btnPasswordOpen = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabloUser)).BeginInit();
            this.tabloUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInfo)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutPanelInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabloUser
            // 
            this.tabloUser.Controls.Add(this.panelInfo);
            this.tabloUser.Controls.Add(this.btnUpdatePassword);
            this.tabloUser.Controls.Add(this.btnPasswordOpen);
            this.tabloUser.Controls.Add(this.txtPassword);
            this.tabloUser.Controls.Add(this.txtUserName);
            this.tabloUser.Controls.Add(this.txtNewPassword);
            this.tabloUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabloUser.Location = new System.Drawing.Point(0, 0);
            this.tabloUser.Name = "tabloUser";
            this.tabloUser.Root = this.Root;
            this.tabloUser.Size = new System.Drawing.Size(449, 150);
            this.tabloUser.TabIndex = 0;
            this.tabloUser.Text = "layoutControl1";
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.txtId);
            this.panelInfo.Controls.Add(this.txtCreateDate);
            this.panelInfo.Controls.Add(this.txtCreateUser);
            this.panelInfo.Location = new System.Drawing.Point(12, 136);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(425, 2);
            this.panelInfo.TabIndex = 8;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(212, 5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 21);
            this.txtId.TabIndex = 2;
            // 
            // txtCreateDate
            // 
            this.txtCreateDate.Location = new System.Drawing.Point(106, 5);
            this.txtCreateDate.Name = "txtCreateDate";
            this.txtCreateDate.Size = new System.Drawing.Size(100, 21);
            this.txtCreateDate.TabIndex = 1;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(0, 5);
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.Size = new System.Drawing.Size(100, 21);
            this.txtCreateUser.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 40);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(313, 24);
            this.txtPassword.StyleController = this.tabloUser;
            this.txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(98, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(339, 24);
            this.txtUserName.StyleController = this.tabloUser;
            this.txtUserName.TabIndex = 4;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(98, 68);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNewPassword.Properties.Appearance.Options.UseFont = true;
            this.txtNewPassword.Properties.UseSystemPasswordChar = true;
            this.txtNewPassword.Size = new System.Drawing.Size(339, 24);
            this.txtNewPassword.StyleController = this.tabloUser;
            this.txtNewPassword.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutPanelInfo});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(449, 150);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtUserName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(429, 28);
            this.layoutControlItem1.Text = "Kullanıcı Adı :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(83, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtPassword;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(403, 28);
            this.layoutControlItem2.Text = "Eski Şifre :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(83, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txtNewPassword;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem5.CustomizationFormText = "Şifre :";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(429, 28);
            this.layoutControlItem5.Text = "Yeni Şifre :";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(83, 17);
            // 
            // layoutPanelInfo
            // 
            this.layoutPanelInfo.Control = this.panelInfo;
            this.layoutPanelInfo.Location = new System.Drawing.Point(0, 124);
            this.layoutPanelInfo.Name = "layoutPanelInfo";
            this.layoutPanelInfo.Size = new System.Drawing.Size(429, 6);
            this.layoutPanelInfo.TextSize = new System.Drawing.Size(0, 0);
            this.layoutPanelInfo.TextVisible = false;
            this.layoutPanelInfo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdatePassword.Appearance.Options.UseFont = true;
            this.btnUpdatePassword.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdatePassword.ImageOptions.Image")));
            this.btnUpdatePassword.Location = new System.Drawing.Point(12, 96);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(425, 36);
            this.btnUpdatePassword.StyleController = this.tabloUser;
            this.btnUpdatePassword.TabIndex = 7;
            this.btnUpdatePassword.Text = "ŞİFRE GÜNCELLE";
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // btnPasswordOpen
            // 
            this.btnPasswordOpen.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPasswordOpen.Appearance.Options.UseFont = true;
            this.btnPasswordOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPasswordOpen.ImageOptions.Image")));
            this.btnPasswordOpen.Location = new System.Drawing.Point(415, 40);
            this.btnPasswordOpen.Name = "btnPasswordOpen";
            this.btnPasswordOpen.Size = new System.Drawing.Size(22, 22);
            this.btnPasswordOpen.StyleController = this.tabloUser;
            this.btnPasswordOpen.TabIndex = 6;
            this.btnPasswordOpen.Click += new System.EventHandler(this.btnPasswordOpen_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnUpdatePassword;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(429, 40);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnPasswordOpen;
            this.layoutControlItem3.Location = new System.Drawing.Point(403, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(26, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // Frm_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 150);
            this.Controls.Add(this.tabloUser);
            this.Name = "Frm_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KULLANICI BİLGİLERİ GÜNCELLEME";
            this.Load += new System.EventHandler(this.Frm_User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabloUser)).EndInit();
            this.tabloUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInfo)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutPanelInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl tabloUser;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnPasswordOpen;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnUpdatePassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.PanelControl panelInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutPanelInfo;
        private System.Windows.Forms.TextBox txtCreateDate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.TextBox txtId;
    }
}
namespace PhanMemQuanLyNhanKhau
{
    partial class FormSoftwareAdministratorLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdminQuit = new System.Windows.Forms.Button();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.txtbAdminPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbAdminUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Đăng nhập với quyền ADMIN phần mềm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdminQuit
            // 
            this.btnAdminQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminQuit.ForeColor = System.Drawing.Color.Blue;
            this.btnAdminQuit.Image = global::PhanMemQuanLyNhanKhau.Properties.Resources.exit__Custom_;
            this.btnAdminQuit.Location = new System.Drawing.Point(255, 179);
            this.btnAdminQuit.Name = "btnAdminQuit";
            this.btnAdminQuit.Size = new System.Drawing.Size(133, 43);
            this.btnAdminQuit.TabIndex = 32;
            this.btnAdminQuit.Text = "Thoát";
            this.btnAdminQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdminQuit.UseVisualStyleBackColor = true;
            this.btnAdminQuit.Click += new System.EventHandler(this.btnAdminQuit_Click);
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.Enabled = false;
            this.btnAdminLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminLogin.ForeColor = System.Drawing.Color.Blue;
            this.btnAdminLogin.Image = global::PhanMemQuanLyNhanKhau.Properties.Resources.login_xxl;
            this.btnAdminLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminLogin.Location = new System.Drawing.Point(107, 179);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(133, 43);
            this.btnAdminLogin.TabIndex = 31;
            this.btnAdminLogin.Text = "Đăng nhập";
            this.btnAdminLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdminLogin.UseVisualStyleBackColor = true;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // txtbAdminPassword
            // 
            this.txtbAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAdminPassword.ForeColor = System.Drawing.Color.Blue;
            this.txtbAdminPassword.Location = new System.Drawing.Point(165, 126);
            this.txtbAdminPassword.Name = "txtbAdminPassword";
            this.txtbAdminPassword.Size = new System.Drawing.Size(284, 26);
            this.txtbAdminPassword.TabIndex = 30;
            this.txtbAdminPassword.UseSystemPasswordChar = true;
            this.txtbAdminPassword.TextChanged += new System.EventHandler(this.txtbAdminPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(28, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Mật Khẩu:";
            // 
            // txtbAdminUserName
            // 
            this.txtbAdminUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAdminUserName.ForeColor = System.Drawing.Color.Blue;
            this.txtbAdminUserName.Location = new System.Drawing.Point(165, 82);
            this.txtbAdminUserName.Name = "txtbAdminUserName";
            this.txtbAdminUserName.Size = new System.Drawing.Size(284, 26);
            this.txtbAdminUserName.TabIndex = 28;
            this.txtbAdminUserName.TextChanged += new System.EventHandler(this.txtbAdminUserName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(28, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên Đăng Nhập:";
            // 
            // FormSoftwareAdministratorLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdminQuit);
            this.Controls.Add(this.btnAdminLogin);
            this.Controls.Add(this.txtbAdminPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbAdminUserName);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSoftwareAdministratorLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập với quyền admin phần mềm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdminQuit;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.TextBox txtbAdminPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbAdminUserName;
        private System.Windows.Forms.Label label2;
    }
}
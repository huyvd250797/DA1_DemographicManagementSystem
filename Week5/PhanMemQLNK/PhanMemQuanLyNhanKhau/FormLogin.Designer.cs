namespace PhanMemQuanLyNhanKhau
{
    partial class FormLogin
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
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReloadDatabases = new System.Windows.Forms.Button();
            this.cbboxDatabaseNames = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLoadDefault = new System.Windows.Forms.Button();
            this.chboxRemember = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChangeValues = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReloadDatabases);
            this.groupBox3.Controls.Add(this.cbboxDatabaseNames);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(14, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 64);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin cơ sở dữ liệu";
            // 
            // btnReloadDatabases
            // 
            this.btnReloadDatabases.Enabled = false;
            this.btnReloadDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadDatabases.ForeColor = System.Drawing.Color.Blue;
            this.btnReloadDatabases.Image = global::PhanMemQuanLyNhanKhau.Properties.Resources.reload2;
            this.btnReloadDatabases.Location = new System.Drawing.Point(412, 22);
            this.btnReloadDatabases.Name = "btnReloadDatabases";
            this.btnReloadDatabases.Size = new System.Drawing.Size(34, 28);
            this.btnReloadDatabases.TabIndex = 9;
            this.btnReloadDatabases.UseVisualStyleBackColor = true;
            this.btnReloadDatabases.Click += new System.EventHandler(this.btnReloadDatabases_Click);
            // 
            // cbboxDatabaseNames
            // 
            this.cbboxDatabaseNames.Enabled = false;
            this.cbboxDatabaseNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbboxDatabaseNames.ForeColor = System.Drawing.Color.Blue;
            this.cbboxDatabaseNames.FormattingEnabled = true;
            this.cbboxDatabaseNames.Location = new System.Drawing.Point(162, 22);
            this.cbboxDatabaseNames.Name = "cbboxDatabaseNames";
            this.cbboxDatabaseNames.Size = new System.Drawing.Size(235, 28);
            this.cbboxDatabaseNames.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(25, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Database:";
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.Blue;
            this.btnQuit.Image = global::PhanMemQuanLyNhanKhau.Properties.Resources.exit__Custom_;
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuit.Location = new System.Drawing.Point(384, 294);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(98, 43);
            this.btnQuit.TabIndex = 32;
            this.btnQuit.Text = "Thoát";
            this.btnQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Blue;
            this.btnLogin.Image = global::PhanMemQuanLyNhanKhau.Properties.Resources.login_xxl;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(245, 294);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(133, 43);
            this.btnLogin.TabIndex = 31;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLoadDefault
            // 
            this.btnLoadDefault.Enabled = false;
            this.btnLoadDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDefault.ForeColor = System.Drawing.Color.Blue;
            this.btnLoadDefault.Image = global::PhanMemQuanLyNhanKhau.Properties.Resources.Default2__Custom___Custom_;
            this.btnLoadDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDefault.Location = new System.Drawing.Point(26, 294);
            this.btnLoadDefault.Name = "btnLoadDefault";
            this.btnLoadDefault.Size = new System.Drawing.Size(169, 43);
            this.btnLoadDefault.TabIndex = 30;
            this.btnLoadDefault.Text = "Tải lại mặc định";
            this.btnLoadDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadDefault.UseVisualStyleBackColor = true;
            this.btnLoadDefault.Click += new System.EventHandler(this.btnLoadDefault_Click);
            // 
            // chboxRemember
            // 
            this.chboxRemember.AutoSize = true;
            this.chboxRemember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxRemember.Location = new System.Drawing.Point(168, 379);
            this.chboxRemember.Name = "chboxRemember";
            this.chboxRemember.Size = new System.Drawing.Size(314, 19);
            this.chboxRemember.TabIndex = 29;
            this.chboxRemember.Text = "ghi nhớ thông tin trong lần đăng nhập kế tiếp";
            this.chboxRemember.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbPassword);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtbUserName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 112);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tài khoản người dùng";
            // 
            // txtbPassword
            // 
            this.txtbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPassword.ForeColor = System.Drawing.Color.Blue;
            this.txtbPassword.Location = new System.Drawing.Point(162, 66);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.Size = new System.Drawing.Size(284, 26);
            this.txtbPassword.TabIndex = 7;
            this.txtbPassword.UseSystemPasswordChar = true;
            this.txtbPassword.TextChanged += new System.EventHandler(this.txtbPassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(25, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật Khẩu:";
            // 
            // txtbUserName
            // 
            this.txtbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbUserName.ForeColor = System.Drawing.Color.Blue;
            this.txtbUserName.Location = new System.Drawing.Point(162, 22);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.Size = new System.Drawing.Size(284, 26);
            this.txtbUserName.TabIndex = 5;
            this.txtbUserName.TextChanged += new System.EventHandler(this.txtbUserName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên Đăng Nhập:";
            // 
            // btnChangeValues
            // 
            this.btnChangeValues.Image = global::PhanMemQuanLyNhanKhau.Properties.Resources._lock;
            this.btnChangeValues.Location = new System.Drawing.Point(26, 359);
            this.btnChangeValues.Name = "btnChangeValues";
            this.btnChangeValues.Size = new System.Drawing.Size(42, 39);
            this.btnChangeValues.TabIndex = 25;
            this.btnChangeValues.UseVisualStyleBackColor = true;
            this.btnChangeValues.Click += new System.EventHandler(this.btnChangeValues_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbServerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 64);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin máy chủ";
            // 
            // txtbServerName
            // 
            this.txtbServerName.Enabled = false;
            this.txtbServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbServerName.ForeColor = System.Drawing.Color.Blue;
            this.txtbServerName.Location = new System.Drawing.Point(162, 19);
            this.txtbServerName.Name = "txtbServerName";
            this.txtbServerName.Size = new System.Drawing.Size(284, 26);
            this.txtbServerName.TabIndex = 1;
            this.txtbServerName.TextChanged += new System.EventHandler(this.txtbServerName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Server:";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 411);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnLoadDefault);
            this.Controls.Add(this.chboxRemember);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnChangeValues);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập vào hệ thống";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReloadDatabases;
        private System.Windows.Forms.ComboBox cbboxDatabaseNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLoadDefault;
        private System.Windows.Forms.CheckBox chboxRemember;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeValues;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbServerName;
        private System.Windows.Forms.Label label1;
    }
}
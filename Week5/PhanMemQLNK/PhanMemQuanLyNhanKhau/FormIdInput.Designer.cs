namespace PhanMemQuanLyNhanKhau
{
    partial class FormIdInput
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
            this.txtbCMND = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHoanTatCMND = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbCMND
            // 
            this.txtbCMND.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtbCMND.Location = new System.Drawing.Point(132, 34);
            this.txtbCMND.Name = "txtbCMND";
            this.txtbCMND.Size = new System.Drawing.Size(141, 24);
            this.txtbCMND.TabIndex = 110;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 16);
            this.label10.TabIndex = 109;
            this.label10.Text = "Mã Số CMND:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 111;
            this.label1.Text = "Hãy nhập vào Số CMND";
            // 
            // btnHoanTatCMND
            // 
            this.btnHoanTatCMND.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnHoanTatCMND.Location = new System.Drawing.Point(87, 67);
            this.btnHoanTatCMND.Name = "btnHoanTatCMND";
            this.btnHoanTatCMND.Size = new System.Drawing.Size(107, 25);
            this.btnHoanTatCMND.TabIndex = 112;
            this.btnHoanTatCMND.Text = "Hoàn Tất";
            this.btnHoanTatCMND.UseVisualStyleBackColor = true;
            this.btnHoanTatCMND.Click += new System.EventHandler(this.btnHoanTatCMND_Click);
            // 
            // FormIdInput
            // 
            this.AcceptButton = this.btnHoanTatCMND;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 104);
            this.Controls.Add(this.btnHoanTatCMND);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbCMND);
            this.Controls.Add(this.label10);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIdInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gõ vào CMND";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbCMND;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHoanTatCMND;
    }
}
namespace GymGenZ.PViews
{
    partial class F_SignCustomer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbPakage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(251, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 454);
            this.panel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbAddress);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(3, 296);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(486, 99);
            this.panel7.TabIndex = 7;
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbAddress.Location = new System.Drawing.Point(109, 8);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(371, 85);
            this.tbAddress.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(4, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Địa chỉ";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbGender);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(3, 200);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(486, 42);
            this.panel6.TabIndex = 6;
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbGender.Location = new System.Drawing.Point(109, 9);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(371, 21);
            this.cbGender.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(4, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Giới tính";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbPakage);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(0, 248);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(486, 42);
            this.panel5.TabIndex = 5;
            // 
            // cbPakage
            // 
            this.cbPakage.FormattingEnabled = true;
            this.cbPakage.Location = new System.Drawing.Point(112, 8);
            this.cbPakage.Name = "cbPakage";
            this.cbPakage.Size = new System.Drawing.Size(371, 21);
            this.cbPakage.TabIndex = 1;
            this.cbPakage.SelectedIndexChanged += new System.EventHandler(this.cbPakage_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(4, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Gói tập:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(292, 401);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(197, 43);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Đăng ký";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbID);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(3, 152);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(486, 42);
            this.panel4.TabIndex = 3;
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.Color.White;
            this.tbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbID.Location = new System.Drawing.Point(109, 8);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(371, 22);
            this.tbID.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(4, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "CCCD:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbPhone);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 104);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(486, 42);
            this.panel3.TabIndex = 2;
            // 
            // tbPhone
            // 
            this.tbPhone.BackColor = System.Drawing.Color.White;
            this.tbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbPhone.Location = new System.Drawing.Point(112, 9);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(371, 22);
            this.tbPhone.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(4, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số điện thoại:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 42);
            this.panel2.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbName.Location = new System.Drawing.Point(109, 8);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(371, 22);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ và tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(131, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin khách hàng";
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // F_SignCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1156, 558);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_SignCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.F_SignCustomer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.ComboBox cbPakage;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbGender;
    }
}
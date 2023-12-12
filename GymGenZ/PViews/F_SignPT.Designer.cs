namespace GymGenZ.PViews
{
    partial class F_SignPT
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
            this.dataStaff = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoC8 = new System.Windows.Forms.RadioButton();
            this.rdoC7 = new System.Windows.Forms.RadioButton();
            this.rdoC6 = new System.Windows.Forms.RadioButton();
            this.rdoC5 = new System.Windows.Forms.RadioButton();
            this.rdoC4 = new System.Windows.Forms.RadioButton();
            this.rdoC3 = new System.Windows.Forms.RadioButton();
            this.rdoC2 = new System.Windows.Forms.RadioButton();
            this.rdoC1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkDate = new System.Windows.Forms.CheckedListBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.cbSession = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataStaff)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataStaff
            // 
            this.dataStaff.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
<<<<<<< Updated upstream
            this.dataStaff.Location = new System.Drawing.Point(16, 249);
            this.dataStaff.Margin = new System.Windows.Forms.Padding(4);
=======
            this.dataStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullname,
            this.phoneNumber});
            this.dataStaff.Location = new System.Drawing.Point(15, 202);
            this.dataStaff.Location = new System.Drawing.Point(12, 202);
>>>>>>> Stashed changes
            this.dataStaff.Name = "dataStaff";
            this.dataStaff.RowHeadersWidth = 51;
            this.dataStaff.Size = new System.Drawing.Size(1359, 241);
            this.dataStaff.TabIndex = 0;
            this.dataStaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataStaff_CellContentClick);
            this.dataStaff.SelectionChanged += new System.EventHandler(this.dataStaff_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoC8);
            this.groupBox1.Controls.Add(this.rdoC7);
            this.groupBox1.Controls.Add(this.rdoC6);
            this.groupBox1.Controls.Add(this.rdoC5);
            this.groupBox1.Controls.Add(this.rdoC4);
            this.groupBox1.Controls.Add(this.rdoC3);
            this.groupBox1.Controls.Add(this.rdoC2);
            this.groupBox1.Controls.Add(this.rdoC1);
            this.groupBox1.Location = new System.Drawing.Point(16, 78);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(683, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ca tập";
            // 
            // rdoC8
            // 
            this.rdoC8.AutoSize = true;
            this.rdoC8.Location = new System.Drawing.Point(555, 27);
            this.rdoC8.Margin = new System.Windows.Forms.Padding(4);
            this.rdoC8.Name = "rdoC8";
            this.rdoC8.Size = new System.Drawing.Size(55, 20);
            this.rdoC8.TabIndex = 7;
            this.rdoC8.TabStop = true;
            this.rdoC8.Text = "Ca 8";
            this.rdoC8.UseVisualStyleBackColor = true;
            // 
            // rdoC7
            // 
            this.rdoC7.AutoSize = true;
            this.rdoC7.Location = new System.Drawing.Point(483, 28);
            this.rdoC7.Margin = new System.Windows.Forms.Padding(4);
            this.rdoC7.Name = "rdoC7";
            this.rdoC7.Size = new System.Drawing.Size(55, 20);
            this.rdoC7.TabIndex = 6;
            this.rdoC7.TabStop = true;
            this.rdoC7.Text = "Ca 7";
            this.rdoC7.UseVisualStyleBackColor = true;
            // 
            // rdoC6
            // 
            this.rdoC6.AutoSize = true;
            this.rdoC6.Location = new System.Drawing.Point(404, 27);
            this.rdoC6.Margin = new System.Windows.Forms.Padding(4);
            this.rdoC6.Name = "rdoC6";
            this.rdoC6.Size = new System.Drawing.Size(55, 20);
            this.rdoC6.TabIndex = 5;
            this.rdoC6.TabStop = true;
            this.rdoC6.Text = "Ca 6";
            this.rdoC6.UseVisualStyleBackColor = true;
            // 
            // rdoC5
            // 
            this.rdoC5.AutoSize = true;
            this.rdoC5.Location = new System.Drawing.Point(325, 28);
            this.rdoC5.Margin = new System.Windows.Forms.Padding(4);
            this.rdoC5.Name = "rdoC5";
            this.rdoC5.Size = new System.Drawing.Size(55, 20);
            this.rdoC5.TabIndex = 4;
            this.rdoC5.TabStop = true;
            this.rdoC5.Text = "Ca 5";
            this.rdoC5.UseVisualStyleBackColor = true;
            // 
            // rdoC4
            // 
            this.rdoC4.AutoSize = true;
            this.rdoC4.Location = new System.Drawing.Point(247, 28);
            this.rdoC4.Margin = new System.Windows.Forms.Padding(4);
            this.rdoC4.Name = "rdoC4";
            this.rdoC4.Size = new System.Drawing.Size(55, 20);
            this.rdoC4.TabIndex = 3;
            this.rdoC4.TabStop = true;
            this.rdoC4.Text = "Ca 4";
            this.rdoC4.UseVisualStyleBackColor = true;
            // 
            // rdoC3
            // 
            this.rdoC3.AutoSize = true;
            this.rdoC3.Location = new System.Drawing.Point(168, 28);
            this.rdoC3.Margin = new System.Windows.Forms.Padding(4);
            this.rdoC3.Name = "rdoC3";
            this.rdoC3.Size = new System.Drawing.Size(55, 20);
            this.rdoC3.TabIndex = 2;
            this.rdoC3.TabStop = true;
            this.rdoC3.Text = "Ca 3";
            this.rdoC3.UseVisualStyleBackColor = true;
            this.rdoC3.CheckedChanged += new System.EventHandler(this.rdoC3_CheckedChanged);
            // 
            // rdoC2
            // 
            this.rdoC2.AutoSize = true;
            this.rdoC2.Location = new System.Drawing.Point(89, 28);
            this.rdoC2.Margin = new System.Windows.Forms.Padding(4);
            this.rdoC2.Name = "rdoC2";
            this.rdoC2.Size = new System.Drawing.Size(55, 20);
            this.rdoC2.TabIndex = 1;
            this.rdoC2.TabStop = true;
            this.rdoC2.Text = "Ca 2";
            this.rdoC2.UseVisualStyleBackColor = true;
            this.rdoC2.CheckedChanged += new System.EventHandler(this.rdoC2_CheckedChanged);
            // 
            // rdoC1
            // 
            this.rdoC1.AutoSize = true;
            this.rdoC1.Location = new System.Drawing.Point(11, 28);
            this.rdoC1.Margin = new System.Windows.Forms.Padding(4);
            this.rdoC1.Name = "rdoC1";
            this.rdoC1.Size = new System.Drawing.Size(55, 20);
            this.rdoC1.TabIndex = 0;
            this.rdoC1.TabStop = true;
            this.rdoC1.Text = "Ca 1";
            this.rdoC1.UseVisualStyleBackColor = true;
            this.rdoC1.CheckedChanged += new System.EventHandler(this.rdoC1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkDate);
            this.groupBox2.Location = new System.Drawing.Point(16, 160);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(683, 81);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ngày tập";
            // 
            // checkDate
            // 
            this.checkDate.FormattingEnabled = true;
            this.checkDate.Items.AddRange(new object[] {
            "Thứ 2",
            "Thứ 3",
            "Thứ 4",
            "Thứ 5",
            "Thứ 6",
            "Thứ 7",
            "Chủ Nhật"});
            this.checkDate.Location = new System.Drawing.Point(9, 23);
            this.checkDate.Margin = new System.Windows.Forms.Padding(4);
            this.checkDate.MultiColumn = true;
            this.checkDate.Name = "checkDate";
            this.checkDate.Size = new System.Drawing.Size(660, 38);
            this.checkDate.TabIndex = 0;
            this.checkDate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkDate_ItemCheck);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(1251, 519);
            this.btnSign.Margin = new System.Windows.Forms.Padding(4);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(228, 48);
            this.btnSign.TabIndex = 3;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // cbSession
            // 
            this.cbSession.FormattingEnabled = true;
            this.cbSession.Location = new System.Drawing.Point(8, 23);
            this.cbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cbSession.Name = "cbSession";
            this.cbSession.Size = new System.Drawing.Size(160, 24);
            this.cbSession.TabIndex = 4;
            this.cbSession.SelectedIndexChanged += new System.EventHandler(this.cbSession_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbSession);
            this.groupBox3.Location = new System.Drawing.Point(707, 78);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(176, 81);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Số buổi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 39);
            this.panel1.TabIndex = 6;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbName.Location = new System.Drawing.Point(176, 11);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(54, 20);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách hàng:";
            // 
            // fullname
            // 
            this.fullname.DataPropertyName = "fullname";
            this.fullname.HeaderText = "Tên huần luyện viên";
            this.fullname.Name = "fullname";
            // 
            // phoneNumber
            // 
            this.phoneNumber.DataPropertyName = "phoneNumber";
            this.phoneNumber.HeaderText = "Số điện thoại";
            this.phoneNumber.Name = "phoneNumber";
            // 
            // F_SignPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1504, 527);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataStaff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_SignPT";
            this.Text = "F_SignPT";
            this.Load += new System.EventHandler(this.F_SignPT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataStaff)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataStaff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoC7;
        private System.Windows.Forms.RadioButton rdoC6;
        private System.Windows.Forms.RadioButton rdoC5;
        private System.Windows.Forms.RadioButton rdoC4;
        private System.Windows.Forms.RadioButton rdoC3;
        private System.Windows.Forms.RadioButton rdoC2;
        private System.Windows.Forms.RadioButton rdoC1;
        private System.Windows.Forms.RadioButton rdoC8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkDate;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.ComboBox cbSession;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
    }
}
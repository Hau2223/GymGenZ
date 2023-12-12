namespace GymGenZ.PViews
{
    partial class F_ManagerPromotion
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
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoActivePromotion = new System.Windows.Forms.RadioButton();
            this.rdoExpiredPromotion = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbIDPromotion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnDeletePromotion = new System.Windows.Forms.Button();
            this.btnAddPromotion = new System.Windows.Forms.Button();
            this.btnUpdatePromotion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ptbFindPromotion = new System.Windows.Forms.PictureBox();
            this.tbFindDiscount = new System.Windows.Forms.TextBox();
            this.dtgvDiscount = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTPStart = new System.Windows.Forms.DateTimePicker();
            this.dateTPdateEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFindPromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(486, 48);
            this.label10.TabIndex = 2;
            this.label10.Text = "Quản Lý Khuyến mãi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(954, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 266);
            this.panel1.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoActivePromotion);
            this.groupBox2.Controls.Add(this.rdoExpiredPromotion);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 63);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tình Trạng";
            // 
            // rdoActivePromotion
            // 
            this.rdoActivePromotion.AutoSize = true;
            this.rdoActivePromotion.Enabled = false;
            this.rdoActivePromotion.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActivePromotion.Location = new System.Drawing.Point(218, 29);
            this.rdoActivePromotion.Name = "rdoActivePromotion";
            this.rdoActivePromotion.Size = new System.Drawing.Size(166, 24);
            this.rdoActivePromotion.TabIndex = 0;
            this.rdoActivePromotion.TabStop = true;
            this.rdoActivePromotion.Text = "đang hoạt động";
            this.rdoActivePromotion.UseVisualStyleBackColor = true;
            // 
            // rdoExpiredPromotion
            // 
            this.rdoExpiredPromotion.AutoSize = true;
            this.rdoExpiredPromotion.Enabled = false;
            this.rdoExpiredPromotion.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoExpiredPromotion.Location = new System.Drawing.Point(45, 29);
            this.rdoExpiredPromotion.Name = "rdoExpiredPromotion";
            this.rdoExpiredPromotion.Size = new System.Drawing.Size(96, 24);
            this.rdoExpiredPromotion.TabIndex = 0;
            this.rdoExpiredPromotion.TabStop = true;
            this.rdoExpiredPromotion.Text = "hết hạn";
            this.rdoExpiredPromotion.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dateTPdateEnd);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(13, 148);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(466, 30);
            this.panel4.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày kết thúc";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.dateTPStart);
            this.panel7.Location = new System.Drawing.Point(13, 101);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(466, 41);
            this.panel7.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(15, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Ngày bắt đầu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbIDPromotion);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(13, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 35);
            this.panel2.TabIndex = 7;
            // 
            // tbIDPromotion
            // 
            this.tbIDPromotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbIDPromotion.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbIDPromotion.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIDPromotion.Location = new System.Drawing.Point(180, 3);
            this.tbIDPromotion.Multiline = true;
            this.tbIDPromotion.Name = "tbIDPromotion";
            this.tbIDPromotion.Size = new System.Drawing.Size(283, 26);
            this.tbIDPromotion.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã khuyến mãi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(124)))), ((int)(((byte)(165)))));
            this.label2.Location = new System.Drawing.Point(52, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thông Tin Khuyến Mãi";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnDeletePromotion);
            this.panel9.Controls.Add(this.btnAddPromotion);
            this.panel9.Controls.Add(this.btnUpdatePromotion);
            this.panel9.Location = new System.Drawing.Point(858, 536);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(597, 69);
            this.panel9.TabIndex = 16;
            // 
            // btnDeletePromotion
            // 
            this.btnDeletePromotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.btnDeletePromotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePromotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDeletePromotion.ForeColor = System.Drawing.Color.White;
            this.btnDeletePromotion.Location = new System.Drawing.Point(18, 6);
            this.btnDeletePromotion.Margin = new System.Windows.Forms.Padding(5);
            this.btnDeletePromotion.Name = "btnDeletePromotion";
            this.btnDeletePromotion.Size = new System.Drawing.Size(160, 58);
            this.btnDeletePromotion.TabIndex = 13;
            this.btnDeletePromotion.Text = "Xóa";
            this.btnDeletePromotion.UseVisualStyleBackColor = false;
            this.btnDeletePromotion.Click += new System.EventHandler(this.btnDeletePromotion_Click);
            // 
            // btnAddPromotion
            // 
            this.btnAddPromotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.btnAddPromotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddPromotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPromotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAddPromotion.ForeColor = System.Drawing.Color.White;
            this.btnAddPromotion.Location = new System.Drawing.Point(217, 6);
            this.btnAddPromotion.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddPromotion.Name = "btnAddPromotion";
            this.btnAddPromotion.Size = new System.Drawing.Size(160, 58);
            this.btnAddPromotion.TabIndex = 13;
            this.btnAddPromotion.Text = "Thêm";
            this.btnAddPromotion.UseVisualStyleBackColor = false;
            this.btnAddPromotion.Click += new System.EventHandler(this.btnAddPromotion_Click);
            // 
            // btnUpdatePromotion
            // 
            this.btnUpdatePromotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.btnUpdatePromotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePromotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUpdatePromotion.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePromotion.Location = new System.Drawing.Point(424, 6);
            this.btnUpdatePromotion.Margin = new System.Windows.Forms.Padding(5);
            this.btnUpdatePromotion.Name = "btnUpdatePromotion";
            this.btnUpdatePromotion.Size = new System.Drawing.Size(160, 58);
            this.btnUpdatePromotion.TabIndex = 12;
            this.btnUpdatePromotion.Text = "Cập nhật";
            this.btnUpdatePromotion.UseVisualStyleBackColor = false;
            this.btnUpdatePromotion.Click += new System.EventHandler(this.btnUpdatePromotion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.ptbFindPromotion);
            this.groupBox1.Controls.Add(this.tbFindDiscount);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.groupBox1.Location = new System.Drawing.Point(1015, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 77);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // ptbFindPromotion
            // 
            this.ptbFindPromotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.ptbFindPromotion.Image = global::GymGenZ.Properties.Resources.Vector;
            this.ptbFindPromotion.Location = new System.Drawing.Point(242, 19);
            this.ptbFindPromotion.Margin = new System.Windows.Forms.Padding(5);
            this.ptbFindPromotion.Name = "ptbFindPromotion";
            this.ptbFindPromotion.Size = new System.Drawing.Size(65, 50);
            this.ptbFindPromotion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbFindPromotion.TabIndex = 9;
            this.ptbFindPromotion.TabStop = false;
            this.ptbFindPromotion.Click += new System.EventHandler(this.ptbFindPromotion_Click);
            // 
            // tbFindDiscount
            // 
            this.tbFindDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbFindDiscount.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbFindDiscount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFindDiscount.Location = new System.Drawing.Point(14, 26);
            this.tbFindDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFindDiscount.Multiline = true;
            this.tbFindDiscount.Name = "tbFindDiscount";
            this.tbFindDiscount.Size = new System.Drawing.Size(216, 30);
            this.tbFindDiscount.TabIndex = 14;
            this.tbFindDiscount.TextChanged += new System.EventHandler(this.tbFindDiscount_TextChanged);
            // 
            // dtgvDiscount
            // 
            this.dtgvDiscount.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDiscount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dtgvDiscount.Location = new System.Drawing.Point(49, 144);
            this.dtgvDiscount.Name = "dtgvDiscount";
            this.dtgvDiscount.RowHeadersWidth = 51;
            this.dtgvDiscount.RowTemplate.Height = 24;
            this.dtgvDiscount.Size = new System.Drawing.Size(812, 349);
            this.dtgvDiscount.TabIndex = 18;
            this.dtgvDiscount.SelectionChanged += new System.EventHandler(this.dtgvDiscount_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Mã khuyến mãi";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "timeStart";
            this.Column2.HeaderText = "Ngày bắt đầu";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "timeEnd";
            this.Column3.HeaderText = "Ngày kết thúc";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "status";
            this.Column4.HeaderText = "Tình trạng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // dateTPStart
            // 
            this.dateTPStart.Location = new System.Drawing.Point(180, 7);
            this.dateTPStart.Name = "dateTPStart";
            this.dateTPStart.Size = new System.Drawing.Size(283, 22);
            this.dateTPStart.TabIndex = 19;
            // 
            // dateTPdateEnd
            // 
            this.dateTPdateEnd.Location = new System.Drawing.Point(180, 3);
            this.dateTPdateEnd.Name = "dateTPdateEnd";
            this.dateTPdateEnd.Size = new System.Drawing.Size(283, 22);
            this.dateTPdateEnd.TabIndex = 19;
            // 
            // F_ManagerPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 747);
            this.Controls.Add(this.dtgvDiscount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_ManagerPromotion";
            this.Text = "F_ManagerPromotion";
            this.Load += new System.EventHandler(this.F_ManagerPromotion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFindPromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbIDPromotion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnDeletePromotion;
        private System.Windows.Forms.Button btnAddPromotion;
        private System.Windows.Forms.Button btnUpdatePromotion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ptbFindPromotion;
        private System.Windows.Forms.TextBox tbFindDiscount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoActivePromotion;
        private System.Windows.Forms.RadioButton rdoExpiredPromotion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DateTimePicker dateTPStart;
        private System.Windows.Forms.DateTimePicker dateTPdateEnd;
    }
}
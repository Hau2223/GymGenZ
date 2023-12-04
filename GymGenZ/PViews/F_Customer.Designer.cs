namespace GymGenZ.PViews
{
    partial class F_Customer
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
            this.tbFind = new System.Windows.Forms.TextBox();
            this.dataGripViewCustomer = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Schedule = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSign_Trainer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGripViewCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý khách hàng";
            // 
            // tbFind
            // 
            this.tbFind.BackColor = System.Drawing.Color.White;
            this.tbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbFind.Location = new System.Drawing.Point(789, 56);
            this.tbFind.Multiline = true;
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(258, 29);
            this.tbFind.TabIndex = 1;
            this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
            // 
            // dataGripViewCustomer
            // 
            this.dataGripViewCustomer.BackgroundColor = System.Drawing.Color.White;
            this.dataGripViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGripViewCustomer.Location = new System.Drawing.Point(13, 91);
            this.dataGripViewCustomer.Name = "dataGripViewCustomer";
            this.dataGripViewCustomer.RowHeadersWidth = 51;
            this.dataGripViewCustomer.Size = new System.Drawing.Size(1128, 398);
            this.dataGripViewCustomer.TabIndex = 3;
            this.dataGripViewCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGripViewCustomer_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.pictureBox1.Image = global::GymGenZ.Properties.Resources.Vector;
            this.pictureBox1.Location = new System.Drawing.Point(1053, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Schedule
            // 
            this.btn_Schedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.btn_Schedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Schedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Schedule.ForeColor = System.Drawing.Color.White;
            this.btn_Schedule.Location = new System.Drawing.Point(803, 504);
            this.btn_Schedule.Name = "btn_Schedule";
            this.btn_Schedule.Size = new System.Drawing.Size(172, 38);
            this.btn_Schedule.TabIndex = 5;
            this.btn_Schedule.Text = "Quản lí lịch tập";
            this.btn_Schedule.UseVisualStyleBackColor = false;
            this.btn_Schedule.Click += new System.EventHandler(this.btn_Schedule_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(981, 504);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 38);
            this.button2.TabIndex = 6;
            this.button2.Text = "Quản lý thông tin";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnSign_Trainer
            // 
            this.btnSign_Trainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(19)))), ((int)(((byte)(99)))));
            this.btnSign_Trainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSign_Trainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSign_Trainer.ForeColor = System.Drawing.Color.White;
            this.btnSign_Trainer.Location = new System.Drawing.Point(589, 504);
            this.btnSign_Trainer.Name = "btnSign_Trainer";
            this.btnSign_Trainer.Size = new System.Drawing.Size(208, 38);
            this.btnSign_Trainer.TabIndex = 7;
            this.btnSign_Trainer.Text = "Đăng ký huấn luyện viên";
            this.btnSign_Trainer.UseVisualStyleBackColor = false;
            this.btnSign_Trainer.Click += new System.EventHandler(this.btnSign_Trainer_Click);
            // 
            // F_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1153, 607);
            this.Controls.Add(this.btnSign_Trainer);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Schedule);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGripViewCustomer);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_Customer";
            this.Load += new System.EventHandler(this.F_Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGripViewCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.DataGridView dataGripViewCustomer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Schedule;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSign_Trainer;
    }
}
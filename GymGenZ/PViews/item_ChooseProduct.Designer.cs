namespace GymGenZ.PViews
{
    partial class item_ChooseProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(item_ChooseProduct));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNameProductChoose = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCountChoose = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbNameProductChoose
            // 
            this.lbNameProductChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameProductChoose.Location = new System.Drawing.Point(151, 18);
            this.lbNameProductChoose.Name = "lbNameProductChoose";
            this.lbNameProductChoose.Size = new System.Drawing.Size(463, 33);
            this.lbNameProductChoose.TabIndex = 1;
            this.lbNameProductChoose.Text = "Gold Standard 100% Whey 10lbs (4.6kg)";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbPrice.Location = new System.Drawing.Point(154, 55);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(93, 20);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "100.000vnđ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số lượng : ";
            // 
            // lbCountChoose
            // 
            this.lbCountChoose.AutoSize = true;
            this.lbCountChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountChoose.Location = new System.Drawing.Point(234, 84);
            this.lbCountChoose.Name = "lbCountChoose";
            this.lbCountChoose.Size = new System.Drawing.Size(21, 22);
            this.lbCountChoose.TabIndex = 4;
            this.lbCountChoose.Text = "2";
            // 
            // item_ChooseProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 139);
            this.Controls.Add(this.lbCountChoose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbNameProductChoose);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "item_ChooseProduct";
            this.Text = "item_ChooseProduct";
            this.Load += new System.EventHandler(this.item_ChooseProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNameProductChoose;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCountChoose;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GymGenZ.PViews
{
    public partial class F_Main : Form
    {
        private F_Customer f_Customer;
        private F_CustomerSchedule f_CustomerSchedule;

        private string receivedValue;

        public F_Main(string user)
        {
            InitializeComponent();
            receivedValue = user;
        }

        public Panel GetPanel()
        {
            return fMain;
        }

        //private void decentralization(string name)
        //{
        //    lbUser.Text = "Xin chào: " + name;
        //    using (SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT roll FROM Staff WHERE username = @name", conn))
        //    {
        //        da.SelectCommand.Parameters.AddWithValue("@name", name);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {
        //            string userRole = dt.Rows[0]["roll"].ToString();
        //            if (userRole == "0")
        //            {
        //            }
        //            else if (userRole == "1")
        //            {
        //                btnStaff.Visible = false;
        //                btnPakage.Visible = false;
        //                btnDiscout.Visible = false;
        //            }
        //            else if (userRole == "2")
        //            {
        //            }
        //            else
        //            {
        //                MessageBox.Show("Role not recognized.");
        //            }
        //        }
        //    }
        //}

        private void F_Main_Load(object sender, EventArgs e)
        {

        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            btnMain.BackColor = Color.White;
            btnMain.ForeColor = Color.FromArgb(26, 19, 99);

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnCustomer.BackColor = Color.FromArgb(26, 19, 99);
            btnCustomer.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnPakage.BackColor = Color.FromArgb(26, 19, 99);
            btnPakage.ForeColor = Color.White;

            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;



        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            btnAddCus.BackColor = Color.White;
            btnAddCus.ForeColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnCustomer.BackColor = Color.FromArgb(26, 19, 99);
            btnCustomer.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnPakage.BackColor = Color.FromArgb(26, 19, 99);
            btnPakage.ForeColor = Color.White;

            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;

            F_SignCustomer f = new F_SignCustomer();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            btnStaff.BackColor = Color.White;
            btnStaff.ForeColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnCustomer.BackColor = Color.FromArgb(26, 19, 99);
            btnCustomer.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnPakage.BackColor = Color.FromArgb(26, 19, 99);
            btnPakage.ForeColor = Color.White;

            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;

            F_ManagerStaff f = new F_ManagerStaff();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            btnCustomer.BackColor = Color.White;
            btnCustomer.ForeColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnPakage.BackColor = Color.FromArgb(26, 19, 99);
            btnPakage.ForeColor = Color.White;

            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;

            F_Customer f = new F_Customer();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            btnProduct.BackColor = Color.White;
            btnProduct.ForeColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnCustomer.BackColor = Color.FromArgb(26, 19, 99);
            btnCustomer.ForeColor = Color.White;

            btnPakage.BackColor = Color.FromArgb(26, 19, 99);
            btnPakage.ForeColor = Color.White;
            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;

            F_ManagerProduct f = new F_ManagerProduct();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btnDiscout_Click(object sender, EventArgs e)
        {
            btnDiscout.BackColor = Color.White;
            btnDiscout.ForeColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnCustomer.BackColor = Color.FromArgb(26, 19, 99);
            btnCustomer.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnPakage.BackColor = Color.FromArgb(26, 19, 99);
            btnPakage.ForeColor = Color.White;

            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;

            F_ManagerPromotion f = new F_ManagerPromotion();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btnPakage_Click(object sender, EventArgs e)
        {
            btnPakage.BackColor = Color.White;
            btnPakage.ForeColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;
        }

        private void btnPakage_Click_1(object sender, EventArgs e)
        {
            btnPakage.BackColor = Color.White;
            btnPakage.ForeColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;
            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_Login f = new F_Login();
            f.ShowDialog();
            this.Close();
        }

        private void F_Main_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            btnPakage.ForeColor = Color.White;
            btnPakage.BackColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;


            btnSales.ForeColor = Color.FromArgb(26, 19, 99);
            btnSales.BackColor = Color.White;


            F_SalesManager f = new F_SalesManager();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();

        }

        private void btnAddCus_Click_1(object sender, EventArgs e)
        {
            F_ManagerStaff f = new F_ManagerStaff();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btnSales_Click_1(object sender, EventArgs e)
        {
            btnPakage.ForeColor = Color.White;
            btnPakage.BackColor = Color.FromArgb(26, 19, 99);

            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;


            btnSales.ForeColor = Color.FromArgb(26, 19, 99);
            btnSales.BackColor = Color.White;


            F_SalesManager f = new F_SalesManager();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {




            btnMain.BackColor = Color.FromArgb(26, 19, 99);
            btnMain.ForeColor = Color.White;

            btnAddCus.BackColor = Color.FromArgb(26, 19, 99);
            btnAddCus.ForeColor = Color.White;

            btnStaff.BackColor = Color.FromArgb(26, 19, 99);
            btnStaff.ForeColor = Color.White;

            btnDiscout.BackColor = Color.FromArgb(26, 19, 99);
            btnDiscout.ForeColor = Color.White;

            btnProduct.BackColor = Color.FromArgb(26, 19, 99);
            btnProduct.ForeColor = Color.White;

            btnPakage.BackColor = Color.FromArgb(26, 19, 99);
            btnPakage.ForeColor = Color.White;

            btnCustomer.ForeColor = Color.White;
            btnCustomer.BackColor = Color.FromArgb(26, 19, 99);

            btnSales.BackColor = Color.FromArgb(26, 19, 99);
            btnSales.ForeColor = Color.White;

            F_CheckIn f = new F_CheckIn();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            fMain.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using GymGenZ.PControls;
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

namespace GymGenZ.PViews
{
    public partial class F_Login : Form
    {
        private CStaff _staff;

        public F_Login()
        {
            InitializeComponent();
            _staff = new CStaff("Data Source = C:\\Data\\GYM.db");
            
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = ipUsername.Text;
            string password = ipPassword.Text;

            bool isAuthenticated = _staff.Login(username, password);

            if (isAuthenticated)
            {
                this.Hide();
                string valueToSend = username;
                F_Main f = new F_Main(valueToSend);
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_ForgetPassword f = new F_ForgetPassword();
            f.ShowDialog();
            this.Close();
        }

        private void F_Login_Load(object sender, EventArgs e)
        {

        }
    }
}

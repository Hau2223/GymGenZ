using GymGenZ.PControls;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace GymGenZ.PViews
{
    public partial class F_ForgetPassword : Form
    {
        private CStaff _staff;

        public F_ForgetPassword()
        {
            InitializeComponent();
            _staff = new CStaff("Data Source=C:\\Data\\GYM.db");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string phoneNumber = txtNumberphone.Text.Trim();
            string newPassword = txtPassword.Text;
            string repeatPassword = txtRepeatPassword.Text;

            if(username == "" || phoneNumber == "" ||  repeatPassword == "" || newPassword == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (newPassword != repeatPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không khớp.");
                return;
            }

            if (_staff.CheckUSer(username, phoneNumber))
            {
                if (_staff.ChangePassword(username, newPassword))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    this.Hide();
                    F_Login f = new F_Login();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng kiểm tra lại thông tin.");
                }
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không đúng. Vui lòng kiểm tra lại.");
            }
        }

        private void F_ForgetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}

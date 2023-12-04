using GymGenZ.PControls;
using GymGenZ.PModels;
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
    public partial class F_SignCustomer : Form
    {
        private SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\data\\GYM.db");
        
        public F_SignCustomer()
        {
            InitializeComponent();
            getAllPackage();
        }

        private void getAllPackage()
        {
            try
            {
                CPackage packageManager = new CPackage("Data Source=C:\\data\\GYM.db");
                List<MPackage> packageInfoList = packageManager.getAllPakage();
                if (packageInfoList.Count > 0)
                {
                    cbPakage.DisplayMember = "name";
                    cbPakage.ValueMember = "id";
                    cbPakage.DataSource = packageInfoList;
                }
                else
                {
                    MessageBox.Show("Không có gói tập nào được tìm thấy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            CCustomer customerManager = new CCustomer("Data Source=C:\\data\\GYM.db");
            string name = tbName.Text;
            string phone = tbPhone.Text;
            string cccd = tbID.Text;
            string idPakage = cbPakage.SelectedValue.ToString();
            string gender = cbGender.SelectedItem.ToString();
            string address = tbAddress.Text;

            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                return;
            }

            if (!IsValidCCCD(cccd))
            {
                MessageBox.Show("CCCD không hợp lệ.");
                return;
            }

            bool result = customerManager.signCustomer(name, phone, cccd, idPakage, address, gender);

            if (result)
            {
                MessageBox.Show("Thêm khách hàng thành công.");
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại.");
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{10,}$");
        }

        private bool IsValidCCCD(string cccd)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^\d{12}$");
        }

        private void F_SignCustomer_Load(object sender, EventArgs e)
        {

        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

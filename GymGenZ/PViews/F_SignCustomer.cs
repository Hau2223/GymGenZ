using GymGenZ.PControls;
using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymGenZ.PViews
{
    public partial class F_SignCustomer : Form
    {
        private SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\data\\GYM.db");
        private int idMaxCus = 0;
        
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

     

        private F_Main FindOpenF_Main()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is F_Main fMain && !fMain.IsDisposed)
                {
                    return fMain;
                }
            }
            return null;
        }

        private bool validateNull()
        {
            if (tbAddress.Text == "" || tbName.Text == "" || tbPhone.Text == "" || tbID.Text == "" || cbGender.SelectedItem == null)
            {
                MessageBox.Show("vui lòng nhập đầy đủ thông tin.");
                return false;
            }else { return true; }
        }

        private bool validateCharacters(string phone, string cccd)
        {
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                return false;
            }
            else
            {
                if (!IsValidCCCD(cccd))
                {
                    MessageBox.Show("CCCD không hợp lệ.");
                    return false;
                }
                else
                {
                    return true;
                }
            }

           
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateNull() == false)
            {
                return;
            }

            string name = tbName.Text;
            string phone = tbPhone.Text;
            string cccd = tbID.Text;
            string idPakage = cbPakage.SelectedValue.ToString();
            string address = tbAddress.Text;
            string gender = cbGender.SelectedItem.ToString();

            if (validateCharacters(phone, cccd)  == false)
            {
                return;
            }

            F_Main currentFMain = FindOpenF_Main();

            if (currentFMain != null)
            {
                Panel fmainPanel = currentFMain.GetPanel();

                if (fmainPanel != null)
                {
                    F_PaymentPackgae f = new F_PaymentPackgae(name, phone, cccd, address, gender, idPakage);
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    fmainPanel.Controls.Add(f);
                    f.Show();
                    f.BringToFront();
                }
                else
                {
                    MessageBox.Show("Panel is null or not initialized in F_Main.");
                }
            }
            else
            {
                MessageBox.Show("F_Main is not open or disposed.");
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

        private void cbPakage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

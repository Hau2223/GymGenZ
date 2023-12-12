using GymGenZ.PControls;
using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GymGenZ.PViews
{
    public partial class F_PaymentPackgae : Form
    {
        CCustomer customerManager = new CCustomer("Data Source=C:\\data\\GYM.db");
        CPaymentPackage cPayment = new CPaymentPackage("Data Source=C:\\data\\GYM.db");


        string _name, _numberPhone, _CCCD, _address, _gender, _idPackage;
        DateTime currentDate = DateTime.Now;

        public F_PaymentPackgae()
        {
            InitializeComponent();
        }

      

        public F_PaymentPackgae(string name, string numberPhone, string CCCD, string address, string gender, string idPakage)
        {
            InitializeComponent();

            _name = name;
            _numberPhone = numberPhone;
            _CCCD = CCCD;
            _address = address;
            _gender = gender;
            _idPackage = idPakage;

            CPackage cPackage = new CPackage("Data Source=C:\\Data\\GYM.db");
            Tuple<int, string, int, int> packageInfo = cPackage.getPackage(idPakage);

            //Package
            string namePackage = packageInfo.Item2;
            int time = packageInfo.Item3;
            int pricePackage = packageInfo.Item4;
            DateTime expirationDate = currentDate.AddDays(time);


            tbName.Text = name;
            tbPhone.Text = numberPhone;
            tbID.Text = CCCD;
            tbAddress.Text = address;
            tbGender.Text = gender;
            tbStart.Text = currentDate.ToString();
            tbEnd.Text = expirationDate.ToString();
            tbPackage.Text = namePackage;
            tbPricePackage.Text = pricePackage.ToString();

            tbTotalPrice.Text = (pricePackage).ToString();
        }

        private string getMethodPayment()
        {
            string result = "";

            if (rdoDirect.Checked == true)
            {
                result = "Thanh toán trực tiếp";
            }
            else if (rdoCredit.Checked == true)
            {
                result = "Thanh toán qua thẻ";
            }
            else if (rdoMomo.Checked == true)
            {
                result = "Thanh toán qua ví điện tử";
            }
            else
            {
                result = "err";
            }

            return result;
        }


        private void F_Payment_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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

        private bool checkPaymentMethod(string method)
        {
            if(method == "err")
            {
                MessageBox.Show("Vui lòng chọn hình thức thanh toán!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(tbTotalPrice.Text);
            string paymentMethod = getMethodPayment();
            if(checkPaymentMethod(paymentMethod) == false)
            {
                return;
            }
            bool result = customerManager.signCustomer(_name, _numberPhone, _CCCD, int.Parse(_idPackage), _address, _gender, paymentMethod, amount);
            if (result)
            {
                DialogResult dialogResult = MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng ký huấn luyện viên?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int idCustomer = customerManager.getIdMaxCustomer();
                    F_Main currentFMain = FindOpenF_Main();

                    if (currentFMain != null)
                    {
                        Panel fmainPanel = currentFMain.GetPanel();

                        if (fmainPanel != null)
                        {
                            F_SignPT f = new F_SignPT(idCustomer.ToString());
                            f.TopLevel = false;
                            f.Dock = DockStyle.Fill;
                            fmainPanel.Controls.Add(f);
                            f.Show();
                            f.BringToFront();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi.");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    F_Main currentFMain = FindOpenF_Main();

                    if (currentFMain != null)
                    {
                        Panel fmainPanel = currentFMain.GetPanel();

                        if (fmainPanel != null)
                        {
                            F_SignCustomer f = new F_SignCustomer();
                            f.TopLevel = false;
                            f.Dock = DockStyle.Fill;
                            fmainPanel.Controls.Add(f);
                            f.Show();
                            f.BringToFront();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Đăng ký khách hàng thất bại!");
            }
        }
    }
}

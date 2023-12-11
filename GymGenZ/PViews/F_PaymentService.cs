using GymGenZ.PControls;
using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GymGenZ.PViews
{
    public partial class F_PaymentService : Form
    {
        private int _idCustomer;
        private int _idTrainer;
        private int _idService;
        private List<String> _checkDate;
        private string _shiftCode;
        private DateTime dateEnd;
        DateTime currentDate = DateTime.Now;
        

        CCustomer customerManager = new CCustomer("Data Source=C:\\data\\GYM.db");
        CPTrainerService serviceManager = new CPTrainerService("Data Source=C:\\data\\GYM.db");
        CStaff staffManager = new CStaff("Data Source=C:\\data\\GYM.db");
        public F_PaymentService(int idCustomer, int idTrainer, int idService, List<string> checkDate, string shiftCode)
        {
            InitializeComponent();
            _idCustomer = idCustomer;
            _idTrainer = idTrainer; 
            _idService = idService;
            _checkDate = checkDate;
            _shiftCode = shiftCode;
            loadData();
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

        private void loadData()
        {
            Tuple<int, string, string, string, string, string> customerInfo = customerManager.GetCustomerInfo(_idCustomer);
            DateTime endDate = DateTime.Parse(customerInfo.Item6);
            Tuple<int, string, int, int> serviceInfo = serviceManager.getServiceTrainer(_idService.ToString());
            int session = serviceInfo.Item3;
            int idCustomer = _idCustomer;
            int dayWithTrainer = (session / _checkDate.Count * 7);
            string nameService = serviceInfo.Item2;
            dateEnd = currentDate.AddDays(dayWithTrainer);

            tbNameCustomer.Text = customerInfo.Item2;
            tbNameTrainer.Text = staffManager.getNameStaff(_idTrainer);
            tbDateStart.Text = currentDate.ToString();
            tbDateEnd.Text = dateEnd.ToString();
            tbNameService.Text = nameService;
            tbTotalPrice.Text = serviceInfo.Item4.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void F_PaymentService_Load(object sender, EventArgs e)
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
                MessageBox.Show("Vui lòng chọn hình thức thanh toán!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            string paymentMethod = getMethodPayment();
            if(checkPaymentMethod(paymentMethod) == false)
            {
                return;
            }
            if(paymentMethod == "Thanh toán trực tiếp")
            {
                bool result = customerManager.SignPTrainer(_idCustomer.ToString(), _idTrainer.ToString(), _checkDate, _shiftCode, _idService, currentDate.ToString("yyyy-MM-dd"), dateEnd.ToString("yyyy-MM-dd"));
                if (result)
                {
                    bool resultPayment = customerManager.PaymentTrainer(_idCustomer, _idTrainer, _idService, paymentMethod);
                    if (resultPayment)
                    {
                        MessageBox.Show("Đăng ký huấn luyện viên thành công!!");
                        F_Main currentFMain = FindOpenF_Main();

                        if (currentFMain != null)
                        {
                            Panel fmainPanel = currentFMain.GetPanel();

                            if (fmainPanel != null)
                            {
                                F_Customer f = new F_Customer();
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
                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công!");
                };
            }
            else if(paymentMethod == "Thanh toán qua thẻ")
            {
                MessageBox.Show("Chức năng thanh toán đang tiến hành");
            }else if(paymentMethod == "Thanh toán qua thẻ điện tử")
            {
                MessageBox.Show("Chức năng thanh toán đang tiến hành");
            }

           
        }
    }
}

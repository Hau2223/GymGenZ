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

namespace GymGenZ.PViews
{
    public partial class F_Schedule : Form
    {
        private CCustomer _dataService;

        public F_Schedule()
        {
            InitializeComponent();
            _dataService = new CCustomer("Data Source=C:\\Data\\GYM.db");
            loadDataCustomer();

        }
        private void loadDataCustomer()
        {
            Tuple<int, string, string, string, string, string> customerInfo = _dataService.GetCustomerInfo(5);

            if (customerInfo != null)
            {
                int idCustomer = customerInfo.Item1;
                string nameCustomer = customerInfo.Item2;
                string packageName = customerInfo.Item3;
                string startDate = customerInfo.Item4;
                string endDate = customerInfo.Item5;
                string trainerName = customerInfo.Item6;
                tbID.Text = idCustomer.ToString();
                tbName.Text = nameCustomer.ToString();
                tbNamePakage.Text = packageName.ToString();
                tbStart.Text = startDate.ToString();
                tbEnd.Text = endDate.ToString();
                tbPT.Text = trainerName.ToString();   
            }
        }


            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void F_Schedule_Load(object sender, EventArgs e)
        {

        }
    }
}

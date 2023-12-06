using GymGenZ.PControls;
using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymGenZ.PViews
{
    public partial class F_SignPT : Form
    {
        private List<string> checkDateData;
        private string idStaff;
        private string idCus;
        DateTime currentDate = DateTime.Now;
        int checkCount = 0;
        int coutCBSession = 0;


        public F_SignPT(string idCustomer)
        {
            InitializeComponent();
            checkDateData = new List<string>();
            LoadDataGridView();
            idCus = idCustomer;
        }

        private bool checkDateTrainer(int datelife, int dateWithTrainer)
        {
            if(datelife - 7 > dateWithTrainer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            CCustomer customer = new CCustomer("Data Source=C:\\data\\GYM.db");
            Tuple<int, string, string, string, string, string> customerInfo = customer.GetCustomerInfo(int.Parse(idCus));
            DateTime endDate = DateTime.Parse(customerInfo.Item6);

            TimeSpan dayLife = endDate - currentDate;
            if (coutCBSession == 0 || checkCount == 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!");
                return;
            }
            int session = int.Parse(cbSession.SelectedItem.ToString());
            int dayWithTrainer = (session / checkCount * 7);

            bool resultCheckDate = checkDateTrainer(dayLife.Days, dayWithTrainer);
            if(resultCheckDate == true)
            {
                checkDateData = GetCheckedItems();
                foreach (string data in checkDateData)
                {
                    MessageBox.Show(data);
                }
                string shiftCode = checkRadioShiftCode();
                if(shiftCode == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin!");
                    return;
                }
                string idCustomer = idCus;
                int duration = session;

                CCustomer customerManager = new CCustomer("Data Source=C:\\data\\GYM.db");
                bool result = customerManager.SignPTrainer(idCustomer, idStaff, checkDateData, shiftCode, duration);

                if (result)
                {
                    MessageBox.Show("Đăng ký thành công!!");
                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công!");
                };
            }
            else
            {
                MessageBox.Show("Thời gian tập không hợp lệ!");
            }

            
        }

        private List<string> GetCheckedItems()
        {
            List<string> checkedItems = new List<string>();
            for (int i = 0; i < checkDate.Items.Count; i++)
            {
                if (checkDate.GetItemChecked(i))
                {
                    checkedItems.Add(checkDate.Items[i].ToString());
                }
            }

            return checkedItems;
        }

        private void LoadDataGridView()
        {
            string shiftCode = checkRadioShiftCode();
            dataStaff.DataSource = null;
            dataStaff.Rows.Clear();
            dataStaff.Columns.Clear();

            CStaff staffManager = new CStaff("Data Source=C:\\data\\GYM.db");
            List<MStaff> staffsList = new List<MStaff>();
            if (checkDateData.Count == 0)
            {
                staffsList.Clear();
                List<MStaff> cStaff = staffManager.ShowAvailableStaff("0", "0");
                staffsList.AddRange(cStaff);
            }
            else
            {
                foreach (string date in checkDateData)
                {
                    staffsList.Clear();
                    List<MStaff> cStaff = staffManager.ShowAvailableStaff(shiftCode, date);
                    staffsList.AddRange(cStaff);
                }
            }
            dataStaff.DataSource = staffsList;
        }


        private string checkRadioShiftCode()
        {
            string result = "";
            if (rdoC1.Checked)
            {
                result = "1";
            }
            else if (rdoC2.Checked)
            {
                result = "2";
            }
            else if (rdoC3.Checked)
            {
                result = "3";
            }
            else if (rdoC4.Checked)
            {
                result = "4";
            }
            else if (rdoC5.Checked)
            {
                result = "5";
            }
            else if (rdoC6.Checked)
            {
                result = "6";
            }
            else if (rdoC7.Checked)
            {
                result = "7";
            }
            else if (rdoC8.Checked)
            {
                result = "8";
            }

            return result;
        }

        private void checkDate_SelectedValueChanged(object sender, EventArgs e)
        {
            checkDateData = GetCheckedItems();

            LoadDataGridView();
        }

        private void checkDate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkCount = checkDate.CheckedItems.Count + 1;
            checkDate.ItemCheck -= checkDate_ItemCheck;
           
            if (e.NewValue == CheckState.Checked)
            {
                checkDateData.Add(checkDate.Items[e.Index].ToString());
            }
            else
            {
                checkDateData.Remove(checkDate.Items[e.Index].ToString());
            }
            checkDate.ItemCheck += checkDate_ItemCheck;
            LoadDataGridView();
        }

        private void rdoC1_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void rdoC2_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void rdoC3_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void rdoC4_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void rdoC5_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void rdoC6_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void rdoC7_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void rdoC8_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dataStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataStaff_SelectionChanged(object sender, EventArgs e)
        {
            if (dataStaff.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataStaff.SelectedRows[0];
                idStaff = selectedRow.Cells["StaffID"].Value.ToString();
            }
        }

        private void F_SignPT_Load(object sender, EventArgs e)
        {

        }

        private void cbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            coutCBSession += 1;
        }
    }
}

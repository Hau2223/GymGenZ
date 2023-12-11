using GymGenZ.PControls;
using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

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
        CCustomer customerManager = new CCustomer("Data Source=C:\\data\\GYM.db");
        CPTrainerService serviceManager = new CPTrainerService("Data Source=C:\\data\\GYM.db");


        public F_SignPT(string idCustomer)
        {
            InitializeComponent();
            checkDateData = new List<string>();
            LoadDataGridView();
            loadDataSession();
            idCus = idCustomer;
        }

        private void loadDataSession()
        {
            try
            {
                List<MPTrainerService> lstService = serviceManager.getAllPTrainerService();
                if (lstService.Count > 0)
                {
                    cbSession.DisplayMember = "name";
                    cbSession.ValueMember = "id";
                    cbSession.DataSource = lstService;
                }
                else
                {
                    MessageBox.Show("Không có gói service nào được tìm thấy!.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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

        private bool checkNull()
        {
            if (cbSession.SelectedItem == null || checkCount == 0 || checkRadioShiftCode() == "" || idStaff == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
        
            Tuple<int, string, string, string, string, string> customerInfo = customerManager.GetCustomerInfo(int.Parse(idCus));
            DateTime endDate = DateTime.Parse(customerInfo.Item6);
            lbName.Text = customerInfo.Item2;
            TimeSpan dayLife = endDate - currentDate;
            if (checkNull() == false)
            {
                return;
            }
            int idService = int.Parse(cbSession.SelectedValue.ToString());
            Tuple<int, string, int, int> serviceInfo = serviceManager.getServiceTrainer(idService.ToString());
            int session = serviceInfo.Item3;
            int dayWithTrainer = (session / checkCount * 7);

            bool resultCheckDate = checkDateTrainer(dayLife.Days, dayWithTrainer);
            if(resultCheckDate == true)
            {
                string shiftCode = checkRadioShiftCode();
                F_Main currentFMain = FindOpenF_Main();

                if (currentFMain != null)
                {
                    Panel fmainPanel = currentFMain.GetPanel();

                    if (fmainPanel != null)
                    {
                        F_PaymentService f = new F_PaymentService(int.Parse(idCus), int.Parse(idStaff), idService, checkDateData, shiftCode);
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
            else
            {
                MessageBox.Show("Thời gian tập không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

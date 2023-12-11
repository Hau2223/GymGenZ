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
    public partial class F_CheckIn : Form
    {



        private CCustomer _dataService;

        private List<MCustomer> _customers;
        private String idCustomer = null;
        public F_CheckIn()
        {
            InitializeComponent();
            _dataService = new CCustomer("Data Source=C:\\Data\\GYM.db");
            loadDataToGrid();
        }

        private void F_CheckIn_Load(object sender, EventArgs e)
        {

        }

        private void loadDataToGrid()
        {

            string searchText = tbFind.Text.Trim();
            _customers = _dataService.SearchCustomers(searchText);
            dataGripViewCustomer.DataSource = _customers;
           


        }

        private void dataGripViewCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGripViewCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGripViewCustomer.SelectedRows[0];
                idCustomer = selectedRow.Cells["CustomerID"].Value.ToString();
            }
        }

        private MCustomer selectedCustomer;

       
     

        private void dataGripViewCustomer_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGripViewCustomer.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGripViewCustomer.Rows[e.RowIndex];

                // Lưu thông tin khách hàng vào biến hoặc thuộc tính
                selectedCustomer = new MCustomer
                {
                    customerID = selectedRow.Cells["CustomerID"].Value.ToString(),
                    customerName = selectedRow.Cells["CustomerName"].Value.ToString(),
                    gender = selectedRow.Cells["Gender"].Value.ToString(),
                    CCCD = selectedRow.Cells["CCCD"].Value.ToString(),
                    phoneNumber = selectedRow.Cells["PhoneNumber"].Value.ToString(),
                    start = selectedRow.Cells["Start"].Value.ToString(),
                    end = selectedRow.Cells["End"].Value.ToString(),
                    soBuoiTap = selectedRow.Cells["SoBuoiTap"].Value.ToString(),
                    address = selectedRow.Cells["Address"].Value.ToString(),
                    packageName = selectedRow.Cells["PackageName"].Value.ToString()
                };

                // Đặt giá trị vào các TextBox
                tbIDKH.Text = selectedCustomer.customerID.ToString();
                tbName.Text = selectedCustomer.customerName;
                tbGender.Text = selectedCustomer.gender;
                tbCCCD.Text = selectedCustomer.CCCD;
                tbPhone.Text = selectedCustomer.phoneNumber;
                tbDayStart.Text = selectedCustomer.start;
                tbDayEnd.Text = selectedCustomer.end;
                tbSoBuoiTap.Text = selectedCustomer.soBuoiTap;
                tbAddress.Text = selectedCustomer.address;
                tbPakage.Text = selectedCustomer.packageName;
            }
        }

        private void btn_Schedule_Click(object sender, EventArgs e)
        {
            CCustomer customerManager = new CCustomer("Data Source=C:\\data\\GYM.db");
            string customerId = selectedCustomer.customerID;

            // Kiểm tra ngày kết thúc có định dạng đúng và không null
            if (DateTime.TryParse(selectedCustomer?.end, out DateTime endDate))
            {
                if (endDate < DateTime.Now)
                {
                    MessageBox.Show("Người dùng đã hết hạn gói tập!!!");
                }
                else
                {
                    MessageBox.Show("Check-in thành công");
                    int currentSoBuoiTap;

                    if (int.TryParse(selectedCustomer.soBuoiTap, out currentSoBuoiTap))
                    {
                        customerManager.UpdateSoBuoiTap(customerId, currentSoBuoiTap + 1);

                        loadDataToGrid();
                        tbSoBuoiTap.Text = (int.Parse(selectedCustomer.soBuoiTap) + 1).ToString();

                    }
                    else
                    {
                        MessageBox.Show("Giá trị số buổi tập không hợp lệ.");
                    }

                }
            }

            else
            {
                MessageBox.Show("Ngày kết thúc không hợp lệ.");
            }
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            loadDataToGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_customers == null && _customers.Count > 0)
            {
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}

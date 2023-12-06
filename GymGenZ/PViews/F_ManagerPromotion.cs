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
    public partial class F_ManagerPromotion : Form
    {
        private CDiscount _dataDiscount;
        private List<MDiscount> _discount;
        private String _idDiscount = null;
        public F_ManagerPromotion()
        {
            InitializeComponent();
            _dataDiscount = new CDiscount("Data Source = C:\\data\\GYM.db");
            this.Load += F_ManagerPromotion_Load;
            dtgvDiscount.SelectionChanged += dtgvDiscount_SelectionChanged;
        }

        private void F_ManagerPromotion_Load(object sender, EventArgs e)
        {
            loadDataToGrid();
        }

        private void dtgvDiscount_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvDiscount.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgvDiscount.SelectedRows[0];
                _idDiscount = selectedRow.Cells["ID"].Value.ToString();
                MDiscount selectedDiscount = _discount.FirstOrDefault(discount => discount.id == _idDiscount);
                if (selectedDiscount != null)
                {
                    tbIDPromotion.Text = selectedDiscount.id;
                    tbdateStart.Text = selectedDiscount.timeStart;
                    tbDateEnd.Text = selectedDiscount.timeEnd;
                    if( selectedDiscount.status == "1")
                    {
                        rdoActivePromotion.Checked = true;
                    }
                    else
                    {
                        rdoExpiredPromotion.Checked = true;
                    }
                }
            }
        }
        private void loadDataToGrid()
        {
            string searchText = tbFindDiscount.Text.Trim();
            _discount = _dataDiscount.SearchDiscount(searchText);
            dtgvDiscount.DataSource = _discount;

        }

        private void ptbFindPromotion_Click(object sender, EventArgs e)
        {
            loadDataToGrid();
        }

        private void btnAddPromotion_Click(object sender, EventArgs e)
        {
            MDiscount newDiscount = new MDiscount
            {
                id = tbIDPromotion.Text,
                timeStart = tbdateStart.Text,
                timeEnd = tbDateEnd.Text,
                status = rdoActivePromotion.Checked ? "1" : "0",
            };
            if (string.IsNullOrWhiteSpace(newDiscount.id) || string.IsNullOrWhiteSpace(newDiscount.timeStart) ||
                string.IsNullOrWhiteSpace(newDiscount.timeEnd) )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_dataDiscount.CheckIDDiscount(newDiscount.id))
            {
                MessageBox.Show("Mã khuyến mãi đã tồn tại!!!\nVui lòng nhập lại Mã khuyến mãi khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Gọi phương thức để thêm nhân viên mới
                bool addedSuccessfully = _dataDiscount.AddDiscount(newDiscount);
                if (addedSuccessfully)
                {
                    MessageBox.Show("Thêm khuyến mãi thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataToGrid();
                }
                else
                {
                    // Xử lý khi thêm không thành công
                    MessageBox.Show("Không thể thêm khuyến mãi.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnUpdatePromotion_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin khuyến mãi này không?", "Some Title", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                MDiscount updatedDiscount = new MDiscount
                {
                    id = tbIDPromotion.Text,
                    timeStart = tbdateStart.Text,
                    timeEnd = tbDateEnd.Text,
                    status = rdoActivePromotion.Checked ? "1" : "0",
                };
                if (!string.IsNullOrEmpty(_idDiscount))
                {
                    bool updatedSuccessfully = _dataDiscount.UpdateDiscount(updatedDiscount);
                    if (updatedSuccessfully)
                    {
                        MessageBox.Show("Cập nhật thông tin khuyến mãi thành công!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin khuyến mãi.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật từ danh sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }

        private void btnDeletePromotion_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(_idDiscount))
                {
                    bool deletedSuccessfully = _dataDiscount.DeleteDiscount(_idDiscount);
                    if (deletedSuccessfully)
                    {
                        MessageBox.Show("Xóa khuyến mãi thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataToGrid();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khuyến mãi.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa từ danh sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void ClearFields()
        {
            tbIDPromotion.Text = string.Empty;
            tbdateStart.Text = string.Empty;
            tbDateEnd.Text = string.Empty;
            rdoActivePromotion.Checked = false;
            rdoExpiredPromotion.Checked = false;
        }

    }
}

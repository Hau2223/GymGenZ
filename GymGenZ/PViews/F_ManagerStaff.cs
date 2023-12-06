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
    public partial class F_ManagerStaff : Form
    {
        private CStaff _dataStaff;
        private List<MStaff> _staff;
        private String _idStaff = null;
        public F_ManagerStaff()
        {
            InitializeComponent();
            _dataStaff = new CStaff("Data Source = C:\\data\\GYM.db");
            this.Load += F_ManagerStaff_Load;
            dtgvStaff.SelectionChanged += dtgvStaff_SelectionChanged;
            dtgvStaff.DataBindingComplete += dtgvStaff_DataBindingComplete;
        }
        private void loadDataToGrid()
        {
            string searchText = tbFindStaff.Text.Trim();
            _staff = _dataStaff.SearchStaff(searchText);
            dtgvStaff.DataSource = _staff;
            
        }
        private void F_ManagerStaff_Load(object sender, EventArgs e)
        {
            loadDataToGrid();
        }
        private void dtgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvStaff.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgvStaff.SelectedRows[0];
                _idStaff = selectedRow.Cells["StaffID"].Value.ToString(); 
                //Đỗ dữ liệu lên label
                MStaff selectedStaff = _staff.FirstOrDefault(staff => staff.staffID == _idStaff);
                if (selectedStaff != null)
                {
                    tbIDStaff.Text = selectedStaff.staffID;
                    tbFNameStaff.Text = selectedStaff.fullname;
                    tbSTDStaff.Text = selectedStaff.numberPhone;
                    tbAccStaff.Text = selectedStaff.username;
                    tbRollStaff.Text = selectedStaff.roll;
                    tbCCCDStaff.Text = selectedStaff.idCard;
                    if(selectedStaff.gender == "Nam")
                    {
                        cbGDMaleStaff.Checked = true;
                        cbGDFemaleStaff.Checked = false;
                    }
                    else
                    {
                        cbGDMaleStaff.Checked = false;
                        cbGDFemaleStaff.Checked = true;
                    }
                    DateTime birthDate;
                    if (DateTime.TryParseExact(selectedStaff.birth, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out birthDate))
                    {
                        dtpkBirthStaff.Format = DateTimePickerFormat.Custom;
                        dtpkBirthStaff.CustomFormat = "dd/MM/yyyy";
                        dtpkBirthStaff.Value = birthDate;
                    }
                    tbAddressStaff.Text = selectedStaff.address;
                }
            }
        }
        private void ptbFindStaff_Click(object sender, EventArgs e)
        {
            loadDataToGrid();
        }

        private void dtgvStaff_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgvStaff.Columns["password"].Visible = false;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            MStaff newStaff = new MStaff
            {
                username = tbAccStaff.Text,
                password = tbPassStaff.Text,
                roll = tbRollStaff.Text,
                fullname = tbFNameStaff.Text,
                numberPhone = tbSTDStaff.Text,
                idCard = tbCCCDStaff.Text,
                gender = cbGDMaleStaff.Checked ? "Nam" : "Nữ",
                birth = dtpkBirthStaff.Value.ToString("yyyy-MM-dd"),
                address = tbAddressStaff.Text
            };
            if (string.IsNullOrWhiteSpace(newStaff.username) || string.IsNullOrWhiteSpace(newStaff.password) ||
                string.IsNullOrWhiteSpace(newStaff.roll) || string.IsNullOrWhiteSpace(newStaff.fullname) ||
                string.IsNullOrWhiteSpace(newStaff.numberPhone) || string.IsNullOrWhiteSpace(newStaff.idCard))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (newStaff.idCard.Length != 12)
            {
                MessageBox.Show("Số CCCD không hợp lệ.\nVui lòng nhập lại số CCCD!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (newStaff.numberPhone.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ.\nVui lòng nhập số lại điện thoại!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_dataStaff.CheckUsername(newStaff.username))
            {
                MessageBox.Show("Username đã tồn tại!!!\nVui lòng nhập lại Username khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_dataStaff.CheckPhoneNumber(newStaff.numberPhone))
            {
                MessageBox.Show("Số điện thoại đã tồn tại!!!\nVui lòng nhập lại SĐT khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (_dataStaff.CheckIDCard(newStaff.idCard)){
                MessageBox.Show("Số CCCD đã tồn tại!!!\nVui lòng nhập lại CCCD khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (newStaff.password.Length < 6 || !newStaff.password.Any(char.IsUpper) || !newStaff.password.Any(char.IsDigit))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự, một ký tự viết hoa và một số.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                // Gọi phương thức để thêm nhân viên mới
                bool addedSuccessfully = _dataStaff.AddStaff(newStaff);
                if (addedSuccessfully){
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataToGrid();
                    tbPassStaff.Text = string.Empty;
                }
                else{
                    // Xử lý khi thêm không thành công
                    MessageBox.Show("Không thể thêm nhân viên.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
        }

        private void btn_UpdateStaff_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên này hay không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MStaff updatedStaff = new MStaff
                {
                    staffID = tbIDStaff.Text,
                    username = tbAccStaff.Text,
                    roll = tbRollStaff.Text,
                    fullname = tbFNameStaff.Text,
                    numberPhone = tbSTDStaff.Text,
                    idCard = tbCCCDStaff.Text,
                    gender = cbGDMaleStaff.Checked ? "Nam" : "Nữ",
                    birth = dtpkBirthStaff.Value.ToString("yyyy-MM-dd"),
                    address = tbAddressStaff.Text
                };
                if (!string.IsNullOrEmpty(_idStaff))
                {
                    bool updatedSuccessfully = _dataStaff.UpdateStaff(updatedStaff);
                    if (updatedSuccessfully)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin nhân viên.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật từ danh sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(_idStaff))
                {
                    bool deletedSuccessfully = _dataStaff.DeleteStaff(_idStaff);
                    if (deletedSuccessfully)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataToGrid();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhân viên.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa từ danh sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }
        private void ClearFields()
        {
            tbIDStaff.Text = string.Empty;
            tbFNameStaff.Text = string.Empty;
            tbSTDStaff.Text = string.Empty;
            tbAccStaff.Text = string.Empty;
            tbRollStaff.Text = string.Empty;
            tbCCCDStaff.Text = string.Empty;
            tbPassStaff.Text = string.Empty;
        }

        private void cbGDMaleStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGDMaleStaff.Checked)
            {
                cbGDFemaleStaff.Checked = false;
            }

        }
        private void cbGDFemaleStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGDFemaleStaff.Checked)
            {
                cbGDMaleStaff.Checked = false;
            }
        }
    }
}

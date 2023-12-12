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
            /*tbRollStaff.TextChanged += tbRollStaff_TextChanged;*/
        }
        private void loadDataToGrid()
        {
            _staff = _dataStaff.LoadAllStaff();
            dtgvStaff.DataSource = _staff;
        }
        private void searchStaff()
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
                    if (selectedStaff.roll == "0")
                    {
                        rdoRollAdmin.Checked = true;
                    }else if (selectedStaff.roll == "1")
                    {
                        rdoRollStaff.Checked = true;
                    }
                    else
                    {
                        rdoRollHLV.Checked= true;
                    }

                }
            }
        }
        private void ptbFindStaff_Click(object sender, EventArgs e)
        {
            searchStaff();
        }

        private void dtgvStaff_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgvStaff.Columns["password"].Visible = false;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            bool isHLV = rdoRollHLV.Checked;

            if (isHLV)
            {

                MStaff newStaff = new MStaff
                {
                    username = tbAccStaff.Text,
                    roll = "2",
                    fullname = tbFNameStaff.Text,
                    numberPhone = tbSTDStaff.Text,
                    idCard = tbCCCDStaff.Text,
                    gender = cbGDMaleStaff.Checked ? "Nam" : "Nữ",
                    birth = dtpkBirthStaff.Value.ToString("yyyy-MM-dd"),
                    address = tbAddressStaff.Text
                };
                if ( string.IsNullOrWhiteSpace(newStaff.roll) || string.IsNullOrWhiteSpace(newStaff.fullname) ||
                   string.IsNullOrWhiteSpace(newStaff.numberPhone) || string.IsNullOrWhiteSpace(newStaff.idCard))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (newStaff.idCard.Length != 12)
                {
                    MessageBox.Show("Số CCCD không hợp lệ.\nVui lòng nhập lại số CCCD!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (newStaff.numberPhone.Length != 10)
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
                else if (_dataStaff.CheckIDCard(newStaff.idCard))
                {
                    MessageBox.Show("Số CCCD đã tồn tại!!!\nVui lòng nhập lại CCCD khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool addedSuccessfully = _dataStaff.AddStaff(newStaff);
                    if (addedSuccessfully)
                    {
                        MessageBox.Show("Thêm nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataToGrid();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm nhân viên.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } 
                   
            }
            else
            {

                MStaff newStaff = new MStaff
                {
                    username = tbAccStaff.Text,
                    password = tbPassStaff.Text, 
                    roll = (rdoRollAdmin.Checked) ? "0" : "1",
                    fullname = tbFNameStaff.Text,
                    numberPhone = tbSTDStaff.Text,
                    idCard = tbCCCDStaff.Text,
                    gender = cbGDMaleStaff.Checked ? "Nam" : "Nữ",
                    birth = dtpkBirthStaff.Value.ToString("yyyy-MM-dd"),
                    address = tbAddressStaff.Text
                };

                if (string.IsNullOrWhiteSpace(newStaff.username)|| string.IsNullOrWhiteSpace(newStaff.password) ||
                    string.IsNullOrWhiteSpace(newStaff.roll) || string.IsNullOrWhiteSpace(newStaff.fullname) ||
                    string.IsNullOrWhiteSpace(newStaff.numberPhone) || string.IsNullOrWhiteSpace(newStaff.idCard))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (newStaff.idCard.Length != 12)
                {
                    MessageBox.Show("Số CCCD không hợp lệ.\nVui lòng nhập lại số CCCD!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (newStaff.numberPhone.Length != 10)
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
                else if (_dataStaff.CheckIDCard(newStaff.idCard))
                {
                    MessageBox.Show("Số CCCD đã tồn tại!!!\nVui lòng nhập lại CCCD khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (newStaff.password.Length < 6 || !newStaff.password.Any(char.IsUpper) || !newStaff.password.Any(char.IsDigit))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự, một ký tự viết hoa và một số.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Gọi phương thức để thêm nhân viên mới
                    bool addedSuccessfully = _dataStaff.AddStaff(newStaff);
                    if (addedSuccessfully)
                    {
                        MessageBox.Show("Thêm nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataToGrid();
                        ClearFields();
                    }
                    else
                    {
                        // Xử lý khi thêm không thành công
                        MessageBox.Show("Không thể thêm nhân viên.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btn_UpdateStaff_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên này hay không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool isHLV = rdoRollHLV.Checked;

                if (isHLV)
                {
                    MStaff updatedStaff = new MStaff
                    {
                        username = tbAccStaff.Text,
                        roll = "2",
                        fullname = tbFNameStaff.Text,
                        numberPhone = tbSTDStaff.Text,
                        idCard = tbCCCDStaff.Text,
                        gender = cbGDMaleStaff.Checked ? "Nam" : "Nữ",
                        birth = dtpkBirthStaff.Value.ToString("yyyy-MM-dd"),
                        address = tbAddressStaff.Text
                    };
                    if ( string.IsNullOrWhiteSpace(updatedStaff.roll) || string.IsNullOrWhiteSpace(updatedStaff.fullname) ||
                        string.IsNullOrWhiteSpace(updatedStaff.numberPhone) || string.IsNullOrWhiteSpace(updatedStaff.idCard))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (updatedStaff.idCard.Length != 12)
                    {
                        MessageBox.Show("Số CCCD không hợp lệ.\nVui lòng nhập lại số CCCD!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (updatedStaff.numberPhone.Length != 10)
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ.\nVui lòng nhập số lại điện thoại!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (_dataStaff.CheckUsername(updatedStaff.username))
                    {
                        MessageBox.Show("Username đã tồn tại!!!\nVui lòng nhập lại Username khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (_dataStaff.CheckPhoneNumber(updatedStaff.numberPhone))
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại!!!\nVui lòng nhập lại SĐT khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (_dataStaff.CheckIDCard(updatedStaff.idCard))
                    {
                        MessageBox.Show("Số CCCD đã tồn tại!!!\nVui lòng nhập lại CCCD khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bool updatedSuccessfully = _dataStaff.UpdateStaff(updatedStaff);
                        if (updatedSuccessfully)
                        {
                            MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDataToGrid();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật thông tin nhân viên.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MStaff updatedStaff = new MStaff
                    {
                        staffID = tbIDStaff.Text,
                        username = tbAccStaff.Text,
                        password = tbPassStaff.Text,
                        roll = (rdoRollAdmin.Checked) ? "0" : "1",
                        fullname = tbFNameStaff.Text,
                        numberPhone = tbSTDStaff.Text,
                        idCard = tbCCCDStaff.Text,
                        gender = cbGDMaleStaff.Checked ? "Nam" : "Nữ",
                        birth = dtpkBirthStaff.Value.ToString("yyyy-MM-dd"),
                        address = tbAddressStaff.Text
                       
                    };
                    if (!string.IsNullOrEmpty(_idStaff))
                    {
                        if (string.IsNullOrWhiteSpace(updatedStaff.username) || string.IsNullOrWhiteSpace(updatedStaff.password) || 
                            string.IsNullOrWhiteSpace(updatedStaff.roll) || string.IsNullOrWhiteSpace(updatedStaff.fullname) ||
                            string.IsNullOrWhiteSpace(updatedStaff.numberPhone) || string.IsNullOrWhiteSpace(updatedStaff.idCard))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (updatedStaff.idCard.Length != 12)
                        {
                            MessageBox.Show("Số CCCD không hợp lệ.\nVui lòng nhập lại số CCCD!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (updatedStaff.numberPhone.Length != 10)
                        {
                            MessageBox.Show("Số điện thoại không hợp lệ.\nVui lòng nhập số lại điện thoại!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (_dataStaff.CheckUsername(updatedStaff.username))
                        {
                            MessageBox.Show("Username đã tồn tại!!!\nVui lòng nhập lại Username khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (_dataStaff.CheckPhoneNumber(updatedStaff.numberPhone))
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại!!!\nVui lòng nhập lại SĐT khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (_dataStaff.CheckIDCard(updatedStaff.idCard))
                        {
                            MessageBox.Show("Số CCCD đã tồn tại!!!\nVui lòng nhập lại CCCD khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (updatedStaff.password.Length < 6 || !updatedStaff.password.Any(char.IsUpper) || !updatedStaff.password.Any(char.IsDigit))
                        {
                            MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự, một ký tự viết hoa và một số.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            bool updatedSuccessfully = _dataStaff.UpdateStaff(updatedStaff);
                            if (updatedSuccessfully)
                            {
                                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadDataToGrid();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Không thể cập nhật thông tin nhân viên.\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật từ danh sách!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
            tbCCCDStaff.Text = string.Empty;
            tbPassStaff.Text = string.Empty;
            rdoRollHLV.Checked = false;
            rdoRollAdmin.Checked = false;
            rdoRollStaff.Checked = false;
            cbGDFemaleStaff.Checked = false;
            cbGDMaleStaff.Checked = false;
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

        private void dtgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rdoRollAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRollAdmin.Checked || rdoRollStaff.Checked)
            {
                tbAccStaff.Enabled = true;
                tbPassStaff.Enabled = true;
            }
        }

        private void rdoRollHLV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRollHLV.Checked)
            {
                tbAccStaff.Enabled = false;
                tbPassStaff.Enabled = false;
                tbAccStaff.Text = string.Empty;
                tbPassStaff.Text = string.Empty;
            }
        }

        private void tbFindStaff_TextChanged(object sender, EventArgs e)
        {
            searchStaff();
        }
    }
}

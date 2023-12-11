using GymGenZ.PControls;
using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymGenZ.PViews
{
    public partial class F_ManagerProduct : Form
    {
        string byteImage = "";
        List<MProduct> productList;
        CProduct productManager = new CProduct("Data Source=C:\\data\\GYM.db");
        string idProduct;


        public F_ManagerProduct()
        {
            InitializeComponent();
            getAllCateProduct();
            loadDataToGrid();
            dataProduct.DataBindingComplete += dataProduct_DataBindingComplete;
        }

        private void F_ManagerProduct_Load(object sender, EventArgs e)
        {

        }

        private void loadDataToGrid()
        {
            string searchText = tbFind.Text.Trim();
            productList = productManager.getAllProduct(searchText);
            dataProduct.DataSource = productList;
        }

        private byte[] converImgToByte()
        {
            FileStream fs;
            fs = new FileStream(lbGetLocationImage.Text, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

        private Image ByteToImg(string byteString)
        {
            if(byteString != null)
            {
                byte[] imgBytes = Convert.FromBase64String(byteString);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
            else
            {
                MessageBox.Show("err convert img");
                return null;
            }
           
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                lbGetLocationImage.Text = openFile.FileName;
                byteImage = Convert.ToBase64String(converImgToByte());
                Image image = ByteToImg(byteImage);

                if (image != null)
                {
                    picImageP.Image = image;
                }
            }
        }

        private void getAllCateProduct()
        {
            try
            {
                
                List<MCateProduct> cateProductList = productManager.getAllCateProduct();
                if (cateProductList.Count > 0)
                {
                    cbCate.DisplayMember = "name";
                    cbCate.ValueMember = "id";
                    cbCate.DataSource = cateProductList;
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

        private bool checkNull()
        {
            if (tbNameP.Text == "" || tbPriceP.Text == "" || tbTotalP.Text == "" || cbCate.SelectedValue.ToString() == "" || picImageP.Image == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool check_int()
        {
            if (int.TryParse(tbPriceP.Text, out int result))
            {
                if (int.TryParse(tbTotalP.Text, out int resultTotal))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Số lượng kho phải là một số nguyên!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Giá phải là một số nguyên!");
                return false;
            }
        }

        private bool checkItemSelected()
        {
            if (tbIdP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool check = checkNull();
            if(check == false)
            {
                return;
            }
            bool checkint = check_int();
            if(checkint == false)
            {
                return;
            }

            MProduct newProduct = new MProduct
            {
                nameProduct = tbNameP.Text,
                count = int.Parse(tbTotalP.Text),
                price = int.Parse(tbTotalP.Text),
                idCateProduct = int.Parse(cbCate.SelectedValue.ToString()),
                image = byteImage
            };

            MessageBox.Show(newProduct.idCateProduct.ToString());

            bool resultAddProduct = productManager.addProduct(newProduct);
            if (resultAddProduct)
            {
                clearItem();
                loadDataToGrid();
                MessageBox.Show("Thêm sản phẩm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!");
            }

        }

        private void dataProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dataProduct.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataProduct.SelectedRows[0];
                idProduct = selectedRow.Cells["id"].Value.ToString();
                MProduct selectedProduct = productList.FirstOrDefault(product => product.id.ToString() == idProduct);
                if (selectedProduct != null)
                {
                    tbIdP.Text = selectedProduct.id.ToString();
                    tbNameP.Text = selectedProduct.nameProduct;
                    tbPriceP.Text = selectedProduct.price.ToString();
                    tbTotalP.Text = selectedProduct.count.ToString();
                    byteImage = selectedProduct.image;
                    Image image = ByteToImg(selectedProduct.image);

                    if (image != null)
                    {
                        picImageP.Image = image;
                    }

                }
            }
        }

        private void dataProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearItem()
        {
            tbIdP.Text = "";
            tbNameP.Text = "";
            tbPriceP.Text = "";
            tbTotalP.Text = "";
            cbCate.SelectedIndex = 0;
            picImageP.Image = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            bool checkID = checkItemSelected();
            if(checkID == false)
            {
                return;
            }
            bool check = checkNull();
            if (check == false)
            {
                return;
            }
            bool checkint = check_int();
            if (checkint == false)
            {
                return;
            }
            MProduct product = new MProduct
            {
                id = int.Parse(tbIdP.Text),
                nameProduct = tbNameP.Text,
                count = int.Parse(tbTotalP.Text),
                price = int.Parse(tbPriceP.Text),
                idCateProduct = int.Parse(cbCate.SelectedValue.ToString()),
                image = byteImage
            };

            DialogResult dialogResult = MessageBox.Show("bạn có chắc chắn muốn cập nhật sản phẩm?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = productManager.updateProduct(product);
                if (result)
                {
                    clearItem();
                    loadDataToGrid();
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại!");
                }
            }
            else if(dialogResult == DialogResult.No)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           checkItemSelected();

            DialogResult dialogResult = MessageBox.Show("bạn có chắc chắn muốn xóa sản phẩm?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = productManager.deleteProduct(tbIdP.Text);
                if (result)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    loadDataToGrid();
                    clearItem();
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }

           
        }

        private void dataProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataProduct.Columns["image"].Visible = false;
        }
    }
}

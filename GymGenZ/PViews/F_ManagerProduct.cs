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


        public F_ManagerProduct()
        {
            InitializeComponent();
            getAllCateProduct();
            loadDataToGrid();
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
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbNameP.Text == "" || tbPriceP.Text == "" || tbTotalP.Text == "" || cbCate.SelectedValue.ToString() == "" || lbGetLocationImage.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!");
                return;
            }

            if(int.TryParse(tbPriceP.Text, out int result))
            {

            }
            else
            {
                MessageBox.Show("Giá phải là một số nguyên!");
                return;
            }

            if (int.TryParse(tbTotalP.Text, out int resultTotal))
            {

            }
            else
            {
                MessageBox.Show("Số lượng kho phải là một số nguyên!");
                return;
            }

            //CProduct productManager = new CProduct("Data Source=C:\\data\\GYM.db");

            MProduct newProduct = new MProduct
            {
                nameProduct = tbNameP.Text,
                count = int.Parse(tbTotalP.Text),
                price = int.Parse(tbTotalP.Text),
                idCateProduct = int.Parse(cbCate.SelectedValue.ToString()),
                image = byteImage
            };

            bool resultAddProduct = productManager.addProduct(newProduct);
            if(resultAddProduct)
            {
                MessageBox.Show("Thêm sản phẩm thành công!");
                tbNameP.Text = "";
                tbPriceP.Text = "";
                tbTotalP.Text = "";
                cbCate.SelectedIndex = 0;
                picImageP.Image = null;
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!");
            }
           

            
        }
    }
}

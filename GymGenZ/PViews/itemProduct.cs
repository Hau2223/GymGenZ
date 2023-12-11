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
using System.Xml.Linq;

namespace GymGenZ.PViews
{
    public partial class itemProduct : Form
    {


        private CProduct _dataService;
        private List<MProduct> _products;
        private List<MProduct> _productss;

        string _name;
        int _price;
        int _idProduct;
        int _idCateProduct;
        public itemProduct()
        {
            InitializeComponent();
        }

        public itemProduct(int idProduct, string productName, int productPrice, int cateProduct)
        {
            InitializeComponent();
            _idProduct = idProduct;
            _name = productName;
            _price = productPrice;
            _idCateProduct = cateProduct;
            lbNameProduct.Text = _name;
            lbPrice.Text = _price.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            itemClick();
        }

        private void lbNameProduct_Click(object sender, EventArgs e)
        {
            itemClick();
        }

        private void lbPrice_Click(object sender, EventArgs e)
        {
            itemClick();
        }




        private void itemClick()
        {
            MessageBox.Show(_idProduct.ToString());
            MessageBox.Show(_name.ToString());
            MessageBox.Show(_price.ToString());
            MessageBox.Show(_idCateProduct.ToString());

            foreach (MProduct product in _products)
            {
                item_ChooseProduct item_ChooseProduct = new item_ChooseProduct(product.id, product.nameProduct, product.price, product.count);

                if (product.id == _idProduct)
                {
                    // Gọi phương thức AddProductToPanel từ F_SalesManager
                    ((F_SalesManager)this.ParentForm).AddProductToPanel(item_ChooseProduct);
                }
            }
        }


    }
}

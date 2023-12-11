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
    public partial class F_SalesManager : Form
    {



        private CProduct _dataService;
        private List<MProduct> _products;
        public F_SalesManager()
        {
            InitializeComponent();
            _dataService = new CProduct("Data Source=C:\\Data\\GYM.db");
            loadDataToGrid();
        }

        private void loadDataToGrid()
        {
            string searchText = tbFind.Text.Trim();
            _products = _dataService.SearchCustomers(searchText);
            dataGripViewCustomer.DataSource = _products;





        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            tbFind.Clear();
            SearchProduct();
        }
  
        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void SearchProduct()
        {
            pnDanhSach.Controls.Clear();
            string searchText = tbFind.Text.Trim();
            _products = _dataService.SearchCustomers(searchText);
            Console.WriteLine(_products.Count);
            
            foreach (MProduct product in _products)
            {

                itemProduct itemProduct = new itemProduct(product.id, product.nameProduct, product.price, product.count);

    
                itemProduct.TopLevel = false;


                pnDanhSach.Controls.Add(itemProduct);
                itemProduct.Show();
            }
            
            dataGripViewCustomer.DataSource = _products;
    



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchProduct();
        }

        private void F_SalesManager_Load(object sender, EventArgs e)
        {

        }

        private void btnWheyProtein_Click(object sender, EventArgs e)
        {
        
            pnDanhSach.Controls.Clear();

            Console.WriteLine(_products.Count);

            foreach (MProduct product in _products)
            {

                itemProduct itemProduct = new itemProduct(product.id, product.nameProduct, product.price, product.idCateProduct);


                if (product.idCateProduct == 1) {
                    itemProduct.TopLevel = false;


                    pnDanhSach.Controls.Add(itemProduct);
                    itemProduct.Show();

                }

                
            }

          
        }

        private void btnNuocDetox_Click(object sender, EventArgs e)
        {
            pnDanhSach.Controls.Clear();

            Console.WriteLine(_products.Count);

            foreach (MProduct product in _products)
            {

                itemProduct itemProduct = new itemProduct(product.id, product.nameProduct, product.price, product.idCateProduct);


                if (product.idCateProduct == 2)
                {
                    itemProduct.TopLevel = false;


                    pnDanhSach.Controls.Add(itemProduct);
                    itemProduct.Show();

                }


            }
        }

        private void btnNuocGiaKhat_Click(object sender, EventArgs e)
        {
            tbFind.Clear();
            pnDanhSach.Controls.Clear();

            Console.WriteLine(_products.Count);

            foreach (MProduct product in _products)
            {

                itemProduct itemProduct = new itemProduct(product.id, product.nameProduct, product.price, product.idCateProduct);


                if (product.idCateProduct == 3)
                {
                    itemProduct.TopLevel = false;


                    pnDanhSach.Controls.Add(itemProduct);
                    itemProduct.Show();

                }


            }

        }

        private void btnSpKhac_Click(object sender, EventArgs e)
        {
            tbFind.Clear();
            pnDanhSach.Controls.Clear();

            Console.WriteLine(_products.Count);

            foreach (MProduct product in _products)
            {

                itemProduct itemProduct = new itemProduct(product.id, product.nameProduct, product.price, product.idCateProduct);


                if (product.idCateProduct == 4)
                {
                    itemProduct.TopLevel = false;


                    pnDanhSach.Controls.Add(itemProduct);
                    itemProduct.Show();

                }


            }
        }

        internal void AddProductToPanel(item_ChooseProduct item_ChooseProduct)
        {
            // Kiểm tra xem Panel có được khởi tạo chưa
            if (pnDanhSach != null)
            {
                // Thêm UserControl vào Panel
                pnDanhSach.Controls.Add(item_ChooseProduct);
                // Hiển thị UserControl
                item_ChooseProduct.Show();
            }
        }
    }
}

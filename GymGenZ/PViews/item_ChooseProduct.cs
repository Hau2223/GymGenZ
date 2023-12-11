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
    public partial class item_ChooseProduct : Form
    {


        string _name;
        int _price;
        int _idProduct;
        int _count;
        public item_ChooseProduct()
        {
            InitializeComponent();
        }



        public item_ChooseProduct(int idProduct, string productName, int productPrice, int count)
        {
            InitializeComponent();
            _name = productName;
            _price = productPrice;
            _idProduct = idProduct;
            _count = count;
            lbNameProductChoose.Text = _name;
            lbPrice.Text = _price.ToString();
            lbCountChoose.Text = _count.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void item_ChooseProduct_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

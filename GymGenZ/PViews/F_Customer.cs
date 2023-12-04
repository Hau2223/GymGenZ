using GymGenZ.PControls;
using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GymGenZ.PViews
{
    public partial class F_Customer : Form
    {
        private CCustomer _dataService;
        private List<MCustomer> _customers;
        private String idCustomer = null;
        private string idTrainer = null;
 
        public F_Customer()
        {
            InitializeComponent();
            _dataService = new CCustomer("Data Source=C:\\Data\\GYM.db");
            loadDataToGrid();
            dataGripViewCustomer.SelectionChanged += dataGripViewCustomer_SelectionChanged;
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
                idTrainer = selectedRow.Cells["TrainerName"].Value.ToString();
                if(idTrainer != "")
                {
                    btnSign_Trainer.Enabled = false;
                }
                else
                {
                    btnSign_Trainer.Enabled = true;
                }
            }
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            loadDataToGrid();
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

        private void btn_Schedule_Click(object sender, EventArgs e)
        {
            F_Main currentFMain = FindOpenF_Main();

            if (currentFMain != null)
            {
                Panel fmainPanel = currentFMain.GetPanel();

                if (fmainPanel != null)
                {
                    MessageBox.Show(fmainPanel.Name.ToString());

                    F_Schedule f = new F_Schedule();
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


        private void F_Customer_Load(object sender, EventArgs e)
        {

        }

        private void dataGripViewCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSign_Trainer_Click(object sender, EventArgs e)
        {
            if (dataGripViewCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGripViewCustomer.SelectedRows[0];
                idCustomer = selectedRow.Cells["CustomerID"].Value.ToString();
                idTrainer = selectedRow.Cells["TrainerName"].Value.ToString();
                F_Main currentFMain = FindOpenF_Main();

                if (currentFMain != null)
                {
                    Panel fmainPanel = currentFMain.GetPanel();

                    if (fmainPanel != null)
                    {
                        MessageBox.Show(fmainPanel.Name.ToString());
                        F_SignPT f = new F_SignPT(idCustomer);
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
        }
    }
}

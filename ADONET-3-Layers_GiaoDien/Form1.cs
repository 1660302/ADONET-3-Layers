using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADONET_3_Layers_XuLy;


namespace ADONET_3_Layers_GiaoDien
{
    public partial class Form1 : Form
    {
        private int originalW;
        private int originalX;
        public Form1()
        {
            InitializeComponent();
            loadSuppliersToComboBox();
            loadCategoriesToComboBox();
            loadListOfProductToDataGridView();
        }
        // Support Functions
        private void loadListOfProductToDataGridView()
        {
            dgvListOfProducts.DataSource = Handler.getListOfProducts();
        }
        private void loadSuppliersToComboBox()
        {
            List<Tuple<int, string>> suppliers = Handler.getListOfSupplier();
            if(suppliers != null && suppliers.Count > 0)
            {
               
                foreach (Tuple<int, string> i in suppliers)
                {
                    cbSupplier.Items.Add(i.Item2);
                    //cbSupplier.Items.Add(i.Item1+". "+i.Item2);
                }
                //cbSupplier.SelectedIndex = 0;
            }
        }

        private void loadCategoriesToComboBox()
        {
            List<Tuple<int, string>> categories = Handler.getListOfCategorys();
            if (categories != null && categories.Count > 0)
            {

                foreach (Tuple<int, string> i in categories)
                {
                    cbCategory.Items.Add( i.Item2);
                    //cbCategory.Items.Add(i.Item1 + ". " + i.Item2);
                }
                //cbCategory.SelectedIndex = 0;
            }
        }


        // Event functions
        private void btnNew_Click(object sender, EventArgs e)
        {
            rbNew.Checked = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            rbEdit.Checked = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            rbDelete.Checked = true;
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            rbNew.Checked = true;
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            rbEdit.Checked = true;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            rbDelete.Checked = true;
            if (dgvListOfProducts.SelectedRows.Count > 0)
            {
                DialogResult res= MessageBox.Show("Do you really want delete?", "Wait", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    string id = dgvListOfProducts.Rows[dgvListOfProducts.CurrentRow.Index].Cells[0].Value.ToString();
                    Handler.deleteRow(int.Parse(id));
                    loadListOfProductToDataGridView();
                    MessageBox.Show("Deleted", "Done");
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Please select 1 row before delete", "Warning");
            }
        }
    }
}

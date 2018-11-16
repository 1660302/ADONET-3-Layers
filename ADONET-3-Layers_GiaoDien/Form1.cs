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
            dgvListOfProducts.CellClick += new DataGridViewCellEventHandler(dgvListOfProducts_CellClick);
            dgvListOfProducts.CellContentClick += new DataGridViewCellEventHandler(dgvListOfProducts_CellContentClick);
        }
        private void dgvListOfProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showSelectedRowDataForm(e.RowIndex);
        }
        private void dgvListOfProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showSelectedRowDataForm(e.RowIndex);
        }
        // Support Functions
        private void loadListOfProductToDataGridView()
        {
            dgvListOfProducts.DataSource = Handler.getListOfProducts();
            dgvListOfProducts.Columns["ProductID"].ReadOnly = true;
            if (dgvListOfProducts.RowCount > 0) showSelectedRowDataForm(0);
        }
        private void loadSuppliersToComboBox()
        {
            List<Tuple<int, string>> suppliers = Handler.getListOfSupplier();
            if (suppliers != null && suppliers.Count > 0)
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
                    cbCategory.Items.Add(i.Item2);
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


            int newid = parseInt(txtId.Text);
            string name = txtName.Text;
            int supplierID = cbSupplier.SelectedIndex + 1;
            int categoryID = cbCategory.SelectedIndex + 1;
            string quantity = txtQuantityPerUnit.Text;
            float price = parseFloat(txtUnitPrice.Text);
            int stock = parseInt(txtUnitsInStock.Text);
            int order = parseInt(txtUnitsOnOrder.Text);
            int reorder = parseInt(txtReoderLevel.Text);
            bool discontinued = parseIntToBool(cbDiscontinued.SelectedIndex);
            DialogResult res = MessageBox.Show("Do you really want Edit?", "Wait", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Handler.UpdateProducts(newid, name, supplierID, categoryID, quantity, price, stock, order, reorder, discontinued);
                loadListOfProductToDataGridView();
            }
        }
        private void showSelectedRowDataForm(int index)
        {
            if (index >= 0)
            {
                txtId.Text = dgvListOfProducts.Rows[index].Cells[0].Value.ToString();
                txtName.Text = dgvListOfProducts.Rows[index].Cells[1].Value.ToString();
                cbSupplier.SelectedIndex = parseInt(dgvListOfProducts.Rows[index].Cells[2].Value.ToString()) - 1;
                cbCategory.SelectedIndex = parseInt(dgvListOfProducts.Rows[index].Cells[3].Value.ToString()) - 1;
                txtQuantityPerUnit.Text = dgvListOfProducts.Rows[index].Cells[4].Value.ToString();
                txtUnitPrice.Text = dgvListOfProducts.Rows[index].Cells[5].Value.ToString();
                txtUnitsInStock.Text = dgvListOfProducts.Rows[index].Cells[6].Value.ToString();
                txtUnitsOnOrder.Text = dgvListOfProducts.Rows[index].Cells[7].Value.ToString();
                txtReoderLevel.Text = dgvListOfProducts.Rows[index].Cells[8].Value.ToString();
                cbDiscontinued.SelectedIndex = parseInt(dgvListOfProducts.Rows[index].Cells[9].Value.ToString());
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            rbDelete.Checked = true;
            if (dgvListOfProducts.SelectedRows.Count > 0)
            {
                DialogResult res = MessageBox.Show("Do you really want delete?", "Wait", MessageBoxButtons.YesNo);
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
        private int parseInt(string str)
        {
            int result = 0;
            if (str == "True")
            {
                return 1;
            }
            else if (str == "False") return 0;
            if (!Int32.TryParse(str, out result)) result = 0;
            return result;
        }
        private float parseFloat(string str)
        {
            float result = 0;
            if (!float.TryParse(str, out result)) result = 0;
            return result;
        }
        private Boolean parseBoolean(string str)
        {
            Boolean result = true;
            if (!bool.TryParse(str, out result)) result = false;
            return result;
        }
        private bool parseIntToBool(int i)
        {
            if (i == 1) return true;
            return false;
        }
    }
}

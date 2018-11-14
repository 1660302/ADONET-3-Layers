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
        public Form1()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XuLy xl = new XuLy();
            DataTable dt = xl.LayDSKhachHang();
            dg.DataSource = dt;
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ToString());

            string id = dg.Rows[dg.CurrentRow.Index].Cells[0].Value.ToString();
            string ten= dg.Rows[dg.CurrentRow.Index].Cells[1].Value.ToString();
            string bangcd = dg.Rows[dg.CurrentRow.Index].Cells[2].Value.ToString();
            txtMaNhom.Text = id;
            txtTruongNhom.Text = ten;
            txtBCDat.Text = bangcd;
            
        }

        
    }
}

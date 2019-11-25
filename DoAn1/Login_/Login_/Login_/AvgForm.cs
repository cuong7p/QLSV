using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;

namespace Login_
{
    public partial class AvgForm : Form
    {
        public AvgForm()
        {
            InitializeComponent();
        }
        Score s = new Score();
        DataProvider con = new DataProvider();
        private void AvgForm_Load(object sender, EventArgs e)
        {
            reload();
        }
        public void reload()
        {
            con.connect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Score", con.connection);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = s.getAvgByCourse();
            //pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            //pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}

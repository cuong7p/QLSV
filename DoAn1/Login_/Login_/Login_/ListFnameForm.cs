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
using System.Data;
using System.IO;

namespace Login_
{
    public partial class ListFnameForm : Form
    {
        string SfName;
        public ListFnameForm()
        {
            InitializeComponent();
        }
        public ListFnameForm(string fName) : this()
        {
            this.SfName = fName;
        }

        STUDENT st = new STUDENT();
        DataProvider con = new DataProvider();
        private void ListFnameForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tbl_userDataSet1.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.tbl_userDataSet1.std);
            con.connect();
            UpdateDeleteStudentForm up = new UpdateDeleteStudentForm();
            string sql = "SELECT * FROM std WHERE fname like '" + SfName + "' ";
            SqlCommand cmd = new SqlCommand(sql);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = st.getStudents(cmd, con);
            pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT *FROM std");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = st.getStudents(cmd, con);
            picol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}

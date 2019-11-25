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
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        STUDENT st = new STUDENT();
        private void Print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tbl_userDataSet.std' table. You can move, or remove it, as needed.
            //this.stdTableAdapter.Fill(this.tbl_userDataSet.std);
            // TODO: This line of code loads data into the 'tbl_userDataSet3.DB' table. You can move, or remove it, as needed.
            //this.dBTableAdapter.Fill(this.tbl_userDataSet3.DB);
            this.stdTableAdapter.Fill(this.tbl_userDataSet.std);
            con.connect();
            string sql = "SELECT * FROM std";
            SqlCommand cmd = new SqlCommand(sql);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = st.getStudents(cmd, con);
            pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                con.connect();
                string sql = "SELECT * FROM std";
                SqlCommand cmd = new SqlCommand(sql);
                dataGridView1.ReadOnly = true;
                DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = st.getStudents(cmd, con);
                pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AllowUserToAddRows = false;
            }
            if (radioButton2.Checked == true)
            {
                con.connect();
                string sql = "SELECT * FROM std Where gender=@gender";
                SqlCommand cmd = new SqlCommand(sql, con.connection);
                cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = "Male";
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable d = new DataTable();
                adt.Fill(d);
                dataGridView1.ReadOnly = true;
                DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = st.getStudents(cmd, con);
                pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AllowUserToAddRows = false;
            }
            if (radioButton3.Checked == true)
            {
                con.connect();
                string sql = "SELECT * FROM std Where gender=@gender";
                SqlCommand cmd = new SqlCommand(sql, con.connection);
                cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = "Female";
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable d = new DataTable();
                adt.Fill(d);
                dataGridView1.ReadOnly = true;
                DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = st.getStudents(cmd, con);
                pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            con.connect();
            string sql = "SELECT * FROM std WHERE bdate between @d1 and @d2 ";
            SqlCommand cmd = new SqlCommand(sql, con.connection);
            cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = dateTimePicker1.Text;
            cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = dateTimePicker2.Text;
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            adt.Fill(d);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = st.getStudents(cmd, con);
            pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = "QuanLySinhVien.txt";
            svf.Filter = "Text File|*.txt*";
            if ((svf.ShowDialog() == DialogResult.OK))
            {
                StreamWriter t = new StreamWriter(svf.OpenFile());
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                    {
                        t.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                    }
                    t.WriteLine("");
                }
                t.Close();
                MessageBox.Show("Data Downloaded");
            }
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        Bitmap b;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(b, 0, 0);
        }
    }
}

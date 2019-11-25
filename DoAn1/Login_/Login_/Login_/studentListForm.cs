using System;
using System.Collections.Generic;   //17110107  
using System.ComponentModel;        //Nguyen Huy Cuong
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
    public partial class studentListForm : Form
    {
        public studentListForm()
        {
            InitializeComponent();
        }
        STUDENT st = new STUDENT();
        DataProvider con = new DataProvider();

        private void studentListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tbl_userDataSet.std' table. You can move, or remove it, as needed.
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm up = new UpdateDeleteStudentForm();
            up.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            up.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            up.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            up.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;

            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female")
            {
                up.radioButton2.Checked = true;
            }
            up.textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            up.textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            up.pictureBox1.Image = Image.FromStream(picture);

            up.Show();

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

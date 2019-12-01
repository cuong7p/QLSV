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
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
        }
        Score s = new Score();
        DataProvider con = new DataProvider();
        Course c = new Course();
        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = c.getCourse(con);
            comboBox1.DisplayMember = "Course_Name";
            comboBox1.ValueMember = "Course_ID";
            comboBox1.SelectedItem = null;

            reload();
        }
        public void reload()
        {
            con.connect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Score", con.connection);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = s.getScore();
            //pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            //pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(textBox1.Text);
            float scr = Convert.ToInt32(textBox2.Text);           
            string des = textBox3.Text;
            int cid = (int)comboBox1.SelectedValue;

            s.id = sid;
            s.score = scr;
            s.des = des;
            s.cid = cid;

            con.connect();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Add A Score", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!s.studentScoreExit(s.id, s.cid))
            {
                if (s.insertScore(s.id, s.cid, s.score, s.des))
                {
                    MessageBox.Show("New Score Added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reload();
                }
                else
                {
                    MessageBox.Show("Error", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Emty Fields", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int id = Convert.ToInt32(comboBox1.SelectedValue);
            //    DataTable table = new DataTable();
            //    table = s.getCourseByID(id);
            //    textBox1.Text = table.Rows[0][1].ToString();
            //    textBox2.Text = table.Rows[0][2].ToString();
            //    textBox3.Text = table.Rows[0][3].ToString();
            //}
            //catch { }
        }

   
    }
}

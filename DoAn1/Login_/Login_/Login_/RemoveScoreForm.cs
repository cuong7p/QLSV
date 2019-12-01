using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Login_
{
    public partial class RemoveScoreForm : Form
    {
        public RemoveScoreForm()
        {
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        Score s = new Score();
        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = s.getStudentScore();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int cid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            s.id = sid;
            s.cid = cid;

            try
            {
                if (MessageBox.Show("Are You Sure Want To Delete This Score", "Delete Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (s.deleteScore(s.id, s.cid))
                    {
                        MessageBox.Show("Score Deleted", "Deleted Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("Score Not Deleted", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

        public void reload()
        {
            con.connect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Score", con.connection);
            dataGridView1.ReadOnly = true;
            //DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            //dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = s.getStudentScore();
            //pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            //pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}

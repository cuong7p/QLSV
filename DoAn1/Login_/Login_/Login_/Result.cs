using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_
{
    public partial class Result : Form
    {
        STUDENT student = new STUDENT();
        Score score = new Score();
        MyDb mydb = new MyDb();
        public Result()
        {
            InitializeComponent();
        }

        private void bttSearch_Click(object sender, EventArgs e)
        {
            string query = "select distinct std.id, std.fname, std.lname from std inner join score on std.id=score.student_id where concat(std.id,std.fname) like '%" + txtSearch.Text + "%'";

            SqlCommand command = new SqlCommand(query, mydb.getConnection);


            mydb.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            int i = 3;
            while (reader.Read())
            {
                dataGridView1.Rows[0].Cells[0].Value = reader.GetString(0);
                dataGridView1.Rows[0].Cells[1].Value = reader.GetString(1);
                dataGridView1.Rows[0].Cells[2].Value = reader.GetString(2);

            }
            mydb.closeConnection();
            goidiem();
            mydb.closeConnection();
            dataGridView1.Rows[0].Cells[7].Value = avg();
            mydb.closeConnection();
            if (avg() < 5)
            {
                dataGridView1.Rows[0].Cells[8].Value = "Fail";
            }
            else
            {
                dataGridView1.Rows[0].Cells[8].Value = "Pass";
            }
            mydb.closeConnection();
        }

        private double avg()
        {
            double kq = 0;
            double dtb;
            SqlCommand command = new SqlCommand("select score.student_score " +
                "from score inner join std on score.student_id=std.id " +
                "where concat(std.id,std.fname)like '%" + txtSearch.Text + "%'", mydb.getConnection);
            command.Parameters.Add("@st", SqlDbType.NChar).Value = txtSearch.Text;
            mydb.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                kq += reader.GetDouble(0);
                i++;
            }
            dtb = (double)kq / i;
            return Math.Round(dtb, 2);
        }

        void goidiem()
        {
            string query2 = "select score.student_score  from std inner join score on std.id=score.student_id where concat(std.id,std.fname) like '%" + txtSearch.Text + "%'";
            SqlCommand command2 = new SqlCommand(query2, mydb.getConnection);
            mydb.openConnection();
            SqlDataReader reader = command2.ExecuteReader();
            int i = 3;
            while (reader.Read())
            {
                dataGridView1.Rows[0].Cells[i].Value = reader.GetDouble(0);
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

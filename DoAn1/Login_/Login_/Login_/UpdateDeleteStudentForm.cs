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

namespace Login_
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateDeleteStudentForm_Load(object sender, EventArgs e)
        {

        }
        STUDENT st = new STUDENT();
        DataProvider con = new DataProvider();
        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            //string sql = "SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = ";
            SqlCommand cmd = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = " + id);

            DataTable da = st.getStudents(cmd, con);

            if(da.Rows.Count>0)
            {
                textBox2.Text = da.Rows[0]["fname"].ToString();
                textBox3.Text = da.Rows[0]["lname"].ToString();
                dateTimePicker1.Value = (DateTime)da.Rows[0]["bdate"];

                if(da.Rows[0]["gender"].ToString()=="Female")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }

                textBox1.Text = da.Rows[0]["id"].ToString();
                textBox5.Text = da.Rows[0]["address"].ToString();

                byte[] pic = (byte[])da.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
            }

            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string phone = textBox4.Text;
            //string sql = "SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = ";
            SqlCommand cmd = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE phone = " + phone);

            DataTable da = st.getStudents(cmd, con);

            if (da.Rows.Count > 0)
            {
                textBox2.Text = da.Rows[0]["fname"].ToString();
                textBox3.Text = da.Rows[0]["lname"].ToString();
                dateTimePicker1.Value = (DateTime)da.Rows[0]["bdate"];

                if (da.Rows[0]["gender"].ToString() == "Female")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }

                textBox4.Text = da.Rows[0]["phone"].ToString();
                textBox5.Text = da.Rows[0]["address"].ToString();

                byte[] pic = (byte[])da.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
            }

            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //string fname = textBox2.Text;
            string sql = "SELECT * FROM std WHERE fname like'" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con.connection);
            DataTable da = st.getStudents(cmd, con);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read() == true)
            {
                ListFnameForm l = new ListFnameForm(textBox2.Text);
                l.Show();
            }
            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if((opf.ShowDialog()==DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Convert.ToInt32(textBox1.Text);
                if(MessageBox.Show("Are You Sure Want To Delete This Student", "Delete Student",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if(st.deleteStudent(studentId,con))
                    {
                        MessageBox.Show("Student Deleted", "Deleted Student", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        bool verif()
        {
            if((textBox1.Text.Trim()=="")
                ||(textBox2.Text.Trim()=="")
                ||(textBox3.Text.Trim()=="")
                ||(textBox4.Text.Trim()=="")
                ||(textBox5.Text.Trim()=="")
                ||(pictureBox1.Image==null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id;
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox4.Text;
            string adrs = textBox5.Text;
            string gender = "Male";

            if(radioButton2.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if((this_year-born_year)<10||(this_year-born_year)>100)
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Birth Date Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(verif())
            {
                try
                {
                    id = Convert.ToInt32(textBox1.Text);

                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if(st.updateStudent(id, fname, lname, bdate, gender, phone, adrs, pic,  con))
                    {
                        MessageBox.Show("Student Information Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

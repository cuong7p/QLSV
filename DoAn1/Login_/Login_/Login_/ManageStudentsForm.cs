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
using System.Drawing.Imaging;

namespace Login_
{
    public partial class ManageStudentsForm : Form
    {
        public ManageStudentsForm()
        {
            InitializeComponent();
        }

        STUDENT st = new STUDENT();
        DataProvider con = new DataProvider();

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox4.Text;
            string adrs = textBox5.Text;
            string gender = "Male";
            DataProvider con = new DataProvider();
            con.connect();

            if (radioButton2.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            st.id = id;
            st.fname = fname;
            st.lname = lname;
            st.bdate = bdate;
            st.phone = phone;
            st.address = adrs;
            st.gender = gender;
            st.pic = pic;

            if (((this_year - born_year) < 10) || (this_year - born_year) > 100)
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                pictureBox1.Image.Save(st.pic, pictureBox1.Image.RawFormat);
                if (st.insertStudent(st.id, st.fname, st.lname, st.bdate, st.gender, st.phone, st.address, st.pic, con))
                {
                    MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Emty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            label9.Text = ("Total Students : " + dataGridView1.Rows.Count);
        }

        bool verif()
        {
            if ((textBox2.Text.Trim() == "") || (textBox3.Text.Trim() == "") || (textBox4.Text.Trim() == "") || (textBox5.Text.Trim() == "") || (pictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id= Convert.ToInt32(textBox1.Text); 
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox4.Text;
            string adrs = textBox5.Text;
            string gender = "Male";

            if (radioButton2.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            st.id = id;
            st.fname = fname;
            st.lname = lname;
            st.bdate = bdate;
            st.phone = phone;
            st.address = adrs;
            st.gender = gender;
            st.pic = pic;

            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Birth Date Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(textBox1.Text);

                    pictureBox1.Image.Save(st.pic, pictureBox1.Image.RawFormat);
                    if (st.updateStudent(st.id, st.fname, st.lname, st.bdate, st.gender, st.phone, st.address, st.pic, con))
                    {
                        MessageBox.Show("Student Information Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            label9.Text = ("Total Students : " + dataGridView1.Rows.Count);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = Convert.ToInt32(textBox1.Text);
                st.id = studentId;
                if (MessageBox.Show("Are You Sure Want To Delete This Student", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (st.deleteStudent(st.id, con))
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
            label9.Text = ("Total Students : " + dataGridView1.Rows.Count);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.connect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM std WHERE CONCAT(fname, lname, address) LIKE'%" + textBox6.Text + "%' ", con.connection);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = st.getStudents(cmd, con);
            pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

            label9.Text = ("Total Students : " + dataGridView1.Rows.Count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("student_" + textBox1.Text);
            if(pictureBox1.Image == null)
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if(svf.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image.Save(svf.FileName + ("." + ImageFormat.Jpeg.ToString()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            pictureBox1.Image = null;
            label9.Text = ("Total Students : " + dataGridView1.Rows.Count);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT *FROM std");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = st.getStudents(cmd, con);
            picol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
            label9.Text = ("Total Students : " + dataGridView1.Rows.Count);
        }

        private void button9_Click(object sender, EventArgs e)
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
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;

            if (dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim()=="Male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            st.pic = picture;
            pictureBox1.Image = Image.FromStream(st.pic);
            label9.Text = ("Total Students : " + dataGridView1.Rows.Count);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageStudentsForm_Load(object sender, EventArgs e)
        {
            con.connect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM std", con.connection);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = st.getStudents(cmd, con);
            pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

            label9.Text = ("Total Students : " + dataGridView1.Rows.Count);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}

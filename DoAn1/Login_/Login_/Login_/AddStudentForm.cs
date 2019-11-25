using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;              //Nguyen Huy Cuong
using System.Threading.Tasks;   //17110107
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Login_
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            STUDENT st = new STUDENT();
            int id = Convert.ToInt32(textBox1.Text);
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox5.Text;
            string adrs = textBox6.Text;
            string gender = "Male";
            DataProvider con = new DataProvider();
            con.connect();

            if(radioButton2.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            if( ((this_year-born_year)<10)||(this_year-born_year)>100)
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
            else if(verif())
            {
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                if(st.insertStudent(id, fname, lname, bdate, gender, phone, adrs, pic, con))
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
        }
        bool verif()
        {
            if((textBox2.Text.Trim()=="")||(textBox3.Text.Trim()=="")||(textBox5.Text.Trim()=="")||(textBox6.Text.Trim()=="")||(pictureBox1.Image==null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.gif)|*.jpg;*.png;*.gif";
            if((opf.ShowDialog()==DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}

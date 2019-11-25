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
    public partial class Sign_In : Form
    {
        public Sign_In()
        {
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        User u = new User();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            string username = textBox4.Text;
            string pass = textBox5.Text;
            MemoryStream pic = new MemoryStream();
                     
            if (verif())
            {
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                if (u.insertUser(id, fname, lname, username, pass, pic))
                {
                    MessageBox.Show("New User Added", "Add  User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add  User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Emty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if ((textBox2.Text.Trim() == "") || (textBox3.Text.Trim() == "") || (textBox5.Text.Trim() == "") || (textBox1.Text.Trim() == "") || (pictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
            
        }
    }  
}

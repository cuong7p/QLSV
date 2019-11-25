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
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        private void AddContactForm_Load(object sender, EventArgs e)
        {
            Group gr = new Group();
            comboBox1.DataSource = gr.getGruops(Globals.GlobalUserId);
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox6.Text);
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox5.Text;
            string email = textBox4.Text;
            int userid = Globals.GlobalUserId;
            try
            {
                int groupid = (int)comboBox1.SelectedValue;
                MemoryStream pic = new MemoryStream();
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                Contact contact = new Contact();
                if(contact.insertContact(id,fname,lname,phone,address,email,userid,groupid,pic))
                {
                    MessageBox.Show("New Contact Added", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Loi");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select image(*.jpg;*.png;*.gif|*.jpg;*.png;*.gif";
            if(opf.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

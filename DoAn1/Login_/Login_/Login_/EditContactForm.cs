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
    public partial class EditContactForm : Form
    {
        public EditContactForm()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        private void button4_Click(object sender, EventArgs e)
        {
            SelectContactForm selectCon = new SelectContactForm();
            selectCon.ShowDialog();
            try
            {
                int contactid = Convert.ToInt32(selectCon.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                contact.id = contactid;
                
                DataTable table = contact.GetContactById(contact.id);
                textBox6.Text = table.Rows[0]["id"].ToString();
                textBox1.Text = table.Rows[0]["fname"].ToString();
                textBox2.Text = table.Rows[0]["lname"].ToString();
                comboBox1.SelectedValue = table.Rows[0]["group_id"];
                textBox3.Text = table.Rows[0]["phone"].ToString();
                textBox4.Text = table.Rows[0]["email"].ToString();
                textBox5.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["pic"];
                MemoryStream picture = new MemoryStream(pic);
                contact.pic = picture;
                pictureBox1.Image = Image.FromStream(contact.pic);

            }
            catch(Exception)
            {

            }
        }

        private void EditContactForm_Load(object sender, EventArgs e)
        {
            Group gr = new Group();
            comboBox1.DataSource = gr.getGruops(Globals.GlobalUserId);
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox5.Text;
            string email = textBox4.Text;

            contact.fname = fname;
            contact.lname = lname;
            contact.phone = phone;
            contact.address = address;
            contact.email = email;
            try
            {
                int id = Convert.ToInt32(textBox6.Text);
                contact.id = id;
                int groupid = (int)comboBox1.SelectedValue;
                contact.groupid = groupid;
                MemoryStream pic = new MemoryStream();
                contact.pic = pic;
                pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                if(contact.updateContact(contact.id, contact.fname, contact.lname, contact.phone, contact.address, contact.email, contact.groupid, contact.pic))
                {
                    MessageBox.Show("Contact Information Updated", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select image(*.jpg;*.png;*.gif|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
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

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
    public partial class HumanResourceForm : Form
    {
        public HumanResourceForm()
        {
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        Contact ct = new Contact();
        Group gr = new Group();
        STUDENT st = new STUDENT();
        MyDb mydb = new MyDb();
        int x = Globals.GlobalUserId;

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ct.deleteContact(Globals.GlobalUserId))
                MessageBox.Show("Bạn đã  xóa liên lạc");
            else
                MessageBox.Show("Lỗi ");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            int id = Convert.ToInt32(textBox4.Text);
            int uid = Globals.GlobalUserId;
            if(gr.insertGroup(id,name,uid))
            {
                MessageBox.Show("New Group Added", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Add Group ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddContactForm add = new AddContactForm();
            add.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            EditContactForm edit = new EditContactForm();
            edit.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectContactForm se = new SelectContactForm();
            se.Show();
        }
        void fillGroup()
        {
            SqlCommand command = new SqlCommand("select * from mygroups where userid ="+Globals.GlobalUserId);
            comboBox1.DataSource = st.getStudents(command, con);
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }
        void fillGroup2()
        {
            SqlCommand command = new SqlCommand("select * from mygroups where userid =" + Globals.GlobalUserId);
            comboBox2.DataSource = st.getStudents(command, con);
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id_g = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            string name = textBox3.Text;
            if (gr.updateGroup(id_g, name))
            {
                MessageBox.Show("Đã cập nhật group");
                fillGroup();
                fillGroup2();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (gr.deleteGroup(Convert.ToInt32(comboBox2.SelectedValue.ToString())))
            {
                MessageBox.Show("Đã Xóa Group");
                fillGroup();
                fillGroup2();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void HumanResourceForm_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
            fillGroup();
            fillGroup2();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            if (ct.deleteContact(id))
                MessageBox.Show("Bạn đã  xóa liên lạc");
            else
                MessageBox.Show("Lỗi ");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from mycontact");
            DataTable table = new DataTable();
            table = ct.SelectContactList(command);
            SelectContactForm frm = new SelectContactForm();
            frm.dataGridView1.DataSource = table;
            frm.Show();
        }

        public void getImageAndUsername()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from hr where Id=@id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = x;
            adapter.SelectCommand = cmd;
            adapter.Fill(tb);
            if ((tb.Rows.Count > 0))
            {
                byte[] pic = (byte[])tb.Rows[0]["fig"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
                label9.Text = "Welcom Back (" + tb.Rows[0]["uname"].ToString().Trim() + ")";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

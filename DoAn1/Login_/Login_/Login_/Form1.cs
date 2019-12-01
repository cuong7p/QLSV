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

namespace Login_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
      

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static string ID_User = "";
        private void button1_Click_1(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            User u = new User();
            provider.connect();
            try
            {
                string tk = textBox1.Text;
                string mk = textBox2.Text;

                u.username = tk;
                u.pass = mk;

                string sql = "select * from tbl_user where user_name='" + u.username + "' and user_pass='" + u.pass + "'";
                string sql1 = "select * from hr where uname='" + u.username + "' and pwd='" + u.pass + "'";
                SqlCommand connect = new SqlCommand(sql1, provider.connection);
                //SqlDataReader read = connect.ExecuteReader();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = connect;
                adapter.Fill(table);
                Globals.SetGlobalUserId(Convert.ToInt32(table.Rows[0]["id"].ToString()));

                if (radioButton1.Checked)
                {
                    //if (read.Read() == true)
                    if(table.Rows.Count>0)
                    {
                        //MessageBox.Show("Đăng Nhập thành công");
                        
                        MainForm mf = new MainForm();
                        mf.Show();
                        this.Hide();

                    }
                    else MessageBox.Show("Đăng Nhập thất bại");
                }
                else
                {
                    if (table.Rows.Count >0)
                    {
                        HumanResourceForm h = new HumanResourceForm();
                        h.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Đăng Nhập thất bại");
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_In s = new Sign_In();
            this.Hide();
            s.Show();
        }
    }
}

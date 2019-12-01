using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        Course c = new Course();
        private void button1_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(textBox1.Text);
            string cname = textBox2.Text;
            int per = Convert.ToInt32(textBox3.Text);
            string des = textBox4.Text;

            c.cId = cid;
            c.cname = cname;
            c.per = per;
            c.des = des;

            con.connect();
            if (per<=10)
            {
                MessageBox.Show("The period must > 10", "Invalid period", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                if (c.insertCourse(c.cId, c.cname, c.per, c.des, con))
                {
                    MessageBox.Show("New Course Added", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Emty Fields", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if ((textBox2.Text.Trim() == "") || (textBox3.Text.Trim() == "") || (textBox4.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

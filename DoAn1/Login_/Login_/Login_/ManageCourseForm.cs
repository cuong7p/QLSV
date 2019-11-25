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
    public partial class ManageCourseForm : Form
    {
        Course c = new Course();
        int pos;
        DataProvider con = new DataProvider();

        public ManageCourseForm()
        {
            InitializeComponent();
        }
        private void ManageCourseForm_Load(object sender, EventArgs e)
        {
            reloadListBoxData();
        }
        void reloadListBoxData()
        {
            listBox1.DataSource = c.getCourse(con);
            listBox1.ValueMember = "Course_ID";
            listBox1.DisplayMember = "Course_Name";
            listBox1.SelectedItem = null;          
        }
        void ShowData(int index)
        {
            DataRow dr = c.getCourse(con).Rows[index];
            listBox1.SelectedIndex = index;
            textBox1.Text = dr.ItemArray[0].ToString();
            textBox2.Text = dr.ItemArray[1].ToString();
            numericUpDown1.Value = int.Parse(dr.ItemArray[2].ToString());
            textBox3.Text = dr.ItemArray[3].ToString();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            DataRowView dt = (DataRowView)listBox1.SelectedItem;
            pos = listBox1.SelectedIndex;
            ShowData(pos);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            int hrs = (int)numericUpDown1.Value;
            string descr = textBox3.Text;
            if(name.Trim()=="")
            {
                MessageBox.Show("Add A Course Name", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if(c.checkCourseName(name, id, con))
            {
                if(c.insertCourse(id,name,hrs,descr,con))
                {
                    MessageBox.Show("New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reloadListBoxData();
                }
                else
                {
                    MessageBox.Show("New Course Not Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("This Course Already Exits", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            int hrs = (int)numericUpDown1.Value;
            string descr = textBox3.Text;

            if (!c.checkCourseName(name, id, con))
            {
                MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (c.updateStudent(id, name, hrs, descr, con))
            {
                MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloadListBoxData();
            }
            else
            {
                MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pos = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(textBox1.Text);
                if (MessageBox.Show("Are You Sure Want To Delete This Course", "Delete Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (c.deleteCourse(Id, con))
                    {
                        MessageBox.Show("Course Deleted", "Deleted Course", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        numericUpDown1.Value = 0;
                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            pos = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowData(pos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pos < (c.getCourse(con).Rows.Count - 1))
            {
                pos += 1;
                ShowData(pos);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(pos>0)
            {
                pos -= 1;
                ShowData(pos);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pos = c.getCourse(con).Rows.Count - 1;
            ShowData(pos);
        }
    }
}

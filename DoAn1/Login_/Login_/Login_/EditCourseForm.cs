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
    public partial class EditCourseForm : Form
    {
        public EditCourseForm()
        {
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        Course c = new Course();
        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = c.getCourse(con);
            comboBox1.DisplayMember = "Course_Name";
            comboBox1.ValueMember = "Course_ID";
            comboBox1.SelectedItem = null;
        }
        public void fillcombo(int index)
        {
            comboBox1.DataSource = c.getCourse(con);
            comboBox1.DisplayMember = "Course_Name";
            comboBox1.ValueMember = "Course_ID";
            comboBox1.SelectedItem = index;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue);
                DataTable table = new DataTable();
                table = c.getCourseById(id, con);
                textBox1.Text = table.Rows[0][1].ToString();
                numericUpDown1.Value = Int32.Parse(table.Rows[0][2].ToString());
                textBox2.Text = table.Rows[0][3].ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int h = (int)numericUpDown1.Value;
            string des = textBox2.Text;
            int id = (int)comboBox1.SelectedValue;

            if(!c.checkCourseName(name,Convert.ToInt32(comboBox1.SelectedValue),con))
            {
                MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(c.updateStudent(id,name,h,des,con))
            {
                MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

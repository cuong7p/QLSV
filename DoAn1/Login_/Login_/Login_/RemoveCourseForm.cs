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
    public partial class RemoveCourseForm : Form
    {
        public RemoveCourseForm()
        {
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        Course c = new Course();
        private void button1_Click(object sender, EventArgs e)
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
        }
    }
}

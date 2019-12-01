using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Login_
{
    public partial class ManageScoreForm : Form
    {
        public ManageScoreForm()
        {
            InitializeComponent();
        }

        Score s = new Score();
        STUDENT std = new STUDENT();
        Course c = new Course();
        DataProvider con = new DataProvider();

        private void button1_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                int stdID = Convert.ToInt32(TextBoxStdID.Text.Trim());
                int cID = (int)ComboBoxSelCourse.SelectedValue;
                float score = Convert.ToInt32(TextBoxScore.Text.Trim());
                string des = TextBoxDescription.Text.Trim();

                s.id = stdID;
                s.cid = cID;
                s.score = score;
                s.des = des;

                if (!s.studentScoreExit(s.id, Convert.ToInt32(ComboBoxSelCourse.SelectedValue)))
                {
                    if (s.insertScore(s.id, s.cid, s.score, s.des))
                    {
                        MessageBox.Show("New Score Added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Couldn't add Score", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("You don't enter Course", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Emty Fields", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if ((TextBoxStdID.Text.Trim() == "")
                || (ComboBoxSelCourse.Text.Trim() == "")
                || (TextBoxScore.Text.Trim() == "")
                || (TextBoxDescription.Text.Trim() == ""))
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
            RemoveScoreForm re = new RemoveScoreForm();
            re.Show();
            //try
            //{
            //    int studentId = Convert.ToInt32(TextBoxStdID.Text);
            //    int cid = Convert.ToInt32(ComboBoxSelCourse.SelectedValue);
            //    if ((MessageBox.Show("Are you sure want to delete this student", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            //    {
            //        if (s.deleteScore(studentId, cid) )
            //        {
            //            MessageBox.Show("Student Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            // clear fields after detele
            //            TextBoxStdID.Text = "";
            //            TextBoxScore.Text = "";
            //            TextBoxDescription.Text = "";
            //            ComboBoxSelCourse.ValueMember = null;

            //        }
            //        else
            //        {
            //            MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Please Enter A Valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate FROM std");
            dataGridView1.DataSource = std.getStudents(command, con);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = s.getStudentScore();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            TextBoxStdID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
        }

        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            ComboBoxSelCourse.DataSource = c.getCourse(con);
            ComboBoxSelCourse.DisplayMember = "Course_Name";
            ComboBoxSelCourse.ValueMember = "Course_ID";
            ComboBoxSelCourse.SelectedItem = null;
        }
        public void fillCombo(int index)
        {
            ComboBoxSelCourse.DataSource = c.getCourse(con);
            ComboBoxSelCourse.DisplayMember = "Course_Name";
            ComboBoxSelCourse.ValueMember = "Course_ID";
            ComboBoxSelCourse.SelectedItem = null;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            AvgForm avg = new AvgForm();
            avg.Show();
        }
    }
}

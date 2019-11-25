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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStdF = new AddStudentForm();
            addStdF.Show(this);
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentListForm st = new studentListForm();
            st.Show();
            //st.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void mannageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentsForm mnst = new ManageStudentsForm();
            mnst.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print pr = new Print();
            pr.Show();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourse add = new AddCourse();
            add.Show();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveCourseForm re = new RemoveCourseForm();
            re.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCourseForm ed = new EditCourseForm();
            ed.Show();
        }

        private void cOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCourseForm mn = new ManageCourseForm();
            mn.Show(); 
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintCourseForm pr = new PrintCourseForm();
            pr.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm ad = new AddScoreForm();
            ad.Show();
        }

        private void avgScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvgForm av = new AvgForm();
            av.Show();
        }

        private void rmoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm re = new RemoveScoreForm();
            re.Show();
        }

        private void mangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoreForm ma = new ManageScoreForm();
            ma.Show();
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm up = new UpdateDeleteStudentForm();
            up.Show();
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statics s = new Statics();
            s.Show();
        }

        private void printResaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result re = new Result();
            re.Show();
        }
    }
}

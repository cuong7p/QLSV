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
using System.Drawing.Printing;

namespace Login_
{
    public partial class PrintCourseForm : Form
    {
        public PrintCourseForm()
        {
            InitializeComponent();
        }
        Course c = new Course();
        DataProvider con = new DataProvider();
        Bitmap bitmap;
        private void PrintCourseForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tbl_userDataSet4.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.tbl_userDataSet4.Course);
            con.connect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course", con.connection);
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pigcol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = c.getCourse(con);
            //pigcol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            //pigcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = "Course.txt";
            svf.Filter = "Text File|*.txt*";
            if ((svf.ShowDialog() == DialogResult.OK))
            {
                StreamWriter t = new StreamWriter(svf.OpenFile());
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                    {
                        t.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                    }
                    t.WriteLine("");
                }
                t.Close();
                MessageBox.Show("Data Downloaded");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //PrintDialog prdi = new PrintDialog();
            //PrintDocument prdc = new PrintDocument();
            //prdc.DocumentName = "Print Document";
            //prdi.Document = prdc;
            //prdi.AllowSelection = true;
            //prdi.AllowSomePages = true;
            //if(prdi.ShowDialog()==DialogResult.OK)
            //{
            //    prdc.Print();
            //}
            //-------------------------------------------------------------------
            //Resize DataGridView to full height.
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            //Resize DataGridView back to original height.
            dataGridView1.Height = height;

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}

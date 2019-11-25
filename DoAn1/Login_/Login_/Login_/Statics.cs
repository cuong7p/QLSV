using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_
{
    public partial class Statics : Form
    {
        public Statics()
        {
            InitializeComponent();
        }
        Color panel11;
        Color panel22;
        Color panel33;
        private void Statics_Load(object sender, EventArgs e)
        {

            Load_Lable();
        }
        void Load_Lable()
        {
            MyDb db = new MyDb();
            SqlCommand command = new SqlCommand("select * from std ", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            int siso = table.Rows.Count;
            lbSiso.Text = ("Tổng số học sinh:" + siso);
            SqlCommand command1 = new SqlCommand("select * from std where gender=@Gender", db.getConnection);
            command1.Parameters.Add("@Gender", SqlDbType.VarChar).Value = "Female    ";
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            int sisonu = table1.Rows.Count;
            double nu = (sisonu * 100) / siso;
            lbNu.Text = ("Nu:" + Math.Round(nu, 2));
            double nam = 100 - nu;
            lbNam.Text = ("Nam: " + Math.Round(nam, 2));
        }
    }
}

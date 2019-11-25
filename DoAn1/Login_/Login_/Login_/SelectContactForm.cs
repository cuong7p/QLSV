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
using System.Data;
using System.IO;

namespace Login_
{
    public partial class SelectContactForm : Form
    {
        public SelectContactForm()
        {
            InitializeComponent();
        }

        private void SelectContactForm_Load(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            SqlCommand cm = new SqlCommand("select id, fname as'first name', lname as 'last name', group_id as'group id' from mycontact where userid=@uid");
            cm.Parameters.Add("@uid", SqlDbType.Int).Value = Globals.GlobalUserId;
            dataGridView1.DataSource = contact.SelectContactList(cm);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

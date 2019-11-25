using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Login_
{
    class MyDb
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9L94EI5;Initial Catalog=tbl_user;Integrated Security=True");
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

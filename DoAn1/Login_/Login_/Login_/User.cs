using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing.Printing;

namespace Login_
{
    class User
    {
        DataProvider con = new DataProvider();
        public DataTable getUserById(Int32 userid)
        {
            SqlDataAdapter ad = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand cm = new SqlCommand("select * from hr where id=@uid", con.connection);
            cm.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            ad.SelectCommand = cm;
            ad.Fill(table);
            return table;
        }
        MyDb con1 = new MyDb();
        public bool insertUser(int id, string fname, string lname, string username, string password, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO hr (id, f_name, l_name, uname, pwd, fig) VALUES (@id , @fn, @ln, @un, @pass, @pic)", con1.getConnection);
            //SqlCommand cmd = new SqlCommand("INSERT INTO hr id=@id, f_name=@fn, l_name=@ln, uname=@un, pwd=@pass, fig=@pic  ", con.connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            con1.openConnection();
            if (cmd.ExecuteNonQuery()==1)
            {
                con1.closeConnection();
                return true;
            }
            else
            {
                con1.closeConnection();
                return false;
            }
        }
        public bool usernameExist(string username, string operation, int userid=0)
        {
            string query = "";
            if(operation=="register")
            {
                query = "select * from hr where uname = @un";
            }
            else if(operation=="edit")
            {
                query = "select * from hr where uname = @un and id <> @uid";
            }
            SqlCommand cm = new SqlCommand(query, con.connection);
            cm.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            cm.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            SqlDataAdapter ad = new SqlDataAdapter();
            DataTable table = new DataTable();
            ad.SelectCommand = cm;
            ad.Fill(table);

            if(table.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool updateUser(int userid, string fname, string lname, string username, string password, MemoryStream picture)
        {
            SqlCommand cm = new SqlCommand("update hr f_name=@fn, l_name=@ln, uname=@un, pwd=@pass, fig=@pic where id=@uid", con.connection);
            cm.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cm.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cm.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            cm.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            cm.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            cm.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            con.connect();
            if(cm.ExecuteNonQuery()==1)
            {
                con.disconnect();
                return true;
            }
            else
            {
                con.disconnect();
                return false;
            }
        }
    }
}

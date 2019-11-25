using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    class STUDENT
    {
        public bool insertStudent(int Id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture, DataProvider con)
        {
            SqlCommand command = new SqlCommand("INSERT INTO std(id, fname, lname, bdate, gender, phone, address, picture)" +
                "VALUES (@id, @fn, @ln, @bdt, @gdr, @phn, @adrs, @pic)", con.connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            con.connect();

            if((command.ExecuteNonQuery()==1))
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

        public bool insertStudent(int Id, string fname, string lname, DateTime bdate, string gender, string phone, MemoryStream picture, DataProvider con)
        {
            SqlCommand command = new SqlCommand("INSERT INTO std(id, fname, lname, bdate, gender, phone, address, picture)" +
                "VALUES (@id, @fn, @ln, @bdt, @gdr, @phn, @adrs, @pic)", con.connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            //command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            con.connect();

            if ((command.ExecuteNonQuery() == 1))
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

        public DataTable getStudents(SqlCommand cmd, DataProvider con)
        {
            con.connect();
            cmd.Connection = con.connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
       
        public bool deleteStudent(int id, DataProvider con)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM std WHERE id= @id", con.connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.connect();
            if(cmd.ExecuteNonQuery()==1)
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

        public bool updateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture, DataProvider con)
        {
            SqlCommand cmd = new SqlCommand("UPDATE std SET fname=@fn, lname=@ln, bdate=@bdt, gender=@gdr, phone=@phn, address=@adrs, picture=@pic WHERE id=@ID", con.connection);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            cmd.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            con.connect();

            if(cmd.ExecuteNonQuery()==1)
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

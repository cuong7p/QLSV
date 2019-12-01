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
    public static class Globals
    {
        public static int GlobalUserId { get; private set; }
        public static void SetGlobalUserId(int userid)
        {
            GlobalUserId = userid;
        }
    }
    class Group
    {
        public int id { get; set; }
        public string gname { get; set; }
        public int userid { get; set; }

        public void group() { }
        public void group(int id, string gname, int userid)
        {
            this.id = id;
            this.gname = gname;
            this.userid = userid;
        }


        DataProvider con = new DataProvider();
        MyDb db = new MyDb();
        public bool insertGroup(int id, string gname, int userid)
        {
            SqlCommand cm = new SqlCommand("insert into mygroups (id, name, userid) values (@id, @gr, @uid)",db.getConnection);

            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cm.Parameters.Add("@gr", SqlDbType.VarChar).Value = gname;
            cm.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            db.openConnection();

            if(cm.ExecuteNonQuery()==1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool updateGroup(int gid, string gname)
        {
            SqlCommand cm = new SqlCommand("update mygroups set name=@name where id=@id", db.getConnection);

            cm.Parameters.Add("@name", SqlDbType.VarChar).Value = gname;
            cm.Parameters.Add("@id", SqlDbType.Int).Value = gid;

            db.openConnection();

            if (cm.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool deleteGroup(int groupid)
        {
            SqlCommand cm = new SqlCommand("delete from mygroups where id=@id", db.getConnection);

            cm.Parameters.Add("@id", SqlDbType.Int).Value = groupid;

            db.openConnection();

            if (cm.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public DataTable getGruops(int userid)
        {
            SqlCommand cm = new SqlCommand("select * from mygroups where userid =@uid", con.connection);
            con.connect();
            cm.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            cm.Connection = con.connection;

            SqlDataAdapter ad = new SqlDataAdapter(cm);
            DataTable table = new DataTable();

            ad.Fill(table);

            return table;
        }
        public bool groupExist(string name, string operation, int userid=0, int gruopid=0)
        {
            string query = "";
            SqlCommand cm = new SqlCommand();

            if(operation=="add")
            {
                query = "select * from mygroups where name = @name and userid = @uid";
                cm.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cm.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            }
            else if(operation=="edit")
            {
                query = "select * from mygroups where name=@name and userid=@uid and id<>@gid";
                cm.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cm.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
                cm.Parameters.Add("@gid", SqlDbType.Int).Value = gruopid;
            }

            cm.Connection = con.connection;
            cm.CommandText = query;

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
        
    }
}

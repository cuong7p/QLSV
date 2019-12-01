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
    class Course
    {
        public int cId { get; set; }
        public string cname { get; set; }
        public int per { get; set; }
        public string des { get; set; }

        public void course() { }
        public void course(int cid, string cname, int per, string des)
        {
            this.cId = cid;
            this.cname = cname;
            this.per = per;
            this.des = des;
        }



        public bool checkCourseName(string courseName, int courseID, DataProvider con)
        {
            courseID = 0;
            SqlCommand cmd = new SqlCommand("Select * From Course Where Course_Name=@cName and Course_ID<>@cID", con.connection);
            cmd.Parameters.Add("@cName", SqlDbType.VarChar).Value = courseName;
            cmd.Parameters.Add("@cID", SqlDbType.Int).Value = courseID;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ta = new DataTable();
            ad.Fill(ta);
            if(ta.Rows.Count>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool insertCourse(int cId, string cname, int per,string des, DataProvider con)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course(Course_ID, Course_Name, Period, Description)" +
                "VALUES (@id, @cn, @p, @d)", con.connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = cId;
            command.Parameters.Add("@cn", SqlDbType.NVarChar).Value = cname;
            command.Parameters.Add("@p", SqlDbType.Int).Value = per;
            command.Parameters.Add("@d", SqlDbType.NVarChar).Value = des;
            
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

        public bool deleteCourse(int id, DataProvider con)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Course WHERE Course_ID= @id", con.connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.connect();
            if (cmd.ExecuteNonQuery() == 1)
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

        public DataTable getCourse( DataProvider con)
        {
            SqlCommand cmd = new SqlCommand("select *from Course");
            con.connect();
            cmd.Connection = con.connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseById(int id,DataProvider con)
        {
            SqlCommand cmd = new SqlCommand("select *from Course where Course_ID=@id",con.connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.connect();
            cmd.Connection = con.connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateStudent(int cId, string cname, int per, string des, DataProvider con)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Course SET Course_Name=@n, Period=@p, Description=@d  WHERE Course_ID=@ID", con.connection);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = cId;
            cmd.Parameters.Add("@n", SqlDbType.NVarChar).Value = cname;
            cmd.Parameters.Add("@p", SqlDbType.Int).Value = per;
            cmd.Parameters.Add("@d", SqlDbType.NVarChar).Value = des;

            con.connect();

            if (cmd.ExecuteNonQuery() == 1)
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

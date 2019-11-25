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
    class Score
    {
        DataProvider con = new DataProvider();
        public bool insertScore(int sid, int cid, float score, string des)
        {
            SqlCommand cmd = new SqlCommand("insert into Score(student_id, course_id, student_score, description) values (@sid,@cid,@scr,@des)", con.connection);
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = sid;
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = cid;
            cmd.Parameters.Add("@scr", SqlDbType.Float).Value = score;
            cmd.Parameters.Add("@des", SqlDbType.VarChar).Value = des;
            con.connect();
            if(cmd.ExecuteNonQuery()==1)
            {
                return true;
                con.disconnect();
            }
            else
            {
                return false;
                con.disconnect();
            }
        }
        public bool studentScoreExit(int sid, int cid)
        {
            SqlCommand cmd = new SqlCommand("select * from Score where student_id=@sid and course_id=@cid", con.connection);
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = sid;
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = cid;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ta = new DataTable();
            ad.Fill(ta);
            if(ta.Rows.Count==0)
            {
                return false;
                con.disconnect();
            }
            else
            {
                return true;
                con.disconnect();
            }
        }
        public DataTable getAvgByCourse()
        {
            SqlCommand cmd = new SqlCommand("select Course.Course_Name,AVG(Score.student_score) As AverageGrade from Course, Score where Course.Course_ID = Score.course_id GROUP BY Course.Course_Name");
            con.connect();
            cmd.Connection = con.connection;
            //cmd.CommandText = "select Course.Course_Name,AVG(Score.student_score) As AverageGrade from Course, Score where Course.Course_ID = Score.course_id GROUP BY Course.Course_Name";
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ta = new DataTable();
            ad.Fill(ta);
            return ta;
        }
        public bool deleteScore(int sid, int cid)
        {
            SqlCommand cmd = new SqlCommand("delete from Score where student_id = @sid And course_id = @cid", con.connection);
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = sid;
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = cid;
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
        public DataTable getScore()
        {
            SqlCommand cmd = new SqlCommand("select *from Score");
            con.connect();
            cmd.Connection = con.connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getCourse()
        {
            SqlCommand cmd = new SqlCommand("select *from Course");
            con.connect();
            cmd.Connection = con.connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getCourseByID(int id)
        {
            SqlCommand cmd = new SqlCommand("select *from Course where course_id = " + id);
            con.connect();
            cmd.Connection = con.connection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM score WHERE id = @id", con.connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
        public DataTable getStudentScore()
        {
            SqlCommand command = new SqlCommand();
            con.connect();
            command.Connection = con.connection;
            command.CommandText = "SELECT std.id, std.fname, std.lname, Course.Course_ID, Course.Course_Name, Score.student_score " + "\r\n" +
                "FROM std INNER JOIN score ON Score.student_id = std.id" + "\r\n" +
                "INNER JOIN Course ON Score.course_id = Course.Course_ID ";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}

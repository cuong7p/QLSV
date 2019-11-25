using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace Login_
{
    class DataProvider
    {
        private static string connectionstring = "Data Source=DESKTOP-9L94EI5;Initial Catalog=tbl_user;Integrated Security=True";
        SqlConnection m_connect;
        public SqlConnection connection
        {
            get { return m_connect; }
            set { m_connect = value; }
        }
        public void connect()
        {
            try
            {
                if (m_connect == null) m_connect = new SqlConnection(connectionstring);
                if (m_connect.State != System.Data.ConnectionState.Closed) m_connect.Close();
                m_connect.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void disconnect()
        {
            try
            {
                if (m_connect != null && m_connect.State == System.Data.ConnectionState.Open) ;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable executeQuery(string sqlstr, CommandType type, SqlParameter[,] parameters)
        {
            try
            {
                connect();
                SqlCommand cmd = m_connect.CreateCommand();
                cmd.CommandText = sqlstr;
                cmd.CommandType = type;
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ma Da Ton Tai Hoac Xoa Thong Tin Lien Quan Truoc( Loi Khai Ngoai)");
                throw ex;
            }
            finally
            {
                disconnect();
            }
        }
        public int executenonQuery(string sqlstr, CommandType type, SqlParameter[,] parameters)
        {
            try
            {
                connect();
                SqlCommand cmd = m_connect.CreateCommand();
                cmd.CommandText = sqlstr;
                cmd.CommandType = type;
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                disconnect();
            }
        }
    }
}

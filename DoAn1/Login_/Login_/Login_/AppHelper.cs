using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Login_
{
    class AppHelper
    {
        public static void loadDataTo_Combobox(ref ComboBox c, DataProvider dp, string spName, string value, string display, SqlParameter[,] parameters)
        {
            c.DataSource = new DataTable();
            if (parameters == null)
                c.DataSource = dp.executeQuery(spName, CommandType.StoredProcedure, null);
            else
                c.DataSource = dp.executeQuery(spName, CommandType.StoredProcedure, parameters);

            c.ValueMember = value;
            c.DisplayMember = display;
        }
        public static void loadDataToTextBox(ref TextBox txt, ref DataProvider dp, string spName, SqlParameter[,] parameters)
        {
            DataTable dtTemp = new DataTable();
            if (parameters == null)
                dtTemp = dp.executeQuery(spName, CommandType.StoredProcedure, null);
            else
                dtTemp = dp.executeQuery(spName, CommandType.StoredProcedure, parameters);

            if (dtTemp.Rows.Count > 0)
                txt.Text = dtTemp.Rows[0].ToString();
        }
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            int i;
            for (i = 0; i <= data.Length - 1; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }
    }
}

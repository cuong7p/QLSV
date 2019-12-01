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
    class Contact
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }  
        public int groupid { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int userid { get; set; }
        public MemoryStream pic { get; set; }

        public void contact() { }
        public void contact(int id, string fname, string lname, string phone, string email, string address, int userid,int groupid, MemoryStream pic)
        {
            this.id = id;
            this.fname = fname;
            this.lname = lname;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.userid = userid;
            this.pic = pic;
        }



        MyDb con = new MyDb();
        public bool insertContact(int id, string fname, string lname, string phone, string address, string email, int userid, int groupid, MemoryStream picture)
        {
            SqlCommand cm = new SqlCommand("insert into mycontact (id , fname , lname , group_id , phone , address , pic , userid , email ) values (@id, @fn, @ln, @grp, @phn, @adrs, @pic, @uid, @mail)", con.getConnection);
            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cm.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cm.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cm.Parameters.Add("@grp", SqlDbType.NChar).Value = groupid;
            cm.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            cm.Parameters.Add("@mail", SqlDbType.NChar).Value = email;
            cm.Parameters.Add("@adrs", SqlDbType.Text).Value = address;
            cm.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            cm.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            con.openConnection();
            if(cm.ExecuteNonQuery()==1)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        }
        public bool updateContact(int contactid, string fname, string lname, string phone, string address, string email, int groupid, MemoryStream picture)
        {
            SqlCommand cm = new SqlCommand("update mycontact set fname=@fn, lname=@ln, group_id=@gid, phone=@phn, address=@adrs, pic=@pic, email=@mail where id=@ID ", con.getConnection);
            cm.Parameters.Add("@ID", SqlDbType.Int).Value = contactid;
            cm.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cm.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cm.Parameters.Add("@gid", SqlDbType.NChar).Value = groupid;
            cm.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            cm.Parameters.Add("@mail", SqlDbType.NChar).Value = email;
            cm.Parameters.Add("@adrs", SqlDbType.Text).Value = address;
            cm.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            con.openConnection();
            if(cm.ExecuteNonQuery()==1)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        }

        public bool deleteContact(int contactid)
        {
            SqlCommand cm = new SqlCommand("DELETE from mycontact where id=@id", con.getConnection);
            cm.Parameters.Add("@id", SqlDbType.Int).Value = contactid;
            con.openConnection();
            if(cm.ExecuteNonQuery()==1)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        }
        public DataTable SelectContactList(SqlCommand cm)
        {
            cm.Connection = con.getConnection;
            SqlDataAdapter ad = new SqlDataAdapter(cm);
            DataTable table = new DataTable();
            ad.Fill(table);
            return table;
        }
        public DataTable GetContactById(int contactid)
        {
            SqlCommand cm = new SqlCommand("select id , fname , lname , group_id , phone , address , pic , userid, email from mycontact where id=@id", con.getConnection);
            cm.Parameters.Add("@id", SqlDbType.Int).Value = contactid;
            SqlDataAdapter ad = new SqlDataAdapter(cm);
            DataTable table = new DataTable();
            ad.Fill(table);
            return table;
        }
    }
}

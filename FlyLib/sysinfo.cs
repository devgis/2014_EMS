/*************************************************************************************
 * Author:fly
 * Date:20090612
 * QQ:421666621
 * E-mail:yafei@post.com
 * Ver:1.0.0
 * Operation:
 * Description:�˴�������о���������ҵʹ������ϵ���߱��ˣ���ӭ��ҽ�bug�ͽ���㱨��fly��
 * ͬʱ�˴������°汾������http://mian8king.bokee.com��������أ�
 * fly@ 2009 All rights reserved
 * lastedit:
 * ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace flylib
{
    public class sysinfo
    {
        public static string constr;
        string localstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\config.cfg;Persist Security Info=True;User ID=admin;Jet OLEDB:Database Password=850306";
        public sysinfo()
        {
            constr = this.getconstr();
        }

        /**************************************************************************************
         * string getconstr(int sel)���ڷ������ӱ��������ַ����������ݿ����ƣ�����int sel��ֵ
         * �������֣����selΪ0�򷵻����ݿ����ƣ����������ֵ�򷵻������ַ���
         * *************************************************************************************/
        public string getconstr()
        {
            string selconid = "select value from info where id='1'";
            string constrid;

            OleDbConnection con = new OleDbConnection(localstring); 
            OleDbCommand conidcmd=new OleDbCommand(selconid,con);
            con.Open();
            OleDbDataReader reader = conidcmd.ExecuteReader();
            reader.Read();
            constrid = reader[0].ToString();
            con.Close();

            string selconinfo = string.Format("select * from dbconfig where id='{0}'", constrid);
            OleDbCommand constrcmd = new OleDbCommand(selconinfo, con);
            con.Open();
            OleDbDataReader readerconinfo = constrcmd.ExecuteReader();
            readerconinfo.Read();
            switch (constrid)
            {
                case "1":
                    constr = string.Format("Data Source='{0}';Initial Catalog='{1}';User ID='{2}';Password='{3}'", readerconinfo[1].ToString(), readerconinfo[2].ToString(), readerconinfo[3].ToString(), readerconinfo[4].ToString());
                    break;
                case "2":
                    constr = string.Format("Data Source='{0}';Initial Catalog='{1}';Integrated Security=True", readerconinfo[1].ToString(), readerconinfo[2].ToString());
                    break;
                case "3":
                    constr = readerconinfo[5].ToString();
                    break;
            }
            con.Close();
            return constr;
        }
        public SqlConnection getcon()
        {
            SqlConnection con = new SqlConnection(constr);
            return con;
        }
        public bool setlocalinfo(string sqlstr)
        {
            OleDbConnection con = new OleDbConnection(localstring);
            OleDbCommand cmd=new OleDbCommand(sqlstr,con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }
    }
}

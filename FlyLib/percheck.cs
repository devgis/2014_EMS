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
using System.Data;
using System.Data.SqlClient;

namespace flylib
{
    public class percheck
    {
        exsql eq = new exsql();
        string sqlcheckstr;

        public int check(string username,int id,int deep)
        {
            int uid = eq.selid(username, 0);
            int resultno;
            if (deep==0) //Ȩ�޼��
            {
                sqlcheckstr = string.Format("select count(*) from userper where(userid={0} and authorityid={1})",uid,id);
            }
            else
            {
                if (deep == 1)
                {
                    sqlcheckstr = string.Format("select count(*) from userper where(userid={0} and subauthorityid={1})", uid, id);
                }
                else
                {
                    sqlcheckstr = string.Format("select count(*) from userper where (userid={0} and roleid={1})", uid, id);
                }
            }

            SqlDataReader reader = eq.excutereader(sqlcheckstr);
            reader.Read();
            resultno = Convert.ToInt32(reader[0]);
            reader.Close();

            if (resultno > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int usercheck(string username,string userpassword)
        {
            /**********************************************************************
             * �����û��������Լ��û�״̬
             * 0,������ȷ״̬������1���û���Ϊ�գ�2������Ϊ�գ�
             * 3�����ݿ��쳣���߼�¼�����ڣ�
             * 4���������5���û�������
             * ********************************************************************/

            if (username == "")
            {
                return 1; //�û���Ϊ��
            }
            else
            {
                if (userpassword == "")
                {
                    return 2; //����Ϊ��
                }
                else
                {
                    string selstr=string.Format("select userpassword from [user] where username='{0}'",username);//��ѯ�û��������
                    string selstr1 = string.Format("select userstate from [user] where username='{0}'",username);//��ѯ�û�״̬���
                    SqlDataReader reader = eq.excutereader(selstr);
                    if (reader.Read())//������ڸ��û����ļ�¼
                    {
                        if (reader[0].ToString() == userpassword) //������ȷ
                        {
                            reader.Close();
                            SqlDataReader reader1=eq.excutereader(selstr1);
                            if(reader1.Read())
                            {
                                if (Convert.ToInt32(reader1[0]) == 1)
                                {
                                    reader1.Close();
                                    return 0;
                                }
                                else
                                {
                                    reader1.Close();
                                    return 5;    //�û�������
                                }
                            }
                            else
                            {
                                return 3; //���ݿ��쳣,��¼��������ʾ��ʾ��
                            }
                        }
                        else����
                        {
                            reader.Close();
                            return 4; //���������ʾ��ʾ��
                        }
                    }
                    else����
                    {
                        reader.Close();
                        return 3; //���ݿ��쳣,��¼��������ʾ��ʾ��
                    }          
                }
            }
        }
    }
}

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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using flylib;

namespace authmanager
{
    public partial class adduser : Form
    {
        public string username;
        
        exsql eq = new exsql();
        public adduser()
        {
            InitializeComponent();
        }

        private void adduser_Load(object sender, EventArgs e)
        {
            string cmdstr = "select role from role";
            SqlDataReader reader=eq.excutereader(cmdstr);
            while (reader.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Text = reader[0].ToString();
                treeView1.Nodes.Add(tn);
            }
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //����û����Ƿ���ڣ��粻����������û��û�������ѡ��Ľ�ɫ���ڸ��û���
            if (textBox1.Text != "")
            {
                string cmdstr = string.Format("select count(*) from [user] where username='{0}'", textBox1.Text.Trim());
                SqlDataReader reader = eq.excutereader(cmdstr);
                reader.Read();
                int count = Convert.ToInt32(reader[0].ToString());
                if (count == 0)
                {
                    cmdstr = string.Format("insert into [user](username,userpassword,userstate)values('{0}','{1}',{2})", textBox1.Text, textBox2.Text, 0);
                    eq.excutesql(cmdstr);
                    int uid = eq.selid(textBox1.Text,0);
                    foreach (TreeNode td in treeView1.Nodes)
                    {
                        if (td.Checked)
                        {
                            int rid = eq.selid(td.Text, 1);
                            string instr = string.Format("insert into userrole(userid,roleid)values({0},{1})", uid, rid);
                            eq.excutesql(instr);
                        }
                    }

                    MessageBox.Show("����ɹ���");
                    username = this.textBox1.Text;
                    this.DialogResult =DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("�û����Ѵ��ڣ�");
                    textBox1.Text = "";
                }

            }
            else
            {
                MessageBox.Show("�������û���!");
            }
        }
    }
}
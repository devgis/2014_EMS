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
    public partial class newrole : Form
    {
        exsql eq = new exsql();
        public newrole()
        {
            InitializeComponent();
        }

        private void newrole_Load(object sender, EventArgs e)
        {
            string cmdstr = "select authority from authority";
            SqlDataReader reader = eq.excutereader(cmdstr);
            while (reader.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Text = reader[0].ToString();
                treeView1.Nodes.Add(tn);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string cmdstr = string.Format("select count(*) from role where role='{0}'", textBox1.Text.Trim());
                SqlDataReader reader = eq.excutereader(cmdstr);
                reader.Read();
                int count = Convert.ToInt32(reader[0].ToString());
                if (count == 0)
                {
                    cmdstr = string.Format("insert into role(role,other)values('{0}','{1}')", textBox1.Text, textBox2.Text, 0);
                    eq.excutesql(cmdstr);
                    int rid = eq.selid(textBox1.Text,1);
                    foreach (TreeNode td in treeView1.Nodes)
                    {
                        if (td.Checked)
                        {
                            int aid = eq.selid(td.Text,2);
                            string instr = string.Format("insert into roleauthority(roleid,authorityid)values({0},{1})",rid,aid);
                            eq.excutesql(instr);
                        }
                    }

                    MessageBox.Show("����ɹ���");
                }
                else
                {
                    MessageBox.Show("�����Ѵ��ڣ�");
                    textBox1.Text = "";
                }

            }
            else
            {
                MessageBox.Show("�������ɫ����");
            }
        }
    }
}
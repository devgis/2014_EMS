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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using flylib;

namespace authmanager
{
    public partial class changepassword : Form
    {
        public string seluser;
        exsql eq = new exsql();
        public changepassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = string.Format("update [user] set userpassword='{0}' where username='{1}'", textBox2.Text, label5.Text);
            eq.excutesql(cmdstr);
            MessageBox.Show("���ĳɹ�");
            this.Close();

        }

        private void changepassword_Load(object sender, EventArgs e)
        {
            label5.Text = seluser;
        }
    }
}
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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            percheck pk = new percheck();
            string username = textBox1.Text;
            int signid=pk.usercheck(textBox1.Text.Trim(), textBox2.Text.Trim());
            switch(signid)
            {
                case 0:
                    textBox1.Text = "";
                    textBox2.Text = "";
                    //main mn = new main();
                    //mn.sysusername = username;
                    main mn = new main();
                    this.Hide();
                    mn.Show();
                    break;
                case 1:
                    MessageBox.Show("�û�������Ϊ�գ�");
                    break;
                case 2:
                    MessageBox.Show("���벻��Ϊ�գ�");
                    break;
                case 3:
                    MessageBox.Show("���ݿ��쳣,���ߵ�ǰ��¼�����ڣ�");
                    break;
                case 4:
                    MessageBox.Show("�û��������");
                    break;
                case 5:
                    MessageBox.Show("���û��ѱ����ã�");
                    break;
                default:
                    MessageBox.Show("δ֪����");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;//���ûس���ʱʹ�õİ�Ŧ
        }

        private void label4_Click(object sender, EventArgs e)
        {
    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connectset csn = new connectset();
            csn.Show();
        }
    }
}
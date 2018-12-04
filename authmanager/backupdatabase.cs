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
using System.IO;
using flylib;

namespace authmanager
{
    public partial class backupdatabase : Form
    {
        string databasename;
        flylib.sysinfo ss = new sysinfo();
        exsql eq = new exsql();

        public backupdatabase()
        {
            InitializeComponent();
            SqlConnection con = ss.getcon();
            databasename = con.Database;
            
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDSPath.Text = folderBrowserDialog1.SelectedPath.ToString().Trim() + "\\";
        }

        private void btnDStore_Click(object sender, EventArgs e)
        {
            if (txtDSPath.Text == "")
            {
                MessageBox.Show("��ѡ��·����");
            }
            else
            {
                try
                {
                    if (File.Exists(txtDSPath.Text.Trim() + ".bak"))
                    {
                        MessageBox.Show("���ļ��Ѿ����ڣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDSPath.Text = "";
                        txtDSPath.Focus();
                    }
                    else
                    {
                        btnDStore.Enabled = false;
                        btnExit.Enabled = false;
                        eq.excutesql("backup database " + databasename + " to disk='" + txtDSPath.Text.Trim() + "flyauth" + DateTime.Now.ToString("DByyyyMMddhhmmss") + ".bak'");
                        MessageBox.Show("���ݱ��ݳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnDStore.Enabled = true;
                        btnExit.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
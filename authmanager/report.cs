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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            exsql eq=new exsql();
            string rstr = "SELECT [user].username, role.role, authority.authority, subauthority.subauthority FROM [user] INNER JOIN userper ON [user].userid = userper.userid INNER JOIN role ON userper.roleid = role.roleid INNER JOIN authority ON userper.authorityid = authority.authorityid INNER JOIN subauthority ON userper.subauthorityid = subauthority.subauthorityid INNER JOIN userrole ON [user].userid = userrole.userid AND role.roleid = userrole.roleid INNER JOIN roleauthority ON role.roleid = roleauthority.roleid AND authority.authorityid = roleauthority.authorityid INNER JOIN authsub ON authority.authorityid = authsub.authorityid AND subauthority.subauthorityid = authsub.subauthorityid";
            DataSet ds = eq.excuterdataset(rstr);

            uras rpt = new uras();
            rpt.SetDataSource(ds.Tables[0]);

            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
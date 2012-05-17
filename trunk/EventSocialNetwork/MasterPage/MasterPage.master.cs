using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Page_MasterPage : System.Web.UI.MasterPage
{
    AccountBLL accBLL = new AccountBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userInfo"] != null)
        {
            Response.Redirect("personalpage.aspx");
        }
    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        if (accBLL.CheckLoginInfor(txtEmail.Text, txtPwd.Text) == true)
        {
            AccountInfo acc = accBLL.Login(txtEmail.Text, txtPwd.Text);
            if (acc != null)
            {
                Session["userInfo"] = acc;
                Response.Redirect("personalpage.aspx");
            }
        }
    }
}

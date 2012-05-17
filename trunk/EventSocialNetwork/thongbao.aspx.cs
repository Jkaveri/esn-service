using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_side_Thongbao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ESNDataContext context = new ESNDataContext();
        var q = context.AccountInfos.SingleOrDefault(f => f.VerificationCode == Request.QueryString["code"].ToString());
        if(q != null)
        {
            q.Status = 1;
            context.SubmitChanges();
        }
        else
        {
            Response.Redirect("home.aspx");
        }
    }
}
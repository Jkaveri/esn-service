using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class message : System.Web.UI.Page
{
    ActivityBLL actiBLL = new ActivityBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["ID"] = ((AccountInfo)Session["userInfo"]).AccID;
            LoadInvitationMsg();
        }
    }

    private void LoadInvitationMsg()
    {
        List<GetInvitationResult> list = actiBLL.LoadInvitationMsg(int.Parse(ViewState["ID"].ToString()));
        lvInvitation.DataSource = list;
        lvInvitation.DataBind();
    }

    protected void Action(object sender, ListViewCommandEventArgs e)
    {
        string[] argument = e.CommandArgument.ToString().Split('&');
        int accID = int.Parse(ViewState["ID"].ToString());
        int friendID = int.Parse(argument[0]);
        int actiID = int.Parse(argument[1]);
        if (e.CommandName.Equals("cmdAgree"))
        {
            actiBLL.AgreeFriendShip(accID, friendID, actiID);
            LoadInvitationMsg();
        }
        else if (e.CommandName.Equals("cmdDisagree"))
        {
            actiBLL.DisagreeFriendShip(accID, friendID, actiID);
            LoadInvitationMsg();
        }
    }
    protected string SetAvatar(string path)
    {
        if (path.Contains("http"))
        {
            return path;
        }
        else
        {
            return @"Images/interface/" + path;
        }
    }
}
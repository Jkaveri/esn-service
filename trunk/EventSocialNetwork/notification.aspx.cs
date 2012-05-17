using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class notification : System.Web.UI.Page
{
    ActivityBLL actiBLL = new ActivityBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["ID"] = ((AccountInfo)Session["userInfo"]).AccID;
            LoadNotificationMsg();
        }
    }

    private void LoadNotificationMsg()
    {
        List<GetNotificationResult> list = actiBLL.LoadNotificationMsg(int.Parse(ViewState["ID"].ToString()));
        lvNotification.DataSource = list;
        lvNotification.DataBind();
    }
    protected void Action(object sender, ListViewCommandEventArgs e)
    {
        
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
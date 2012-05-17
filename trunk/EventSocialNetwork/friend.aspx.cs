using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class friend : System.Web.UI.Page
{
    RelationBLL relBLL = new RelationBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["ID"] = ((AccountInfo)Session["userInfo"]).AccID;
            LoadFriend();
        }
    }

    private void LoadFriend()
    {
        List<GetFriendListResult> list= relBLL.GetFriendList(int.Parse(ViewState["ID"].ToString()));
        lvFriend.DataSource = list;
        lvFriend.DataBind();
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


    protected string setIcon(bool status)
    {
        if (status == true)
        {
            return "online.jpg";
        }
        else
        {
            return "offline.png";
        }
    }

    protected void Action(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("cmdUnFriend"))
        {
            int accID = int.Parse(ViewState["ID"].ToString());
            int friendID = int.Parse(e.CommandArgument.ToString());
            string msg = relBLL.UnFriend(accID, friendID);
            Response.Write("<script>alert('" + msg + "')</script>");
            LoadFriend();
            //Response.Write("<script>Sexy.error('SEXY!', $time); return false;</script>");

        }
    }
}
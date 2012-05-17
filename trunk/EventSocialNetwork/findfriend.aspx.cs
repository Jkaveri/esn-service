using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class findfriend : System.Web.UI.Page
{
    RelationBLL relBLL = new RelationBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["ID"] = ((AccountInfo)Session["userInfo"]).AccID;
    }

    protected void MakeFriendShip(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("cmdMakeFriendShip"))
        {
            int accID = int.Parse(ViewState["ID"].ToString());
            int friendID = int.Parse(e.CommandArgument.ToString());
            string msg = relBLL.SendFriendShipMessage(accID, friendID);
            Response.Write("<script>alert('" + msg + "')</script>");
            //Response.Write("<script>Sexy.error('SEXY!', $time); return false;</script>");
            
        }
    }


    protected void SearchFrinend(object sender, EventArgs e)
    {
        lvFriend.DataSource = relBLL.SearchFriend(txtKeyword.Text, int.Parse(ViewState["ID"].ToString()));
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

}
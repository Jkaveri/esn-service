using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Master_Page_logined : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["userInfo"] == null & Page.Request.Url.AbsolutePath.EndsWith("personalpage.aspx") == false)
        {
            Response.Redirect("home.aspx");
        }
        else if (Session["userInfo"] != null)
        {
            lblName.Text = ((AccountInfo)Session["userInfo"]).Name;
            if (((AccountInfo)Session["userInfo"]).Avatar.Contains("http"))
            {
                imgAvatar.ImageUrl = ((AccountInfo)Session["userInfo"]).Avatar;
            }
            else
            {
                imgAvatar.ImageUrl = @"~/Images/interface/" + ((AccountInfo)Session["userInfo"]).Avatar;
            }
        }
    }

    protected void LogOut(object sender, EventArgs e)
    {
        string accessToken = ((AccountInfo)Session["userInfo"]).AccessToken;
        Session.Remove("userInfo");
        if (accessToken != null)
        {
            Response.Redirect("https://www.facebook.com/logout.php?next=" + ConfigurationManager.AppSettings["Redirect_URI"] + "&access_token=" + accessToken);
        }
        else
        {
            Response.Redirect("home.aspx");
        }
        
    }
}

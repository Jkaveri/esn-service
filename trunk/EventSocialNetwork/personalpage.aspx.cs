using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class personalpage : System.Web.UI.Page
{
    AccountBLL accBLL = new AccountBLL();

    public void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["code"] != null)
            {
                CheckFBAcc(Request.QueryString["code"]);
            }
        }
        if (Session["userInfo"] == null)
        {
            Response.Redirect("home.aspx");
        }
    }

    private void CheckFBAcc(string code)
    {
        try
        {
            AccountInfo result = accBLL.CheckFBAcc(code);
            if (result == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                Session["userInfo"] = result;
                ShowNameAndAvatar();

                //HttpCookie userInfo = new HttpCookie("tempUserInfo");
                //userInfo.Values["accID"] = Convert.ToString(result.AccID);
                //userInfo.Values["name"] = result.Name;
                //userInfo.Values["email"] = result.Account.Email;
                //userInfo.Values["avatar"] = result.Avatar;
                //userInfo.Values["accessToken"] = result.AccessToken;
                //userInfo.Expires = DateTime.Now.AddDays(1);
                //Response.Cookies.Add(userInfo);
            }
        }
        catch (Exception)
        {
            Response.Redirect("home.aspx");
        }
        
    }

    private void ShowNameAndAvatar()
    {
        Image imgAvatar = (Image)Page.Master.FindControl("imgAvatar");
        if (((AccountInfo)Session["userInfo"]).Avatar.Contains("http"))
        {
            imgAvatar.ImageUrl = ((AccountInfo)Session["userInfo"]).Avatar;
        }
        else
        {
            imgAvatar.ImageUrl = @"~/Images/interface/" + ((AccountInfo)Session["userInfo"]).Avatar;
        }
        Label lblName = (Label)Page.Master.FindControl("lblName");
        lblName.Text = ((AccountInfo)Session["userInfo"]).Name;
    }
}
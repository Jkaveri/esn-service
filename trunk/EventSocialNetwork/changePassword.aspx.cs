using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class changePassword : System.Web.UI.Page
{
    AccountBLL accBLL = new AccountBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((AccountInfo)Session["userInfo"]).Avatar.Contains("http") &&
            accBLL.CheckOldPassword((AccountInfo)Session["userInfo"], null)) //Error here
        {
            txtOldPassword.Visible = false;
            txtRePass.Visible = false;
        }
        else if (((AccountInfo)Session["userInfo"]).Avatar.Contains("http"))
        {
            txtOldPassword.Visible = true;
            txtRePass.Visible = true;
        }
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        lblValidateShow.Visible = true;
        if (txtNewPassword.Text == "")
        {
            lblValidateShow.Text = "Vui lòng điền đầy đủ thông tin";
        }
        else if (txtOldPassword.Text != txtRePass.Text)
        {
            lblValidateShow.Text = "Mật khẩu nhập lại chưa đúng";
        }
        else if (txtNewPassword.Text.Length <= 4)
        {
            lblValidateShow.Text = "Mật khẩu phải chứa ít nhất 5 ký tự";
        }
        else
        {
            if (accBLL.CheckOldPassword((AccountInfo)Session["userInfo"],
                FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPassword.Text, "MD5")) == true)
            {
                accBLL.InsertNewPassword((AccountInfo)Session["userInfo"], txtNewPassword.Text);
                Response.Redirect("AnnounChangePassword.aspx");
            }
            else
            {
                lblValidateShow.Text = "Mật khẩu nhập không đúng";
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblValidateShow.Visible = false;
        txtNewPassword.Text = "";
        txtOldPassword.Text = "";
        txtRePass.Text = "";
    }
}
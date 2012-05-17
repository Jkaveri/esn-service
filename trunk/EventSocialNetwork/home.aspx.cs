using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Web.Security;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class Client_side_home1 : System.Web.UI.Page
{
    AccountBLL accBLL = new AccountBLL();
    int year, month;
    string codeActive;

    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList AllYear = new ArrayList();
        int i;
        for (i = 2012; i >= 1900; i--)
        {
            AllYear.Add(i);
        }
        ArrayList AllMonth = new ArrayList();
        for (i = 1; i <= 12; i++)
        {
            AllMonth.Add(i);
        }
        if (!this.IsPostBack)
        {
            ddlYearOfBirth.DataSource = AllYear;
            ddlYearOfBirth.DataBind();
            ddlMonthOfBirth.DataSource = AllMonth;
            ddlMonthOfBirth.DataBind();
            year = Int32.Parse(ddlYearOfBirth.SelectedValue);
            month = Int32.Parse(ddlMonthOfBirth.SelectedValue);
            BindDays(year, month);
        }
    }

    //judge leap year
    private bool CheckLeap(int year)
    {
        if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //binding every day of month
    private void BindDays(int year, int month)
    {
        int i;
        ArrayList AllDay = new ArrayList();
        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                for (i = 1; i <= 31; i++)
                {
                    AllDay.Add(i);
                }
                break;
            case 2:
                if (CheckLeap(year))
                {
                    for (i = 1; i <= 29; i++)
                    {
                        AllDay.Add(i);
                    }
                }
                else
                {
                    for (i = 1; i <= 28; i++)
                    {
                        AllDay.Add(i);
                    }
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                for (i = 1; i <= 30; i++)
                {
                    AllDay.Add(i);
                }
                break;
        }
        ddlDayOfBirth.DataSource = AllDay;
        ddlDayOfBirth.DataBind();
    }

    protected void ddlMonthOfBirth_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Int32.Parse(ddlYearOfBirth.SelectedValue);
        month = Int32.Parse(ddlMonthOfBirth.SelectedValue);
        BindDays(year, month);
    }
    protected void ddlYearOfBirth_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Int32.Parse(ddlYearOfBirth.SelectedValue);
        month = Int32.Parse(ddlMonthOfBirth.SelectedValue);
        BindDays(year, month);
    }

    //Ham gui email
    protected void SendEmail()
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress("eventsocialnetwork@gmail.com");
        message.To.Add(new MailAddress(txtEmail.Text));
        message.CC.Add(new MailAddress("eventsocialnetwork@gmail.com"));
        message.Subject = "Email xác nhận đăng ký mạng sự kiện xã hội";
        message.Body = "Vui lòng nhấn vào đường dẫn dưới đây để xác nhận đăng ký \n";
        message.Body += ConfigurationManager.AppSettings["Confirm_URL"] + "?code=" + codeActive;
        try
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            //khai báo tài khoản và mật khẩu gửi mail
            NetworkCredential credentials = new NetworkCredential("eventsocialnetwork@gmail.com", "@aptech32d2");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            client.Send(message); //thực hiện gửi mail
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi " + ex.ToString());
        }
    }

    //Validated email function

    protected bool validEmail(String email)
    {
        Regex pattern = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        if (pattern.IsMatch(email))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        lblValidateShow.Visible = true;
        if (txtName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtRePassWord.Text == "")
        {
            lblValidateShow.Text = "Vui lòng điền đầy đủ thông tin";
        }
        else if (!validEmail(txtEmail.Text))
        {
            lblValidateShow.Text = "Email bạn nhập không đúng";
        }
        else if (txtPassword.Text.Length <= 4)
        {
            lblValidateShow.Text = "Mật khẩu phải chứa ít nhất 5 ký tự";
        }
        else if (txtPassword.Text != txtRePassWord.Text)
        {
            lblValidateShow.Text = "Mật khẩu nhập lại chưa đúng";
        }
        else
        {
            Account acc = new Account();
            acc.Email = txtEmail.Text;
            acc.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
            acc.RoleID = 3;

            acc.AccountInfo = new AccountInfo();
            acc.AccountInfo.Name = txtName.Text;
            acc.AccountInfo.DayCreate = DateTime.Now;
            acc.AccountInfo.DateOfBirth = Convert.ToDateTime(ddlMonthOfBirth.SelectedValue.ToString() + "/" +
                ddlDayOfBirth.SelectedValue.ToString() + "/" + ddlYearOfBirth.SelectedValue.ToString());
            acc.AccountInfo.Gender = (ddlGender.SelectedValue.ToString()).Equals("Nam") ? true : false;
            string verificationCode = Guid.NewGuid().ToString();
            acc.AccountInfo.VerificationCode = verificationCode;
            acc.AccountInfo.Avatar = "DefaultAvatar.jpg";
            acc.AccountInfo.IsOnline = false;

            bool rs = accBLL.Register(acc);
            if (rs == true)
            {
                lblValidateShow.Text = "Đăng ký thành công! Hãy kiểm tra email để kích hoạt tài khoản";
                codeActive = verificationCode;
                SendEmail();
            }
            else
            {
                lblValidateShow.Text = "Email đã được sử dụng";
            }
        }
    }
}
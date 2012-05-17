using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Configuration;
using Facebook;
using System.Web.Security;

/// <summary>
/// Summary description for UserDAL
/// </summary>
public class AccountBLL
{
    AccountDAL accDAL = new AccountDAL();

    public AccountBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public AccountInfo CheckFBAcc(string code)
    {
        dynamic result = GetFBData(code);
        AccountInfo acc = new AccountInfo();
        if (result == null)
        {
            return null;
        }
        else
        {
            return InsertNewFBACC(result);
        }
        return acc;
    }

    public dynamic GetFBData(string code)
    {
        WebClient wc = new WebClient();
        string accessToken = wc.DownloadString("https://graph.facebook.com/oauth/access_token?client_id=" +
                            ConfigurationManager.AppSettings["AppID"] + "&redirect_uri=" +
                            ConfigurationManager.AppSettings["Redirect_URI"] + "&client_secret=" +
                            ConfigurationManager.AppSettings["AppSecret"] + "&code=" +
                            code).Split('&')[0].ToString().Split('=')[1].ToString();

        var fbClient = new FacebookClient(accessToken);
        dynamic result = fbClient.Get("me", new { fields = "name, id, email, picture, gender, location, birthday" });
        result.accessToken = accessToken;
        return result;
    }

    public AccountInfo InsertNewFBACC(dynamic result)
    {
        AccountInfo accInfo = accDAL.CheckExistingAccByEmail2(result.email);
        if (accInfo == null)
        {
            Account acc = new Account();
            acc.RoleID = 3;
            acc.Email = result.email;

            acc.AccountInfo = new AccountInfo();
            acc.AccountInfo.Name = result.name;
            acc.AccountInfo.DateOfBirth = Convert.ToDateTime(result.birthday);
            acc.AccountInfo.Gender = (((string)result.gender).Equals("male")) ? true : false;
            acc.AccountInfo.AccessToken = result.accessToken;
            acc.AccountInfo.Avatar = result.picture;
            acc.AccountInfo.DayCreate = DateTime.Now;
            acc.AccountInfo.IsOnline = true;
            acc.AccountInfo.Status = 1;
            accDAL.InsertNewAcc(acc);
            return accDAL.GetAccIDByEmail(result.email);
        }
        else
        {
            if (accInfo.Avatar.Contains("http") & accInfo.Avatar.Equals(result.picture) == false)
            {
                accDAL.UpdateAvatar(ref accInfo, result.picture);
            }
            return accInfo;
        }
    }

    public bool Register(Account acc)
    {
        if (accDAL.CheckExistingAccByEmail(acc.Email.ToString()) == false)
        {
            accDAL.InsertNewAcc(acc);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckLoginInfor(string email, string password)
    {
        if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
        {
            return true;
        }
        return false;
    }

    public AccountInfo Login(string email, string password)
    {
        AccountInfo acc = accDAL.CheckEmailAndPassword(email, FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5"));
        if (acc != null)
        {
            return acc;
        }
        return null;
    }

    public bool CheckOldPassword(AccountInfo accInfo, string password)
    {
        Account a = accDAL.GetAccount(accInfo);

        if (a.Password.ToString() == password)
        {
            return true;
        }
        return false;
    }

    //Ham insert mat khau moi
    public void InsertNewPassword(AccountInfo accInfo, string newpassword)
    {
        Account a = accDAL.GetAccount(accInfo);
        if (a != null)
        {
            a.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(newpassword, "MD5");
            accDAL.UpdateNewProperty();
        }
    }
}
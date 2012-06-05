using System;
using System.Net;
using System.Configuration;
using Facebook;

/// <summary>
/// Summary description for UserDAL
/// </summary>
/// 
namespace ESNLibrary
{
    public class AccountBLL
    {
        AccountDAL accDAL = new AccountDAL();
        Supporter sp = new Supporter();


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
        }

        public dynamic GetFBData(string code)
        {
            WebClient wc = new WebClient();
            string accessToken = wc.DownloadString("https://graph.facebook.com/oauth/access_token?client_id=" +
                                ConfigurationSettings.AppSettings["AppID"] + "&redirect_uri=" +
                                ConfigurationSettings.AppSettings["Redirect_URI"] + "&client_secret=" +
                                ConfigurationSettings.AppSettings["AppSecret"] + "&code=" +
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


        public bool Register(string email, string password, string name, string birthDay, bool gender)
        {            
            if (accDAL.CheckExistingAccByEmail(email) == false)
            {
                Account acc = new Account();
                acc.Email = email;
                acc.Password = Supporter.MD5Encrypt(password);
                acc.RoleID = 3;

                acc.AccountInfo = new AccountInfo();
                acc.AccountInfo.Name = name;
                acc.AccountInfo.DayCreate = DateTime.Now;
                acc.AccountInfo.DateOfBirth = Convert.ToDateTime(birthDay);
                acc.AccountInfo.Gender = gender;
                acc.AccountInfo.VerificationCode = Guid.NewGuid().ToString();
                acc.AccountInfo.Avatar = "default_avatar.jpg";
                acc.AccountInfo.IsOnline = false;
                acc.AccountInfo.ShareID = 1;
                acc.AccountInfo.Status = 0;

                if (sp.SendEmail(email, acc.AccountInfo.VerificationCode, 0) == true)
                {
                    accDAL.InsertNewAcc(acc);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool CheckExistingAccByEmail(string email)
        {
            return accDAL.CheckExistingAccByEmail(email);
        }

        public bool CheckLoginInfor(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
            {
                return true;
            }
            return false;
        }

        public LoginResult Login(string email, string encryptedPassword)
        {
            return accDAL.Login(email, encryptedPassword);
        }

        public bool CheckOldPassword(AccountInfo accInfo, string password)
        {
            Account a = accDAL.GetAccount(accInfo);

            if (a.Password == password)
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
                a.Password = Supporter.MD5Encrypt(newpassword);
                accDAL.UpdateNewProperty();
            }
        }

        //Ham insert thong tin moi
        public void UpdateInformation(AccountInfo accInfo, int accID)
        {
            AccountInfo a = accDAL.GetAccountInfo(accID);
            if (a != null)
            {
                a.Name = accInfo.Name;
                a.Address = accInfo.Address;
                a.Avatar = accInfo.Avatar;
                a.DateOfBirth = accInfo.DateOfBirth;
                a.Gender = accInfo.Gender;
                a.Favorite = accInfo.Favorite;
                a.Phone = accInfo.Phone;
                accDAL.UpdateNewProperty();
            }
        }

        public AccountInfo VerifyAccount(string id, string code)
        {
            AccountInfo acc = accDAL.GetAccByVerificationCode(code);
            if (Supporter.MD5Encrypt(acc.Account.Email).Equals(id))
            {
                accDAL.UpdateAccStatus(acc, 1);
                return acc;
            }
            return null;
        }

        public AccountInfo GetAccountInfo(int id)
        {
            return accDAL.GetAccountInfo(id);
        }

        public Account GetAccountForgotPassword(string email, string code)
        {
            return (accDAL.GetAccountByEmailandVerifyCode(email, code));
        }


    }
}
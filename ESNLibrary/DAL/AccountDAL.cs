using System;
using System.Collections.Generic;
using System.Linq;



/// <summary>
/// Summary description for UserDAL
/// </summary>
/// 
namespace ESNLibrary
{
    public class AccountDAL
    {
        ESNDataContext context = new ESNDataContext();

        public AccountDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public bool CheckExistingAccByEmail(string email)
        {
            var q = context.Accounts.SingleOrDefault(a => a.Email.Equals(email));
            if (q == null)
            {
                return false;
            }
            return true;
        }

        public AccountInfo CheckExistingAccByEmail2(string email)
        {
            var q = context.AccountInfos.SingleOrDefault(a => a.Account.Email.Equals(email) & a.Status == 1);
            return q;
        }

        public void InsertNewAcc(Account acc)
        {
            context.Accounts.InsertOnSubmit(acc);
            context.SubmitChanges();
        }

        public void UpdateNewProperty()
        {
            context.SubmitChanges();
        }

        public AccountInfo GetAccIDByEmail(string email)
        {
            var q = context.AccountInfos.SingleOrDefault(a => a.Account.Email.Equals(email) & a.Account.AccountInfo.Status == 1);
            return q;
        }

        public List<AccountInfo> SearchFriend(string keyword, int userID, string type)
        {
            List<AccountInfo> list;

            if (type.Equals("Name"))
            {
                list = context.AccountInfos.Where(a => (a.Name.Contains(keyword)) & a.Status == 1 & a.AccID != userID).ToList();
            }
            else
            {
                list = context.AccountInfos.Where(a => (a.Account.Email.Contains(keyword)) & a.Status == 1 & a.AccID != userID).ToList();
            }

            if (list.Count() > 0)
            {
                return list;
            }
            else
            {
                return null;
            }
        }


        public bool CheckExistingAccByID(int FriendID)
        {
            var q = context.Accounts.SingleOrDefault(a => a.AccID == FriendID & a.AccountInfo.Status == 1);
            if (q == null)
            {
                return false;
            }
            return true;
        }

        public LoginResult Login(string email, string password)
        {
            LoginResult rs = context.Login(email, password).SingleOrDefault();
            return rs;
        }

        public AccountInfo CheckEmailAndPassword(string email, string password)
        {
            AccountInfo rs = context.AccountInfos.SingleOrDefault(a => a.Account.Email.Equals(email) & a.Account.Password.Equals(password) & a.Status == 1);
            return rs;
        }


        //Ham lay ra account thao man mot sessionInfo
        public Account GetAccount(AccountInfo accInfo)
        {
            Account a = context.Accounts.SingleOrDefault(f => f.AccountInfo.Equals(accInfo));
            return a;
        }

        internal void UpdateAvatar(ref AccountInfo accInfo, string picture)
        {
            accInfo.Avatar = picture;
            context.SubmitChanges();
        }

        //Ham lay accountInfo
        public AccountInfo GetAccountInfo(int accID)
        {
            AccountInfo a = context.AccountInfos.SingleOrDefault(f => f.AccID.Equals(accID));
            return a;
        }

        public AccountInfo GetAccByVerificationCode(string code)
        {
            AccountInfo acc = context.AccountInfos.SingleOrDefault(a => a.VerificationCode.Equals(code));
            return acc;
        }

        internal void UpdateAccStatus(AccountInfo acc, int status)
        {
            acc.Status = status;
            context.SubmitChanges();
        }

        public Account GetAccountByEmailandVerifyCode(string email, string verifyCode)
        {
            var acc = context.Accounts.SingleOrDefault(a => a.Email.Equals(email) & a.AccountInfo.VerificationCode.Equals(verifyCode));
            if (acc != null)
            {
                return acc;
            }
            return null;
        }

    }
}
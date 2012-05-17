using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Summary description for SessionExt
/// </summary>
public static class SessionExt
{
    public static void SetCurrentUser(this HttpSessionState session, Account user)
    {
        session["currentUser"] = user;
    }
    public static Account GetCurrentUser(this HttpSessionState session) 
    {
        return session["currentUser"] as Account; //Trả về null nghĩa là chưa đăng nhập!
    }
}
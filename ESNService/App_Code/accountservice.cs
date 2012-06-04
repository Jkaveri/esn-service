using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ESNLibrary;
using System.Configuration;

/// <summary>
/// Summary description for accountservice
/// </summary>
[WebService(Namespace = "http://esnservice.somee.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class accountservice : System.Web.Services.WebService
{

    AccountBLL accBLL = new AccountBLL();

    public accountservice()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool Register(string email, string password, string name, string birthday, bool gender)
    {
        try
        {
            return accBLL.Register(email, password, name, birthday, gender);
        }
        catch (Exception)
        {
            return false;
        }
    }

    [WebMethod]
    public LoginResult Login(string email, string password)
    {
        try
        {
            LoginResult rs = accBLL.Login(email, password);
            if (rs.Avatar.Contains("http") == false)
            {
                rs.Avatar = ConfigurationManager.AppSettings["AvatarUrl"] + rs.Avatar;
            }
            return rs;
        }
        catch (Exception)
        {
            return null;
        }
    }
}



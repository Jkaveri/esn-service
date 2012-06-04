using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ESNLibrary;
using System.Configuration;
using System.Linq;

/// <summary>
/// Summary description for friendservice
/// </summary>
[WebService(Namespace = "http://esnservice.somee.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class friendservice : System.Web.Services.WebService
{

    RelationBLL relBLL = new RelationBLL();

    public friendservice()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public GetFriendListResult[] GetFriendList(int page, int accID)
    {
        try
        {
            GetFriendListResult[] list = relBLL.GetFriendList(accID).Skip((page - 1) * 20).Take(20).ToArray();
            foreach (GetFriendListResult item in list)
            {
                if (item.Avatar.Contains("http") == false)
                {
                    item.Avatar = ConfigurationManager.AppSettings["AvatarUrl"] + item.Avatar;
                }
            }
            return list;
        }
        catch (Exception)
        {
            return null;
        }
    }

    [WebMethod]
    public bool UnFriend(int accID, int friendID)
    {
        try
        {
            return relBLL.UnFriend(accID, friendID);
        }
        catch (Exception)
        {
            return false;
        }
    }
}

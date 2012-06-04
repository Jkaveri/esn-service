using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ESNLibrary;
using System.Configuration;

/// <summary>
/// Summary description for eventservice
/// </summary>
[WebService(Namespace = "http://esnservice.somee.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class eventservice : System.Web.Services.WebService
{


    EventBLL eveBLL = new EventBLL();

    public eventservice()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public LoadEventTypeResult[] GetEventType()
    {
        try
        {
            LoadEventTypeResult[] list = eveBLL.LoadEventType().ToArray();
            foreach (LoadEventTypeResult item in list)
            {
                item.LabelImage = ConfigurationManager.AppSettings["LabelImageUrl"] + item.LabelImage;
            }
            return list;
        }
        catch (Exception)
        {
            return null;
        }
    }

    [WebMethod]
    public LoadAllEventResult[] GetAllEvent()
    {
        try
        {
            LoadAllEventResult[] list = eveBLL.LoadAllEvent().ToArray();
            foreach (LoadAllEventResult item in list)
            {
                item.LabelImage = ConfigurationManager.AppSettings["LabelImageUrl"] + item.LabelImage;
                item.Picture = ConfigurationManager.AppSettings["EventPictureUrl"] + item.Picture;
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
    public LoadHotedEventResult[] GetHotedEvent()
    {
        try
        {
            LoadHotedEventResult[] list = eveBLL.LoadHotedEvent().ToArray();
            foreach (LoadHotedEventResult item in list)
            {
                item.LabelImage = ConfigurationManager.AppSettings["LabelImageUrl"] + item.LabelImage;
                item.Picture = ConfigurationManager.AppSettings["EventPictureUrl"] + item.Picture;
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
    public LoadNewestEventResult[] GetNewestEvent()
    {
        try
        {
            LoadNewestEventResult[] list = eveBLL.LoadNewestEvent().ToArray();
            foreach (LoadNewestEventResult item in list)
            {
                item.LabelImage = ConfigurationManager.AppSettings["LabelImageUrl"] + item.LabelImage;
                item.Picture = ConfigurationManager.AppSettings["EventPictureUrl"] + item.Picture;
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
    public loadEventResult[] GetEventInDistance(float lat, float lng, float r)
    {
        try
        {
            loadEventResult[] list = eveBLL.LoadEvent(lat, lng, r).ToArray();
            foreach (loadEventResult item in list)
            {
                item.LabelImage = ConfigurationManager.AppSettings["LabelImageUrl"] + item.LabelImage;
                item.Picture = ConfigurationManager.AppSettings["EventPictureUrl"] + item.Picture;
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

}

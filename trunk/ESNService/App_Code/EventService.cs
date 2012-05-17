using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for EventService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EventService : System.Web.Services.WebService {
    
    DBConnection db = new DBConnection();

    public EventService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public int CreateNewEvent(int accID, string evenTypeID, string title, string description, float lat, float lng)
    {
        try
        {
            return db.executeInsertQuery("CreateNewEvent", new SqlParameter[6] { new SqlParameter("@AccID", accID),   
                                                                            new SqlParameter("@EventType", evenTypeID), 
                                                                            new SqlParameter("@Title", title),  
                                                                            new SqlParameter("@Description", description), 
                                                                            new SqlParameter("@Lat", lat), 
                                                                            new SqlParameter("@Lng", lng)});
        }
        catch (FormatException)
        {
            return 2;
        }
    }

    [WebMethod]
    public DataTable LoadNewestEvent()
    {
        return db.executeSelectQuery("LoadNewestEvent", null);
    }
}

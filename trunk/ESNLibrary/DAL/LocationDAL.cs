using System;
using System.Collections.Generic;
using System.Linq;

namespace ESNLibrary
{
    public class LocationDAL
    {
        ESNDataContext context = new ESNDataContext();
        DBConnection db = new DBConnection();
        Supporter sp = new Supporter();

        public LocationDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertNewLocation(UserLocation uLoc)
        {
            context.UserLocations.InsertOnSubmit(uLoc);
            context.SubmitChanges();
        }

        public List<GetFriendLocationResult> LoadFriendLocation(int accID)
        {
            //return db.executeSelectQuery("GetFriendLocation", new SqlParameter[1] { new SqlParameter("@AccID", accID)});
            List<GetFriendLocationResult> list = context.GetFriendLocation(accID).ToList();
            //return sp.ToDataTableAsList(list);
            return list;
        }

        public List<GetHistoryLocationResult> LoadHistoryLocation(int accID)
        {
            List<GetHistoryLocationResult> list = context.GetHistoryLocation(accID).ToList();
            return list;
        }
    }
}
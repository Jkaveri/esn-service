using System;
using System.Collections.Generic;

namespace ESNLibrary
{
    public class LocationBLL
    {
        LocationDAL locDAL = new LocationDAL();

        public LocationBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void InsertNewLocation(int AccID, float Lat, float Lng)
        {
            UserLocation uLoc = new UserLocation();
            uLoc.AccID = AccID;
            uLoc.Latitude = Lat;
            uLoc.Longtitude = Lng;
            uLoc.DayCreate = DateTime.Now;
            uLoc.Status = 1;

            locDAL.InsertNewLocation(uLoc);
        }

        public List<GetFriendLocationResult> LoadFriendLocation(int AccID)
        {
            return locDAL.LoadFriendLocation(AccID);
        }

        public List<GetHistoryLocationResult> LoadHistoryLocation(int AccID)
        {
            return locDAL.LoadHistoryLocation(AccID);
        }
    }
}
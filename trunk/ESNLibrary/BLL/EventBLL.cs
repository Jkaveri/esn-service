using System;
using System.Data;
using System.Collections.Generic;

namespace ESNLibrary
{
    public class EventBLL
    {
        EventDAL eveDAL = new EventDAL();

        public EventBLL()
        {

        }

        public List<LoadNewestEventResult> LoadNewestEvent()
        {
            return eveDAL.LoadNewestEvent();
        }

        public List<LoadAllEventResult> LoadAllEvent()
        {
            return eveDAL.LoadAllEvent();
        }

        public List<LoadHotedEventResult> LoadHotedEvent()
        {
            return eveDAL.LoadHotedEvent();
        }

        public List<LoadEventInfoResult> LoadEventInfo(int eventID)
        {
            return eveDAL.LoadEventInfo(eventID);
        }

        public List<LoadEventTypeResult> LoadEventType()
        {
            return eveDAL.LoadEventType();
        }

        public List<loadEventResult> LoadEvent(float lat, float lng, float r)
        {
            return eveDAL.LoadEvent(lat, lng, r);
        }

        public bool SetLikeAndDislike(int eventID, String like, String dislike)
        {
            return eveDAL.SetLikeAndDislike(eventID, like, dislike);
        }

    }
}

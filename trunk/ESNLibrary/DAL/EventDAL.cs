using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace ESNLibrary
{
    public class EventDAL
    {
        ESNDataContext context = new ESNDataContext();

        public List<LoadNewestEventResult> LoadNewestEvent()
        {
            return context.LoadNewestEvent().ToList();
        }

        public List<LoadAllEventResult> LoadAllEvent()
        {
            return context.LoadAllEvent().ToList();
        }

        public List<loadEventResult> LoadEvent(float lat, float lng, float r)
        {
            return context.loadEvent(lat, lng, r).ToList();
        }

        public List<LoadHotedEventResult> LoadHotedEvent()
        {
            return context.LoadHotedEvent().ToList();
        }

        public List<LoadEventInfoResult> LoadEventInfo(int eventID)
        {
            List<LoadEventInfoResult> rs = context.LoadEventInfo(eventID).ToList();
            if (rs.Count == 0)
            {
                return null;
            }
            return rs;

        }

        public List<LoadEventTypeResult> LoadEventType()
        {
            List<LoadEventTypeResult> list = context.LoadEventType().ToList();
            return list;
        }


        public bool SetLikeAndDislike(int eventID, String like, String dislike)
        {
            bool rs = false;
            var q = context.EventInfos.SingleOrDefault(e => e.EventID == eventID);
            if (q != null)
            {
                q.Like = int.Parse(like);
                q.Dislike = int.Parse(dislike);
                context.SubmitChanges();
                rs = true;
            }
            return rs;
        }
    }
}

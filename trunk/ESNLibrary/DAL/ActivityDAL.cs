using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ActivityDAL
namespace ESNLibrary
{
    public class ActivityDAL
    {
        ESNDataContext context = new ESNDataContext();

        public ActivityDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        internal void InsertNewActivity(Activity acti)
        {
            context.Activities.InsertOnSubmit(acti);
            context.SubmitChanges();
        }


        public List<GetInvitationResult> LoadInvitationMsg(int userID)
        {
            List<GetInvitationResult> list = context.GetInvitation(userID).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            return list;
        }

        internal List<Activity> CheckExistingFriendShipActivity(int userID, int friendID)
        {
            List<Activity> q = context.Activities.Where(r => ((r.AccID == userID & r.FriendID == friendID) |
                                                                (r.AccID == friendID & r.FriendID == userID)) & r.ActiTypeID == 1 & r.Status == 1).ToList();
            return q;
        }

        public bool DisableActivity(int actiID)
        {
            var q = context.Activities.SingleOrDefault(a => a.ActiID == actiID & a.Status == 1);
            if (q != null)
            {
                q.Status = 0;
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool CheckExistingUnFriendShipActivity(int accID, int friendID)
        {
            var q = context.Activities.SingleOrDefault(a => a.AccID == accID & a.FriendID == friendID & a.ActiTypeID == 5 & a.Status == 1);
            if (q == null)
            {
                return true;
            }
            return false;
        }

        internal List<GetNotificationResult> LoadNotificationMsg(int userID)
        {
            List<GetNotificationResult> list = context.GetNotification(userID).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            return list;
        }
    }
}
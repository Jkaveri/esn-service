using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommentBLL
/// </summary>
namespace ESNLibrary
{
    public class CommentBLL
    {
        CommentDAL comDAL = new CommentDAL();
        ActivityDAL actiDAL = new ActivityDAL();


        public CommentBLL()
        {

        }


        public bool SendComment(AccountInfo accInfo, LoadEventInfoResult eventInfo, string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                return false;
            }
            else
            {
                Comment com = new Comment();
                com.AccID = int.Parse(accInfo.AccID.ToString());
                com.EventID = int.Parse(eventInfo.EventID.ToString());
                com.Content = comment;
                com.DayCreate = DateTime.Now;
                com.Status = true;
                comDAL.CreateComment(com);

                Activity acti = new Activity();
                acti.AccID = accInfo.AccID;
                acti.EventID = int.Parse(eventInfo.EventID.ToString());
                acti.ActiTypeID = 4;
                acti.DayCreate = DateTime.Now;
                acti.Status = 1;
                acti.Content = accInfo.Name + " đã bình luận về sự kiện " + "<a href='comment.aspx?ID=" + eventInfo.EventID + "&Lat=" + eventInfo.EventLat + "&Lng=" + eventInfo.EventLng
                                + "'>" + eventInfo.Title + "</a>";
                actiDAL.InsertNewActivity(acti);
                return true;
            }

        }

        public List<LoadCommentResult> LoadComment(int eventID)
        {
            return comDAL.LoadComment(eventID);
        }
    }
}
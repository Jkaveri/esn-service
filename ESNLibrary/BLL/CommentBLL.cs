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


        public bool SendComment(int accID, int eventID, string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                return false;
            }
            else
            {
                Comment com = new Comment();
                com.AccID = int.Parse(accID.ToString());
                com.EventID = eventID;
                com.Content = comment;
                com.DayCreate = DateTime.Now;
                com.Status = true;
                comDAL.CreateComment(com);
                return true;
                //Activity acti = new Activity();
            }

        }

        public List<LoadCommentResult> LoadComment(int eventID)
        {
            return comDAL.LoadComment(eventID);
        }
    }
}
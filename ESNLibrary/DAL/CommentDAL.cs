using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommentDAL
/// </summary>
namespace ESNLibrary
{
    public class CommentDAL
    {

        ESNDataContext context = new ESNDataContext();

        public CommentDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        internal void CreateComment(string comment)
        {

        }

        internal void CreateComment(Comment com)
        {
            context.Comments.InsertOnSubmit(com);
            context.SubmitChanges();
        }

        internal List<LoadCommentResult> LoadComment(int eventID)
        {
            List<LoadCommentResult> list = context.LoadComment(eventID).ToList();
            if (list.Count != 0)
            {
                return list;
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RelationDAL
/// </summary>
public class RelationDAL
{
    ESNDataContext context = new ESNDataContext();

    public RelationDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public List<Relation> CheckExistingRelation(int userID, int friendID)
    {
        List<Relation> q = context.Relations.Where(r => (r.AccID == userID & r.FriendID == friendID) | (r.AccID == friendID & r.FriendID == userID)).ToList();        
        return q;
    }

    public void InsertNewRelation(int accID, int friendID)
    {
        Relation rel1 = new Relation();
        rel1.AccID = accID;
        rel1.FriendID = friendID;
        rel1.RelationTypeID = 1;
        rel1.DayCreate = DateTime.Now;
        rel1.Status = 1;
        context.Relations.InsertOnSubmit(rel1);

        Relation rel2 = new Relation();
        rel2.AccID = friendID;
        rel2.FriendID = accID;
        rel2.RelationTypeID = 1;
        rel2.DayCreate = DateTime.Now;
        rel2.Status = 1;
        context.Relations.InsertOnSubmit(rel2);
        context.SubmitChanges();
    }

    public void UpdateRelation(List<Relation> listRel)
    {
        foreach (Relation rel in listRel)
        {
            rel.DayCreate = DateTime.Now;
            rel.Status = 0;
            context.SubmitChanges();
        }
    }

    public int GetRelationID(int userID, int friendID)
    {
        var q = context.Relations.SingleOrDefault(r => r.AccID == userID & r.FriendID == friendID);
        return q.RelationID;
    }

    public List<GetFriendListResult> GetFriendList(int userID)
    {
        List<GetFriendListResult> q = context.GetFriendList(userID).ToList();
        return q;
    }


    internal void UpdateRelationStatus(List<Relation> listRel, int status)
    {
        foreach (Relation rel in listRel)
        {
            rel.Status = status;
            context.SubmitChanges();
        }
    }
}
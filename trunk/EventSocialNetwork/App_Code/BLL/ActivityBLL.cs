using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ActivityBLL
/// </summary>
public class ActivityBLL
{
    ActivityDAL actiDAL = new ActivityDAL();
    RelationDAL relDAL = new RelationDAL();

	public ActivityBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void CreateNewActivity(int userID, int friendID, int type)
    {
        Activity acti = new Activity();
        acti.AccID = userID;
        acti.FriendID = friendID;
        acti.ActiTypeID = type;
        acti.DayCreate = DateTime.Now;
        acti.Status = 1;
        actiDAL.InsertNewActivity(acti);

    }

    public List<GetInvitationResult> LoadInvitationMsg(int userID)
    {
        return actiDAL.LoadInvitationMsg(userID);
    }

    public void AgreeFriendShip(int accID, int friendID, int actiID)
    {
        bool rs = actiDAL.DisableActivity(actiID);
        if (rs == true)
        {
            List<Relation> listRel = relDAL.CheckExistingRelation(accID, friendID);
            if (listRel.Count == 0)
            {
                relDAL.InsertNewRelation(accID, friendID);
                CreateNewActivity(accID, friendID, 6);
            }
            else if (listRel[0].Status == 0)
            {
                relDAL.UpdateRelationStatus(listRel, 1);
                CreateNewActivity(accID, friendID, 6);
            }
        }
    }

    public void DisagreeFriendShip(int accID, int friendID, int actiID)
    {
        bool rs = actiDAL.DisableActivity(actiID);
        if (rs == true)
        {
            if (actiDAL.CheckExistingUnFriendShipActivity(accID, friendID) == true)
            {
                CreateNewActivity(accID, friendID, 5);
            }
        }
    }


    public List<GetNotificationResult> LoadNotificationMsg(int userID)
    {
        return actiDAL.LoadNotificationMsg(userID);
    }
}
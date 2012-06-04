using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESNLibrary
{
    public class SuggestionBLL
    {
        SuggestionDAL sgestDAL = new SuggestionDAL();

        public SuggestionBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //Ham tao 1 object suggestion va insert no vao database
        public void createNewSuggestion(int accID, String suggestion, String title)
        {
            Suggestion sgest = new Suggestion();
            sgest.AccID = accID;
            sgest.Content = suggestion;
            sgest.Title = title;
            sgest.DayCreate = DateTime.Now;
            sgest.Status = 1;
            sgestDAL.insetNewSuggestion(sgest);
        }
    }
}
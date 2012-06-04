using System;
using System.Linq;

namespace ESNLibrary
{
    public class SuggestionDAL
    {
        ESNDataContext context = new ESNDataContext();

        public SuggestionDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Ham insert suggest vao database
        public void insetNewSuggestion(Suggestion sgest)
        {
            context.Suggestions.InsertOnSubmit(sgest);
            context.SubmitChanges();
        }

        public long getSgestByAccID(int accID)
        {
            var q = context.Suggestions.LongCount(a => a.Account.AccID.Equals(accID));
            return q;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AccountService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AccountService : System.Web.Services.WebService
{
    DBConnection db = new DBConnection();

    public AccountService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataTable CheckEmailAndPassword(string email, string encryptedpass)
    {
        return db.executeSelectQuery("CheckEmailAndPassword", new SqlParameter[2] { new SqlParameter("@Email", email), new SqlParameter("@Password", encryptedpass)});
    }

    [WebMethod]
    public int Register(string name, string email, string encryptedpass, bool gender, string birthDay, string verificationCode)
    {
        try 
	    {
            return db.executeInsertQuery("Register", new SqlParameter[6] { new SqlParameter("@Name", name),   
                                                                            new SqlParameter("@Email", email), 
                                                                            new SqlParameter("@Pass", encryptedpass),  
                                                                            new SqlParameter("@Gender", gender), 
                                                                            new SqlParameter("@BirthDay", Convert.ToDateTime(birthDay)), 
                                                                            new SqlParameter("@VerificationCode", verificationCode)});
	    }
	    catch (FormatException)
	    {
            return 2;
	    }        
    }
}

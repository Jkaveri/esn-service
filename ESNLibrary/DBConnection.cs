using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for DBConnection
/// </summary>
public class DBConnection
{    
    SqlConnection conn = new SqlConnection();
    SqlDataAdapter myAdapter = new SqlDataAdapter();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    int rs = 0;

    public DBConnection()
    {
        conn.ConnectionString = "workstation id=EventSocialNetwork.mssql.somee.com;packet size=4096;user id=hoangnam;pwd=nhn29121992;data source=EventSocialNetwork.mssql.somee.com;persist security info=False;initial catalog=EventSocialNetwork";
        cmd.Connection = conn;
        da.SelectCommand = cmd;
    }

    public DataTable executeSelectQuery(String spName, SqlParameter[] sqlParameter)
    {
        try
        {
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (sqlParameter != null)
            {
                cmd.Parameters.AddRange(sqlParameter);
            }
            da.Fill(ds);
        }
        catch (SqlException e)
        {
            Console.Write(e.Message);
            return null;
        }
        finally
        {

        }
        return ds.Tables[0];
    }

    public int executeInsertQuery(String spName, SqlParameter[] sqlParameter)
    {
        //0 --> trung lap du lieu: email, 1 ---> thanh cong, 2 --> co loi xay ra: duong truyen, convert
        try
        {
            conn.Open();
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(sqlParameter);
            rs = (cmd.ExecuteNonQuery() > 0) ? 1 : 0;
        }
        catch (SqlException e)
        {
            rs = 2;
        }
        finally
        {
            conn.Close();
        }
        return rs;
    }


    public int executeUpdateQuery(String spName, SqlParameter[] sqlParameter)
    {
        SqlCommand myCommand = new SqlCommand();
        try
        {
            conn.Open();
            myCommand.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddRange(sqlParameter);
            rs = (cmd.ExecuteNonQuery() > 0) ? 1 : 0;
        }
        catch (SqlException e)
        {
            Console.Write(e.Message);
        }
        finally
        {
            conn.Close();
        }
        return rs;
    }
}
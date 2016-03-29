using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void CreateOrder(SqlString firstName, SqlString lastName, SqlString custEmail, SqlInt32 phone)
    {
        SqlConnection conn = new SqlConnection("Context Connection=true");

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "Insert into Customer (FirstName, LastName, Email, Phone) Values(@firstName, @lastName, @custEmail, @phone)";
        SqlParameter ParamFName = new SqlParameter();
        SqlParameter ParamLName = new SqlParameter();
        SqlParameter ParamEmail = new SqlParameter();
        SqlParameter ParamPhone = new SqlParameter();
        ParamFName.Value = firstName;
        ParamLName.Value = lastName;
        ParamEmail.Value = custEmail;
        ParamPhone.Value = phone;
        ParamFName.Direction = ParameterDirection.Input;
        ParamLName.Direction = ParameterDirection.Input;
        ParamEmail.Direction = ParameterDirection.Input;
        ParamPhone.Direction = ParameterDirection.Input;
        ParamFName.DbType = DbType.String;
        ParamLName.DbType = DbType.String;
        ParamEmail.DbType = DbType.String;
        ParamPhone.DbType = DbType.Int32;
        ParamFName.ParameterName = "@firstName";
        ParamLName.ParameterName = "@lastName";
        ParamEmail.ParameterName = "@custEmail";
        ParamPhone.ParameterName = "@phone";
        cmd.Parameters.Add(ParamFName);
        cmd.Parameters.Add(ParamLName);
        cmd.Parameters.Add(ParamEmail);
        cmd.Parameters.Add(ParamPhone);
        SqlDataReader sqldr = cmd.ExecuteReader();
        SqlContext.Pipe.Send(sqldr);
        sqldr.Close();
        conn.Close();
    }
}
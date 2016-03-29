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
        cmd.CommandText = "Insert into Orders (FirstName, LastName, Email, Phone) Values(@firstName, @lastName, @custEmail, phone";
        SqlParameter ParamFName = new SqlParameter();
        SqlParameter ParamLName = new SqlParameter();
        SqlParameter ParamEmail = new SqlParameter();
        SqlParameter ParamPhone = new SqlParameter();
        ParamFName.Value = firstName;
        ParamLName.Value = lastName;
        ParamEmail.Value = custEmail;
        ParamPhone.Value = phone;
        paramDest.Direction = ParameterDirection.Input;
        paramDest.DbType = DbType.String;
        paramDest.ParameterName = "@dest";
        cmd.Parameters.Add(paramDest);
        SqlDataReader sqldr = cmd.ExecuteReader();
        SqlContext.Pipe.Send(sqldr);
        sqldr.Close();
        conn.Close();
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void FindCountry(SqlString dest)
    {
        //It	returns	rows	from	Employee	table	on	basis	of	supplied	age	
        SqlConnection conn = new SqlConnection("Context Connection=true");
        
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "Select Route_ID, Departure, Destination, Date	from [dbo].[Route]	Where Destination LIKE @dest + '%'";
        SqlParameter paramDest = new SqlParameter();        
        paramDest.Value = dest;
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
    


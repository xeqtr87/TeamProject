using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void ListAllRoute ()
    {
        using (SqlConnection connection = new SqlConnection("context connection=true"))
        {
            SqlCommand command = new SqlCommand("Select Departure, Destination, Date from Route");
            SqlContext.Pipe.ExecuteAndSend(command);
        }
    }
}

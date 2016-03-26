using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures {
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void GetCustomers()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand getCustomers = new SqlCommand("SELECT FirstName FROM [TravelBooking].[dbo].[Customer]", conn);
            //getcustomers.commandtext = "select * from [travelbooking].[dbo].[customer]";
            //getCustomers.Connection = conn;
            conn.Open();
            getCustomers.ExecuteNonQuery();
            SqlDataReader reader = getCustomers.ExecuteReader();
            //conn.Close();

        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SqlStoredProcedure1(string firstName)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            //SqlCommand getCustomerByFirstName = new SqlCommand("SELECT * from Customer", conn);
            //SqlParameter paramName = new SqlParameter("@FirstName", SqlDbType.NVarChar);

            //paramName.Value = firstName;

            //getCustomerByFirstName.Parameters.Add(firstName);

            //getCustomerByFirstName.CommandText = "SELECT * from Customer";


            conn.Open();
            SqlCommand getCustomerByFirstName = new SqlCommand("SELECT * from Customer", conn);
            //SqlDataReader rdr = getCustomerByFirstName.ExecuteReader();
            SqlContext.Pipe.ExecuteAndSend(getCustomerByFirstName);
            //SqlContext.Pipe.ExecuteAndSend(getCustomerByFirstName);
            //rdr.Close();
            //getCustomerByFirstName.ExecuteNonQuery();
        }
    }
}
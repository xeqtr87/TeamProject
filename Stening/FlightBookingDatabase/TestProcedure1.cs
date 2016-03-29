using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures {
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void TestProcedure1(SqlString test)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand getCustomerByFirstName = new SqlCommand("SET @FirstName ='changed'", conn);
            SqlParameter paramName = new SqlParameter("@FirstName", SqlDbType.NVarChar);

            paramName.Value = test;

            getCustomerByFirstName.Parameters.Add(test);

            //getCustomerByFirstName.CommandText = "SELECT * from Customer";

            conn.Open();
            //SqlCommand getCustomerByFirstName = new SqlCommand("SELECT * from Customer", conn);
            //SqlDataReader rdr = getCustomerByFirstName.ExecuteReader();
            SqlContext.Pipe.Send(test.ToString());
            //SqlContext.Pipe.ExecuteAndSend(getCustomerByFirstName);
            //rdr.Close();
            //getCustomerByFirstName.ExecuteNonQuery();
        }
    }
}
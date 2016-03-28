using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;

public partial class UserDefinedFunctions {

        private class FirstNameAndIDResult {
            public SqlInt32 CustomerID;
            public SqlString FirstName;


            public FirstNameAndIDResult(SqlInt32 inputID, SqlString inputName)
            {
                FirstName = inputName;
                CustomerID = inputID;
            }
        }



        [Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read,
            FillRowMethodName = "FirstNameAndID_FillRow",
            TableDefinition = "Customer_ID int, FirstName nvarchar(50)")]
        public static IEnumerable GetFirstNameAndIDByFirstName(SqlString firstName)
        {
            ArrayList ResultCollection = new ArrayList();
            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                conn.Open();

                using (SqlCommand GetCustomerByName = new SqlCommand("Select [Customer_ID], [FirstName] From Customer WHERE FirstName = @firstName ", conn))
                {
                    SqlParameter FirstNameParam = GetCustomerByName.Parameters.Add(
                       "@FirstName", SqlDbType.NVarChar);
                    FirstNameParam.Value = firstName;


                    using (SqlDataReader FirstNameReader = GetCustomerByName.ExecuteReader())
                    {
                        while (FirstNameReader.Read())
                        {
                            SqlString firstNameFind = FirstNameReader.GetSqlString(1);

                            ResultCollection.Add(new FirstNameAndIDResult(
                                FirstNameReader.GetSqlInt32(0),
                                firstNameFind));
                        }
                    }
                }
            }
            return ResultCollection;
            //SqlCommand getCustomerByFirstName = new SqlCommand("SELECT * from Customer", conn);
            //SqlParameter paramName = new SqlParameter("@FirstName", SqlDbType.NVarChar);

            //paramName.Value = firstName;

            //getCustomerByFirstName.Parameters.Add(firstName);

            //getCustomerByFirstName.CommandText = "SELECT * from Customer";



            //SqlCommand getCustomerByFirstName = new SqlCommand("Select * From Customer WHERE FirstName = '" + firstName + "'", conn);
            //SqlContext.Pipe.ExecuteAndSend(getCustomerByFirstName);
            //SqlDataReader rdr = getCustomerByFirstName.ExecuteReader();
            //SqlContext.Pipe.Send(rdr);
            //SqlContext.Pipe.ExecuteAndSend(getCustomerByFirstName);
            //rdr.Close();
            //getCustomerByFirstName.ExecuteNonQuery();

        }


        public static void FirstNameAndID_FillRow(
            object CustomerResultObj,
            out SqlInt32 customerid,
            out SqlString firstName)
        {
            FirstNameAndIDResult result = (FirstNameAndIDResult)CustomerResultObj;
            customerid = result.CustomerID;
            firstName = result.FirstName;
        }
    };




using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void BookRouteSeats(SqlInt32 routeID, SqlInt32 selseats)
    {
        SqlConnection conn = new SqlConnection("Context Connection=true");

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        conn.Open();
        //cmd.CommandText = "Select Seats_Left From Route	WHERE @routeID = Route_ID";
        //cmd.CommandText = "IF (Select Seats_Left from Route WHERE Route_ID = @routeID) > @selseats  ";
        //cmd.CommandText = "select seats_left from route where route_id = @routeid if (Select seats_left from Route where seats_left) > @selseats begin   update Route set Seats_Left -= @selseats where Route_ID = @routeid end";
        cmd.CommandText = "if ((select Seats_Left from Route where Route_ID = @routeID) >= @selseats) begin update route set route.seats_left -= @selseats where route.route_id = @routeid end";
        SqlParameter paramRouteID = new SqlParameter();
        paramRouteID.Value = routeID;
        SqlParameter paramselseats = new SqlParameter();
        paramselseats.Value = selseats;
        paramRouteID.Direction = ParameterDirection.Input;
        paramselseats.Direction = ParameterDirection.Input;
        paramRouteID.DbType = DbType.Int32;
        paramselseats.DbType = DbType.Int32;
        paramRouteID.ParameterName = "@routeID";
        paramselseats.ParameterName = "@selseats";
        cmd.Parameters.Add(paramRouteID);
        cmd.Parameters.Add(paramselseats);
        SqlDataReader sqldr = cmd.ExecuteReader();        
        SqlContext.Pipe.Send(sqldr);
        sqldr.Close();
        conn.Close();
    }
}

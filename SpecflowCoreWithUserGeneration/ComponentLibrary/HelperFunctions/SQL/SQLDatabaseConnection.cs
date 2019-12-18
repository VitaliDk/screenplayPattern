using System.Data.SqlClient;

namespace ComponentLibrary.HelperFunctions.SQL
{
    public class SQLDatabaseConnection
    {
        

        public static SqlConnection ConnectTo(string server, string database)
        {// to be refactored out to config settings
            string sqlConnectionString = $"user id={Config.Environment.SqlServerUser};" + // svc_uat_sql  // Also user is ui_test_project in qa2
                                               $"password={Config.Environment.SqlServerPassword};server={server};" +
                                               "Trusted_Connection=FALSE;" +
                                               $"database={database}; " +
                                               "connection timeout=30";
            SqlConnection myConnection = new SqlConnection(sqlConnectionString);

            return myConnection;
        }
    }
}

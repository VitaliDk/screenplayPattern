using System.Data.SqlClient;
using ComponentLibrary.HelperFunctions.SQL;

namespace ComponentLibrary.UserClasses
{
    public class UserClaims
    {

        private static string FindRightIdFor(ProductType product, UserClaimAbility userClaimAbility)
        {
            // Connect to sql
            SqlConnection myConnection = SQLDatabaseConnection.ConnectTo(Config.Environment.SqlServer, "CTN_Report");
            myConnection.Open();

            //string id = "";
            string select = "SELECT [CTN_Report].[dbo].[Right].[RightId] ";
            string from = "FROM [CTN_Report].[dbo].[Module] ";
            string innerJoin = "INNER JOIN[CTN_Report].[dbo].[Right] ON [CTN_Report].[dbo].[Module].[ModuleId] = [CTN_Report].[dbo].[Right].[ModuleId] ";
            string whereProductIs = $"WHERE[CTN_Report].[dbo].[Module].[Name] = '{product.ToString()}' ";
		    string whereAbilityIs = $"AND [CTN_Report].[dbo].[Right].[Name] = '{userClaimAbility.ToString()}'";

            string command = select + from + innerJoin + whereProductIs + whereAbilityIs;

           // SqlCommand myCommand = new SqlCommand(command, myConnection);

            return SQLRead.FromDatabase(command, "RightId", myConnection);
        }

        public static void InsertRightsFor(ProductType product, UserClaimAbility userClaimAbility, DMIUser user)
        {
            string rightId = FindRightIdFor(product, userClaimAbility);
            string userId = user.userId;

            string insertInto = "INSERT INTO[CTN_Report].[dbo].[UserRight] ";
            string columnNames = "(UserId, RightId) ";
            string columnValues = $"VALUES ('{userId}', '{rightId}')";

            string command = insertInto + columnNames + columnValues;

            SqlConnection myConnection = SQLDatabaseConnection.ConnectTo(Config.Environment.SqlServer, "CTN_Report");
            myConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(command, myConnection);

            sqlCommand.ExecuteNonQuery();

        }
    }
}

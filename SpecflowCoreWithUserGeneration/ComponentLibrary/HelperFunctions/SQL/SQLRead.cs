using System;
using System.Data.SqlClient;

namespace ComponentLibrary.HelperFunctions.SQL
{
    public class SQLRead
    {
        public static string FromDatabase(string sqlStatement, string returnField, SqlConnection openConnection)
        {
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(sqlStatement,
                                                         openConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Console.WriteLine("It found the following:  " + myReader[returnField].ToString());
                    return myReader[returnField].ToString();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return "";
        }


    }
}

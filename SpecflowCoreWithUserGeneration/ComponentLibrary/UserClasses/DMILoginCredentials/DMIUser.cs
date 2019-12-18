using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ComponentLibrary.HelperFunctions.SQL;
using ComponentLibrary.Config;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ComponentLibrary.UserClasses
{
    public class DMIUser
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string userId { get; set; }
        public string clientId { get; set; }


        public DMIUser(string clientId)
        {
            this.clientId = clientId;
        }

        public DMIUser(IdentityProviderUserModel identityProviderUserModel, string clientId)
        {
            this.username = identityProviderUserModel.username;
            this.firstname = identityProviderUserModel.firstName;
            this.lastname = identityProviderUserModel.lastName;
            this.email = identityProviderUserModel.email;
            this.userId = identityProviderUserModel.id;
            this.clientId = clientId;
        }

        public static async Task<DMIUser> Create(NewUser newuser, string clientId)
        {
            try
            {
                IdentityProviderUser identityProvideruser = new IdentityProviderUser();
                var userCreated = await identityProvideruser.Create(newuser);

                DMIUser user = new DMIUser(userCreated, clientId);
                user.password = newuser.password;

                Console.WriteLine("dmiuser username is:  " + user.username);
                InsertUserIntoCTNReportDatabase(user);

                return user;
            }
            catch (Exception)
            {

                throw Log.Exception("Unable to create dmi user login details");
            }
        }

        public static async Task<DMIUser> CreateDisabledUser()
        {
            IdentityProviderUser identityProvideruser = new IdentityProviderUser();
            NewUser newuser = NewUser.GenerateRandomUser();
            var userCreated = await identityProvideruser.Create(newuser);

            DMIUser user = new DMIUser(userCreated, Config.Environment.ClientId);
            user.password = newuser.password;

            InsertUserIntoCTNReportDatabase(user);
            user.DisableUser();

            return user;
        }

        public static async Task<DMIUser> Create(string clientId)
        {
            NewUser newuser = NewUser.GenerateRandomUser();

            IdentityProviderUser identityProvideruser = new IdentityProviderUser();
            var userCreated = await identityProvideruser.Create(newuser);

            DMIUser user = new DMIUser(userCreated, clientId);
            user.password = newuser.password;

            InsertUserIntoCTNReportDatabase(user);
            Log.MetaData($"User created with username {user.username}");
            Log.MetaData($"              and password {user.password}");
            return user;
        }

        public static async Task<DMIUser> Create(string clientId, string username)
        {
            NewUser newuser = NewUser.GenerateUserWithUsername(username);

            IdentityProviderUser identityProvideruser = new IdentityProviderUser();
            var userCreated = await identityProvideruser.Create(newuser);

            DMIUser user = new DMIUser(userCreated, clientId);
            user.password = newuser.password;

            InsertUserIntoCTNReportDatabase(user);
            Console.WriteLine("username: " + user.username);

            Log.MetaData($"User created with username {user.username}");
            Log.MetaData($"              and password {user.password}");
            return user;
        }

        public DMIUser CanViewOrders()
        {
            UserClaims.InsertRightsFor(ProductType.DmiOrders, UserClaimAbility.CanSee, this);
            return this;
        }
        public DMIUser CanViewSettlements()
        {
            UserClaims.InsertRightsFor(ProductType.DmiSettlements, UserClaimAbility.CanSee, this);
            return this;
        }
        public DMIUser CanSettleNetPositions()
        {
            UserClaims.InsertRightsFor(ProductType.DmiSettlements, UserClaimAbility.canCloseNetPositions, this);
            return this;
        }
        public DMIUser CanViewBalances()
        {
            UserClaims.InsertRightsFor(ProductType.DmiSettlements, UserClaimAbility.canViewBalances, this);
            return this;
        }

        public DMIUser CanViewHoldings()
        {
            UserClaims.InsertRightsFor(ProductType.DmiSubRegister, UserClaimAbility.CanSee, this);
            return this;
        }

        public void DisableUser()
        {

            HttpClient Client = new HttpClient();
            var authenticateUser = new AuthenticateIdentityProviderUser();
            var token = authenticateUser.AuthAsync().GetAwaiter().GetResult();
            string patchJson = "[{'op': 'replace','path': '/disabled','value': true}]";

            var buffer = System.Text.Encoding.UTF8.GetBytes(patchJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            string Uri = Config.Environment.IdentityProviderUsersEndpoint + this.userId;
            var response =  Client.PatchAsync(Uri, byteContent);

        }

        public void DeleteUser()
        {
            HttpClient Client = new HttpClient();
            var authenticateUser = new AuthenticateIdentityProviderUser();
            var token = authenticateUser.AuthAsync().GetAwaiter().GetResult();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            string Uri =    Config.Environment.IdentityProviderUsersEndpoint + this.userId;
            var response = Client.DeleteAsync(Uri);
        }

        public void SetAgeOfPassword(int days)
        {

            var dateInPast = DateTime.Today.AddDays(-days);

            SqlConnection myConnection = SQLDatabaseConnection.ConnectTo(Config.Environment.SqlServer, "CAL_IdentityUser");
            myConnection.Open();

            //generate SQL insert statement parts
            string updateTableName = "UPDATE [CAL_IdentityUser].[dbo].[AspNetUsers]";
            string setPasswordResetDate = $"SET LastPasswordReset = '{dateInPast}'";
            string forUser = $"WHERE Id = '{this.userId}'";

            //construct sql statement
            string command = updateTableName + setPasswordResetDate + forUser;

            SqlCommand myCommand = new SqlCommand(command, myConnection);

            myCommand.ExecuteNonQuery();
        }

        private static void InsertUserIntoCTNReportDatabase(DMIUser user)
        {
            SqlConnection myConnection = SQLDatabaseConnection.ConnectTo(Config.Environment.SqlServer, "CTN_Report");
            myConnection.Open();

            //generate SQL insert statement parts
            string insertInto = "INSERT INTO [User]";
            string columnNames = "(UserId,FirstName,Surname,ClientId,Username,Email,GlobalAdminType,UserMustChangePasswordOnLogin,Deleted,Disabled)";
            string columnValues = $"VALUES ('{user.userId}','{user.firstname}', '{user.lastname}', '{user.clientId}','{user.username}','{user.email}',0,0,0,0)"; //2349 in qa2

            //construct sql statement
            string command = insertInto + columnNames + columnValues;

            SqlCommand myCommand = new SqlCommand(command, myConnection);

            myCommand.ExecuteNonQuery();

        }


       
    }
}

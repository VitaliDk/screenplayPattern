using ComponentLibrary.HelperFunctions;

namespace ComponentLibrary.UserClasses
{
    public class NewUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public NewUser()
        {

        }

        public NewUser(DMIUser dmiuser)
        {
            this.firstName = (dmiuser.firstname != null) ? dmiuser.firstname : GenerateRandom.StringOfLength(5);
            this.lastName = (dmiuser.lastname != null) ? dmiuser.lastname : GenerateRandom.StringOfLength(5);
            this.username = (dmiuser.username != null) ? dmiuser.username : GenerateRandom.StringOfLength(5);
            this.password = (dmiuser.password != null) ? dmiuser.password : "Password123.";
            this.email = (dmiuser.email != null) ? dmiuser.email : Config.Environment.Email;

        }

        public static NewUser GenerateRandomUser()
        {
            NewUser newuser = new NewUser();
            newuser.email = Config.Environment.Email;
            newuser.username = "TestUser" + GenerateRandom.StringOfLength(8);
            newuser.firstName = GenerateRandom.StringOfLength(5);
            newuser.lastName = GenerateRandom.StringOfLength(5);
            newuser.password = "Password123.";

            return newuser;
        }
        public static NewUser GenerateUserWithUsername(string username)
        {
            NewUser newuser = new NewUser();
            newuser.email = Config.Environment.Email;
            newuser.username = username;
            newuser.firstName = GenerateRandom.StringOfLength(5);
            newuser.lastName = GenerateRandom.StringOfLength(5);
            newuser.password = "Password123.";

            return newuser;
        }
    }
}

using System;
using OpenQA.Selenium;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Actions;
using ComponentLibrary.Config;

namespace ComponentLibrary.Tasks
{
    public class Login : ITask
    {
        private string username;
        private string password;

        private By usernameTextBox = Screens.DMILoginPageScreen.UsernameField;
        private By passwordTextBox = Screens.DMILoginPageScreen.PasswordField;
        private By loginButton = Screens.DMILoginPageScreen.LoginButton;

        public void PerformAs(User user)
        {
            string username = this.username != null ? this.username : user.dmiuser.username;
            string password = this.password != null ? this.password : user.dmiuser.password;

            Log.Task($"Login with username {username} and password {password}");

            user.AttemptsTo(Enter.TheText(username).Into(usernameTextBox),
                            Enter.TheText(password).Into(passwordTextBox),
                            Click.On(loginButton));
        }

        public Login()
        {
            Console.WriteLine("constructor instantiated");
        }

        public static Login ToTheDmi()
        {
            return new Login();
        }

        public Login WithAnIncorrectUsername()
        {
            this.username = "anInvalidUsername";
            return this;
        }
        public Login WithAnIncorrectPassword()
        {
            this.password = "anInvalidPassword";
            return this;
        }

    }
}

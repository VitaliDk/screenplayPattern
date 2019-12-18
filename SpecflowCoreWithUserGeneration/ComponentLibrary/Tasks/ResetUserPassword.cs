using OpenQA.Selenium;
using ComponentLibrary.Screens;
using ComponentLibrary.Actions;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Interfaces;

namespace ComponentLibrary.Tasks
{
    public class ResetUserPassword : ITask
    {
        string newPassword;

        By usernameTextBox = DMIPasswordResetPageScreen.UsernameField;
        By passwordTextBox = DMIPasswordResetPageScreen.PasswordField;
        By confirmPasswordTextBox = DMIPasswordResetPageScreen.ConfirmPasswordField;
        By submitButton = DMIPasswordResetPageScreen.ResetPasswordButton;

        public ResetUserPassword(string password)
        {
            this.newPassword = password;
        }

        public static ResetUserPassword To(IWebDriver driver, DMIUser user, string newPassword)
        {
            return new ResetUserPassword(newPassword);
        }

        public void PerformAs(User user)
        {
            user.AttemptsTo(Enter.TheText(user.dmiuser.username).Into(usernameTextBox),
            Enter.TheText(newPassword).Into(passwordTextBox),
            Enter.TheText(newPassword).Into(confirmPasswordTextBox),
            Click.On(submitButton));
        }
    }
}

using OpenQA.Selenium;
using ComponentLibrary.Screens;
using ComponentLibrary.Actions;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Interfaces;

namespace ComponentLibrary.Tasks
{
    public class PasswordResetRequest : ITask
    {
        DMIUser dmiuser;
        By usernameTextBox = DMIPasswordResetRequestPageScreen.UsernameField;
        By emailTextBox = DMIPasswordResetRequestPageScreen.EmailField;
        By sumbitButton = DMIPasswordResetRequestPageScreen.SubmitButton;

        public static PasswordResetRequest SubmitAs(User user)
        {
            return new PasswordResetRequest(user);
        }

        public PasswordResetRequest(User user)
        {
            this.dmiuser = user.dmiuser;
        }

        public void PerformAs(User user)
        {
            user.AttemptsTo(Enter.TheText(user.dmiuser.username).Into(usernameTextBox),
            Enter.TheText(user.dmiuser.email).Into(emailTextBox),
            Click.On(sumbitButton));
        }
    }
}

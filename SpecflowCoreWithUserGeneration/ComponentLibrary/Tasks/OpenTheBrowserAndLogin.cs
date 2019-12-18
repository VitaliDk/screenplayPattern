using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using System;
using ComponentLibrary.Observations.VerifyPage;
using System.Text;

namespace ComponentLibrary.Tasks
{
    public class OpenTheBrowserAndLogin : ITask
    {
        public void PerformAs(User user)
        {
            user.AttemptsTo(OpenTheBrowserOn.DMI());
            user.ShouldSee(DMILoginPage.IsDisplayed());
            user.AttemptsTo(Login.ToTheDmi());
            user.ShouldSee(DMIDashboardPage.IsDisplayed());
        }

        public static OpenTheBrowserAndLogin ToTheDMI()
        {
            return new OpenTheBrowserAndLogin();
        }
    }
}

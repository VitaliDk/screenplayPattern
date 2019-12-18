using ComponentLibrary.Actions;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Observations;
using ComponentLibrary.Config;

namespace ComponentLibrary.Tasks
{
    public class Logout : ITask
    {
        public Logout()
        {

        }
        public void PerformAs(User user)
        {
            Log.Task("log out of the DMI");
            user.AttemptsTo(Click.On(Screens.DMIDashboardPageScreen.AccountDropDownToggle),
                            Click.ThelastButton());
            user.ShouldSee(PageDisplayed.Is("login"));
        }
        public static Logout DMI()
        {
            return new Logout();
        }
    }
}

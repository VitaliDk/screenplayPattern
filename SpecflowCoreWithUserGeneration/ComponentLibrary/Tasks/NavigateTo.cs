using ComponentLibrary.Config;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Screens;
using OpenQA.Selenium;

using ComponentLibrary.Actions;

namespace ComponentLibrary.Tasks
{
    public class NavigateTo : ITask
    {
        By link;

        public void PerformAs(User user)
        {
            Log.Task($"Navigate to {this.link}");
            user.AttemptsTo(Click.On(this.link));
        }

        public NavigateTo(By link)
        {
            this.link = link;
        }

        public static NavigateTo OrdersPage()
        {
            return new NavigateTo(DMINavBarUI.OrdersWebLink);
        }

        public static NavigateTo SettlementsPage()
        {
            return new NavigateTo(DMINavBarUI.SettlementsWebLink);
        }

        public static NavigateTo RegisterPage()
        {
            return new NavigateTo(DMINavBarUI.RegisterWebLink);
        }

        public static NavigateTo BalancesPage()
        {
            return new NavigateTo(DMINavBarUI.BalancesWebLink);
        }
    }
}

using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{
    public class DMIDashboardPageScreen
    {
        public static By OrdersLink = DMINavBarUI.OrdersWebLink;
        public static By SettlementsLink = DMINavBarUI.SettlementsWebLink;
        public static By BalancesLink = DMINavBarUI.BalancesWebLink;
        public static By RegisterLink = DMINavBarUI.RegisterWebLink;

        public static By Dashboard = By.Id("dashboard");

        public static By AccountDropDownToggle = By.Id("userDropdownContainer");

    }
}

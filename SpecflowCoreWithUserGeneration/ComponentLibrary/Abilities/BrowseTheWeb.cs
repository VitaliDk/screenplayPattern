using OpenQA.Selenium;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Interfaces;

namespace ComponentLibrary.Abilities
{
    public class BrowseTheWeb : IAbility
    {
        IWebDriver driver;

        public void AddAbilityFor(User user)
        {
            user.driver = driver;
        }

        public BrowseTheWeb(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static BrowseTheWeb WithHisBrowser(IWebDriver driver)
        {
            return new BrowseTheWeb(driver);
        }
    }
}

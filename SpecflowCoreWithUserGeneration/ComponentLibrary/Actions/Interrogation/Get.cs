using OpenQA.Selenium;

namespace ComponentLibrary.Actions
{
    public class Get
    {
        // Retrieve text from an element on the page
        public static string Text(IWebDriver driver, By id)
        {
            return FindElement.By(driver, id).GetAttribute("value");
        }

        public static string InnerText(IWebDriver driver, By id)
        {
            return FindElement.By(driver, id).Text;
        }
    }
}

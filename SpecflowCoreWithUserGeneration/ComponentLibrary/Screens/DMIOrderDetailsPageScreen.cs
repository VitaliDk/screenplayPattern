using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{
    public class DMIOrderDetailsPageScreen
    {
        public static By OrderDetailsTitle = By.Id("orderDetails");

        public static By Field(string fieldName)
        {
            return By.Id(fieldName);
        }
    }
}

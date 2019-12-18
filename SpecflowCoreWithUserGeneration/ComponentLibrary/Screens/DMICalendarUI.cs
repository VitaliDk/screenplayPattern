using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{

    public class DMICalendarUI
    {
        public static By ToggleRight = By.CssSelector("i[class*='dx-icon-chevrontright']");

        public static By ToggleLeft = By.CssSelector("i[class*='dx-icon-chevrontleft']");

        public static By FromDateMonthYearSelector(string monthAndOrYear)
        {
            By dateFieldSelector = By.XPath($"//span[contains(text(),'{monthAndOrYear}')]");
            return dateFieldSelector;
        }

        public static By FromDateDaySelector(string day)
        {
            By dateFieldSelector = By.XPath($"//span[text()='{day}']");
            return dateFieldSelector;
        }

        public static By ToDateMonthYearSelector(string monthAndOrYear)
        {
            By dateFieldSelector = By.XPath($"//div[text()='To']/following::span[contains(text(),'{monthAndOrYear}')]");
            return dateFieldSelector;
        }

        public static By ToDateDaySelector(string day)
        {
            By dateFieldSelector = By.XPath($"//div[text()='To']/following::span[text()='{day}']");
            return dateFieldSelector;
        }

        public static By FromDateOpenCalendarSelector()
        {
            By calendarSelector = By.XPath("//div[text()='From']/following::div[@class='dx-dropdowneditor-icon']");
            return calendarSelector;
        }

        public static By ToDateOpenCalendarSelector()
        {
            By calendarSelector = By.XPath("//div[text()='To']/following::div[@class='dx-dropdowneditor-icon']");
            return calendarSelector;
        }
    }
}

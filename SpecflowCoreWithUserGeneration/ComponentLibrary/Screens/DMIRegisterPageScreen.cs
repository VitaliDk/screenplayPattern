using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{
    public class DMIRegisterPageScreen
    {
        public static By firstRowWithNonEmptyHolding = By.CssSelector("tr[class='dx-row dx-data-row dx-column-lines dmi-data'][aria-rowindex='4'] td:nth-of-type(5)");

        public static By firstRowWithANonEmptyTranche = By.CssSelector("tr[class='dx-row dx-data-row dx-column-lines'][aria-rowindex='1']");
    }
}

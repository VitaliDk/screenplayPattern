using OpenQA.Selenium;
namespace ComponentLibrary.Screens
{
    public class DMIBalancesPageScreen
    {
        public static By rowContainingFirstNonEmptyBalance = By.CssSelector("tr[class='dx-row dx-data-row dx-column-lines dmi-data'][aria-rowindex='4'] td:nth-of-type(4)");
    }
}

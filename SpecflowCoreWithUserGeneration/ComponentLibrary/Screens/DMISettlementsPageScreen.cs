using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{
    public class DMISettlementsPageScreen
    {
        public static By closedDatagridArrowToggle = By.ClassName("dx-datagrid-group-closed");
        public static By firstRowWithASettlement = By.CssSelector("tr[class='dx-row dx-data-row dx-column-lines'][aria-rowindex='1'] td:nth-of-type(1)");
        public static By firstRowWithAnOrder = By.CssSelector("tr[class='dx-row dx-data-row dx-column-lines'][aria-rowindex='1']");
    }
}

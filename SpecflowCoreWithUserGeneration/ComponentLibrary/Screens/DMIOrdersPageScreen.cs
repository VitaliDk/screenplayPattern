using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{
    public class DMIOrdersPageScreen
    {
        // <Column Search Fields>
        public static By DmiOrderIdSearchField = By.Id("dx-col-1");
        public static By SendingPartySearchField = By.Id("dx-col-2");
        public static By ReceivingPartySearchField = By.Id("dx-col-3");
        public static By TpaSearchField = By.Id("dx-col-4");
        public static By CreatedDateTimeSearchField = By.Id("dx-col-5");
        public static By ModifiedDateTimeSearchField = By.Id("dx-col-6");
        public static By OrderReferenceSearchField = By.Id("dx-col-7");
        public static By DealReferenceSearchField = By.Id("dx-col-8");
        public static By IsinSearchField = By.Id("dx-col-9");
        public static By AccountSearchField = By.Id("dx-col-10");
        public static By TransactionTypeSearchField = By.Id("dx-col-11");
        public static By OrderedAmountSearchField = By.Id("dx-col-12");
        public static By OrderedUnitsSearchField = By.Id("dx-col-13");
        public static By ConfirmedUnitsSearchField = By.Id("dx-col-14");
        public static By SettlementAmountSearchField = By.Id("dx-col-15");
        public static By SettlementDateSearchField = By.Id("dx-col-16");
        public static By StatusSearchField = By.Id("dx-col-17");

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

        public static By OrderDetailsLink(int containingDigit)
        {
            return By.XPath($"//div[text()='DMI Order ID']/following::a[contains(text(),'{containingDigit}')]");
        }
    }
}

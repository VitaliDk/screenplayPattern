using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ComponentLibrary.Tasks;
using ComponentLibrary.UserClasses;
using ComponentLibrary.DMIFilters;
using ComponentLibrary.Observations;
using ComponentLibrary.Actions;

namespace UITestProject
{
    [Binding]
    public class OrdersPageSteps
    {
        private readonly IWebDriver driver;
        private readonly User user;


        public OrdersPageSteps(IWebDriver driver, User user)
        {
            this.driver = driver;
            this.user = user;
        }

        [When(@"the user navigates to the orders page")]
        public void WhenTheUserNavigatesToTheOrdersPage()
        {
            user.AttemptsTo(NavigateTo.OrdersPage());
        }

        [When(@"the user can find at least 1 order")]
        public void WhenTheUserCanFindAtleast1Order()
        {
            user.AttemptsTo(FilterResults.By(SubmittedFromDateFilter.EqualTo(1, "Jun", "2011"),
                                               SubmittedToDateFilter.EqualTo(1, "Oct", "2020")));

            user.ShouldSee(OrderDisplayed.OnThePage());
        }

        [Then(@"the user can see an order")]
        public void ThenTheUserCanSeeAnOrder()
        {
            user.AttemptsTo(FilterResults.By(SubmittedFromDateFilter.EqualTo(7,"Jan", "2010"),
                                               SubmittedToDateFilter.EqualTo(24, "Oct", "2020")));
            user.ShouldSee(OrderDisplayed.OnThePage());
        }

        [When(@"the user clicks the link to the order details page for an order")]
        public void WhenTheUserClicksTheLinkToTheOrderDetailsPageForAnOrder()
        {
            user.AttemptsTo(Click.On(user.FoundOrderId));
        }

        [When(@"the user goes to the balances page to rejoice")]
        public void WhenTheUserGoesToTheBalancesPageToRejoice()
        {
            //user.AttemptsTo(Get.InnerText(By.Id("")));
        }

        [Given(@"the user is logged into the DMI with a vengeance")]
        public void GivenTheUserIsLoggedIntoTheDMIWithAVengeance()
        {
            user.AttemptsTo(OpenTheBrowserAndLogin.ToTheDMI());
        }

    }
}

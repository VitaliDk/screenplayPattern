using TechTalk.SpecFlow;

namespace UITestProject
{
    [Binding]
    public class GroupedSteps 
    {

        private readonly IdentityProviderSteps identityProviderSteps;
        private readonly OrdersPageSteps orderPageSteps;
        private readonly SettlementPageSteps settlementPageSteps;
        private readonly HoldingsPagesSteps holdingsPagesSteps;

        public GroupedSteps(IdentityProviderSteps identityProviderSteps, OrdersPageSteps ordersPageSteps, SettlementPageSteps settlementPageSteps, HoldingsPagesSteps holdingsPagesSteps)
        {
            this.identityProviderSteps = identityProviderSteps;
            this.orderPageSteps = ordersPageSteps;
            this.settlementPageSteps = settlementPageSteps;
            this.holdingsPagesSteps = holdingsPagesSteps;
        }

        [Given(@"the user is logged into the DMI")]
        public void GivenTheUserIsLoggedIntoTheDMI()
        {
            identityProviderSteps.GivenTheUserIsOnTheLoginPage();
            identityProviderSteps.WhenTheUserAttemptsToLogIn();
            identityProviderSteps.ThenTheUserIsRedirectedToTheDMI();


        }

        [Given(@"the user is on the orders page")]
        public void GivenTheUserIsOnTheOrdersPage()
        {
            GivenTheUserIsLoggedIntoTheDMI();
            orderPageSteps.WhenTheUserNavigatesToTheOrdersPage();
        }

        [Given(@"the user is on the settlements page")]
        public void GivenTheUserIsOnTheSettlementsPage()
        {
            GivenTheUserIsLoggedIntoTheDMI();
            settlementPageSteps.WhenTheUserNavigatesToTheSettlementsPage();
        }

        [Given(@"the user is on the order details page")]
        public void GivenTheUserIsOnTheOrderDetailsPage()
        {
            GivenTheUserIsOnTheOrdersPage();
            orderPageSteps.WhenTheUserCanFindAtleast1Order();
            orderPageSteps.WhenTheUserClicksTheLinkToTheOrderDetailsPageForAnOrder();
        }

        [Given(@"the user is on the register page")]
        public void GivenTheUserIsOnTheRegisterPage()
        {
            holdingsPagesSteps.GivenTheUserHasTheAbilityToViewHoldings();
            GivenTheUserIsLoggedIntoTheDMI();
            holdingsPagesSteps.GivenTheUserNavigatesToTheRegisterPage();

        }

    }
}

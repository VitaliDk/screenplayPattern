using TechTalk.SpecFlow;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Observations;

namespace UITestProject
{
    [Binding]
    public class OrderDetailsPageSteps
    {
        private readonly User user;


        public OrderDetailsPageSteps(User user)
        {
            this.user = user;
        }

        [Then(@"the user is taken to the order details page")]
        public void ThenTheUserIsTakenToTheOrderDetailsPage()
        {
            user.ShouldSee(PageDisplayed.Is("details"));
        }

        [Then(@"the user can see the system name is displayed")]
        public void ThenTheUserCanSeeTheSystemNameIsDisplayed()
        {
            user.ShouldSee(DMIOrderDetailsPage.SystemName().HasAValueOf("CTN"));
        }

    }
}

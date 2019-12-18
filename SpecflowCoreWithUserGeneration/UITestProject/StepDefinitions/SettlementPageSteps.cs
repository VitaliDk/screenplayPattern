using OpenQA.Selenium;
using TechTalk.SpecFlow;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Abilities;
using ComponentLibrary.Tasks;
using ComponentLibrary.DMIFilters;
using ComponentLibrary.Observations;

namespace UITestProject
{
    [Binding]
    public class SettlementPageSteps
    {
        User user;
        IWebDriver driver;

        public SettlementPageSteps(User user, IWebDriver driver)
        {
            this.user = user;
            this.driver = driver;
        }

        [Given(@"the user is able to view settlements")]
        public void GivenTheUserIsAbleToViewSettlements()
        {
            user.HasTheAbilityTo(View.Settlements());
        }

        [When(@"the user searches for all settlements for the client")]
        public void WhenTheUserSearchesForAllSettlementsForTheClient()
        {
            user.AttemptsTo(FilterResults.By(SubmittedFromDateFilter.EqualTo(7, "Jan", "2010"),
                                       SubmittedToDateFilter.EqualTo(30, "Oct", "2020")));
        }

        [When(@"the user expands all settlements on the page")]
        public void WhenTheUserExpandsAllSettlementsOnThePage()
        {
            user.AttemptsTo(ExpandAllDatagrids.OnTheSettlementsPage());
        }

        [When(@"the user navigates to the settlements page")]
        public void WhenTheUserNavigatesToTheSettlementsPage()
        {
            user.AttemptsTo(NavigateTo.SettlementsPage());
        }

        [Then(@"the user can see a settlement")]
        public void ThenTheUserCanSeeASettlement()
        {
            user.AttemptsTo(FilterResults.By(SubmittedFromDateFilter.EqualTo(7, "Jan", "2010"),
                                                   SubmittedToDateFilter.EqualTo(30, "Oct", "2020")),
                            ExpandAllDatagrids.OnTheSettlementsPage());

            user.ShouldSee(SettlementDisplayed.OnThePage());
        }

        [Then(@"the user can see at least one underlying order on the page")]
        public void ThenTheUserCanSeeAtLeastOneUnderlyingOrderOnThePage()
        {
            user.ShouldSee(NumberOfOrdersOnThePage.IsAtleastOne());
        }
    }
}

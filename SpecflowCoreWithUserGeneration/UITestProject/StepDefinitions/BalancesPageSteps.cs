using TechTalk.SpecFlow;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Tasks;
using ComponentLibrary.Observations;
using ComponentLibrary.DMIFilters;
using ComponentLibrary.Abilities;

namespace UITestProject
{
    [Binding]
    public class BalancesPageSteps
    {
        private readonly User user;
        public BalancesPageSteps(User user)
        {
            this.user = user;
        }

        [Given(@"the user has the ability to view balances")]
        public void GivenTheUserHasTheAbilityToViewBalances()
        {
            user.HasTheAbilityTo(View.Balances());
        }

        [When(@"the user navigates to the balances page")]
        public void WhenTheUserNavigatesToTheBalancesPage()
        {
            user.AttemptsTo(NavigateTo.BalancesPage());
        }
        [Then(@"the user can see a balance")]
        public void ThenTheUserCanSeeABalance()
        {
            user.AttemptsTo(FilterResults.By(SubmittedFromDateFilter.EqualTo(7, "Jan", "2010"),
                                             SubmittedToDateFilter.EqualTo(24, "Oct", "2020")),                                               
                                             ExpandAllDatagrids.OnTheSettlementsPage());

            user.ShouldSee(BalanceDisplayed.OnThePage());
        }

    }
}

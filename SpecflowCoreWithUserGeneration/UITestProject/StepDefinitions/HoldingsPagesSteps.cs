using TechTalk.SpecFlow;
using ComponentLibrary.Abilities;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Tasks;
using ComponentLibrary.Observations;

namespace UITestProject
{
    [Binding]
    public class HoldingsPagesSteps
    {
        User user;
     
        public HoldingsPagesSteps(User user)
        {
            this.user = user;
        }

        [Given(@"the user has the ability to view holdings")]
        public void GivenTheUserHasTheAbilityToViewHoldings()
        {
            user.HasTheAbilityTo(View.Holdings());
        }

        [When(@"the user navigates to the register page")]
        public void GivenTheUserNavigatesToTheRegisterPage()
        {
            user.AttemptsTo(NavigateTo.RegisterPage());
        }

        [When(@"the user expands all holdings on the page")]
        public void WhenTheUserExpandsAllHoldingsOnThePage()
        {
            user.AttemptsTo(ExpandAllDatagrids.OnTheRegisterPage());
        }

        [Then(@"the user can see a holding")]
        public void ThenTheUserCanSeeAHolding()
        {
            user.AttemptsTo(ExpandAllDatagrids.OnTheRegisterPage());
            user.ShouldSee(HoldingDisplayed.OnThePage());
        }

        [Then(@"the user can see atleast one tranche")]
        public void ThenTheUserCanSeeAtleastOneTranche()
        {
            user.ShouldSee(NumberOfTranchesOnThePage.IsAtleastOne());
        }
    }
}

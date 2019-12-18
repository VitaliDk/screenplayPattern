using TechTalk.SpecFlow;
using ComponentLibrary.UserClasses;
using ability = ComponentLibrary.Abilities;
using ComponentLibrary.Config;

namespace UITestProject
{
    [Binding]
    public class UserGenerationSteps
    {

        private readonly User user;

        public UserGenerationSteps(User user)
        {
            this.user = user;
        }

        [Given(@"i have a user")]
        public void GivenIHaveAUser()
        {
            user.HasTheAbilityTo(ability.Access.TheDmi(), ability.View.Orders(), ability.View.Settlements());
        }

        [Given(@"I create the qa users for the DMI API test project")]
        public void GivenICreateTheQaUsersForTheDmiApiTestProject()
        {
            DMIUser dmiuser = DMIUser.Create(APITestProjectConfig.QA1ClientId, "qa1").GetAwaiter().GetResult();
            dmiuser.CanViewOrders();
            dmiuser.CanViewSettlements();
            dmiuser.CanViewBalances();
            dmiuser.CanSettleNetPositions();
            dmiuser.CanViewHoldings();
            DMIUser dmiuser2 = DMIUser.Create(APITestProjectConfig.QA2ClientId, "qa2").GetAwaiter().GetResult();
            dmiuser2.CanViewOrders();
            dmiuser2.CanViewSettlements();
            dmiuser2.CanViewBalances();
            dmiuser2.CanSettleNetPositions();
            dmiuser2.CanViewHoldings();
            DMIUser dmiuser3 = DMIUser.Create(APITestProjectConfig.QA3ClientId, "qa3").GetAwaiter().GetResult();
            dmiuser3.CanViewOrders();
            dmiuser3.CanViewSettlements();
            dmiuser3.CanViewBalances();
            dmiuser3.CanSettleNetPositions();
            dmiuser3.CanViewHoldings();
            DMIUser dmiuser4 = DMIUser.Create(APITestProjectConfig.QA4ClientId, "qa4tpa").GetAwaiter().GetResult();
            dmiuser4.CanViewOrders();
            dmiuser4.CanViewSettlements();
            dmiuser4.CanViewBalances();
        }

    }
}

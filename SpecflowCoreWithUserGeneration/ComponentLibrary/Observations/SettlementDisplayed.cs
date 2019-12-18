using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Config;


namespace ComponentLibrary.Observations
{
    public class SettlementDisplayed : IObservation
    {
        public bool CanBeSeen(User user)
        {
            Log.Observation("at least one settlement is displayed on the page");
            return Element.WithId(Screens.DMISettlementsPageScreen.firstRowWithASettlement).CanBeFoundOnThePageBy(user);
        }

        public static SettlementDisplayed OnThePage()
        {
            return new SettlementDisplayed();
        }


    }
}

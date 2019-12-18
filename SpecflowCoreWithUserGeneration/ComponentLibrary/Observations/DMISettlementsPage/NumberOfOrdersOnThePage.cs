using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Config;

namespace ComponentLibrary.Observations
{
    public class NumberOfOrdersOnThePage : IObservation
    {
        public bool CanBeSeen(User user)
        {
            Log.Observation("there is atleast one order on the page");
            return Element.WithId(Screens.DMISettlementsPageScreen.firstRowWithAnOrder).CanBeFoundOnThePageBy(user);
        }

        public static NumberOfOrdersOnThePage IsAtleastOne()
        {
            return new NumberOfOrdersOnThePage();
        }

    }
}

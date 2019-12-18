using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Config;

namespace ComponentLibrary.Observations
{
    public class NumberOfTranchesOnThePage : IObservation
    {
        public bool CanBeSeen(User user)
        {
            Log.Observation("there is atleast one tranche on the page");
            return Element.WithId(Screens.DMIRegisterPageScreen.firstRowWithANonEmptyTranche).CanBeFoundOnThePageBy(user);
        }

        public static NumberOfTranchesOnThePage IsAtleastOne()
        {
            return new NumberOfTranchesOnThePage();
        }

    }
}

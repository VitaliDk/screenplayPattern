using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Actions;
using ComponentLibrary.Config;

namespace ComponentLibrary.Observations
{
    public class BalanceDisplayed : IObservation
    {
        public bool CanBeSeen(User user)
        {
            try
            {
                Log.Observation("there is at least one balance displayed on the page");
                string textOfTheFirstBalanceEntry = Get.InnerText(user.driver, Screens.DMIBalancesPageScreen.rowContainingFirstNonEmptyBalance);
                if (textOfTheFirstBalanceEntry != null)
                {
                    Log.ObservationOutcome("at least one balance displayed on the page");
                    return true;
                }
                else
                {
                    Log.ObservationOutcome("no balances were found on the page");
                    return false;
                }
            }
            catch (Exception)
            {
                Log.ObservationOutcome("no balance displayed on the page");
                return false;
            }
        }

        public static BalanceDisplayed OnThePage()
        {
            return new BalanceDisplayed();
        }

    }
}

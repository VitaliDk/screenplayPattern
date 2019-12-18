using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Actions;
using ComponentLibrary.Config;

namespace ComponentLibrary.Observations
{
    public class HoldingDisplayed : IObservation
    {
        public bool CanBeSeen(User user)
        {
            Log.Observation("a holding displayed on the current page");
            try
            {
                string holdingText = Get.InnerText(user.driver, Screens.DMIRegisterPageScreen.firstRowWithNonEmptyHolding);
                if (holdingText != null)
                {
                    Log.ObservationOutcome("a holding was displayed on the page");
                    return true;
                }
                else
                {
                    Log.ObservationOutcome("no holding found");
                    return false;
                }
            }
            catch (Exception)
            {
                Log.ObservationOutcome("no holding on the page");
                return false;
            }
        }

        public static HoldingDisplayed OnThePage()
        {
            return new HoldingDisplayed();
        }

    }
}

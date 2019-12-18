using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Screens;
using ComponentLibrary.Config;
using OpenQA.Selenium;

namespace ComponentLibrary.Observations.VerifyPage
{
    public class DMIDashboardPage : IObservation
    {
        By DMIDashboardPageDashboard = DMIDashboardPageScreen.Dashboard;

        public bool CanBeSeen(User user)
        {
            Log.Observation("the DMI dashboard page is displayed");
            try
            {
                Element.WithId(DMIDashboardPageDashboard).CanBeFoundOnThePageBy(user);
                Log.ObservationOutcome("the DMI dashboard page was displayed successfully");
                return true;
            }
            catch (Exception)
            {
                throw Log.Exception("DMI dashboard page was not displayed");
            }
        }

        public static DMIDashboardPage IsDisplayed()
        {
            return new DMIDashboardPage();
        }
    }
}

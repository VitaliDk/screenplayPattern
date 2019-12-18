using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Screens;
using ComponentLibrary.Config;
using OpenQA.Selenium;
using System;

namespace ComponentLibrary.Observations.VerifyPage
{
    public class DMILoginPage : IObservation
    {
        By loginPageUsernameField = DMILoginPageScreen.UsernameField;

        public bool CanBeSeen(User user)
        {
            Log.Observation("the login page is displayed");
            try
            {
                Element.WithId(loginPageUsernameField).CanBeFoundOnThePageBy(user);
                Log.ObservationOutcome("the DMI login page was displayed");
                return true;
            }
            catch (Exception)
            {
                throw Log.Exception("DMI login page was not displayed");
            }
        }

        public static DMILoginPage IsDisplayed()
        {
            return new DMILoginPage();
        }
    }
}


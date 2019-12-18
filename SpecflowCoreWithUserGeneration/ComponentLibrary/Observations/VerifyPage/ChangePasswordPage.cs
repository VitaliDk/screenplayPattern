using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Screens;
using ComponentLibrary.Config;
using OpenQA.Selenium;

namespace ComponentLibrary.Observations
{

    public class ChangePasswordPage : IObservation
    {
        By ChangePasswordHeader = DMIChangePasswordScreen.ChangePasswordHeader;

        public bool CanBeSeen(User user)
        {
            Log.Observation("the change password page is displayed");
            try
            {
                Element.WithId(ChangePasswordHeader).CanBeFoundOnThePageBy(user);
                Log.ObservationOutcome("the change password page was displayed");
                return true;
            }
            catch (Exception)
            {
                throw Log.Exception("Change password page was not displayed");
            }
            
        }

        public static ChangePasswordPage IsDisplayed()
        {
            return new ChangePasswordPage();
        }
    }
}

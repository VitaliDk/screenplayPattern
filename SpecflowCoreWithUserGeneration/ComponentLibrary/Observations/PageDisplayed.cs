using System;
using System.Threading;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Config;

namespace ComponentLibrary.Observations
{
    public class PageDisplayed : IObservation
    {
        public string page;

        public Boolean CanBeSeen(User user)
        {
            Log.Observation($"the current page displayed is the {this.page} page");
            int retries = 0;
            while (!user.driver.Url.Contains(this.page) && retries<10)
            {
                Thread.Sleep(1000);
                Log.Debug($"Check page retry attempt {retries}");
                retries++;
            }

            if (!user.driver.Url.Contains(this.page) && retries ==10)
            {
                Log.ObservationOutcome($"the url displayed was {user.driver.Url}");
                return false;
            }
                
            return true;
        }


        public PageDisplayed(string page)
        {
            this.page = page;
        }

        public static PageDisplayed Is(string page)
        {
            return new PageDisplayed(page);
        }        
    }
}

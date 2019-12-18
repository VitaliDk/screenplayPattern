using System;
using OpenQA.Selenium;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Observations;
using ComponentLibrary.Config;
using ComponentLibrary.HelperFunctions;

namespace ComponentLibrary.Actions
{
    public class Click : ITask
    {

        private readonly By id;


        public void PerformAs(User user)
        {
            Element.WithId(id).CanBeFoundOnThePageBy(user);
            try
            {
                Log.Action($"clicking the element with id {this.id}");

                RetryUtils.RetryIfThrown<Exception, Boolean>(() => 
                {
                    return ClickElement(user, id);
                }, 10, 250);
            }
            catch (Exception)
            {
                throw Log.Exception($"Unable to click on the element with id:  {this.id}");
            }
        }

        public Click(By id)
        {
            this.id = id;
        }

        private static Boolean ClickElement(User user, By id)
        {
            user.driver.FindElement(id).Click();
            return true;
        }

        public static Click On(By id)
        {
            return new Click(id);
        }

        public static Click ThelastButton()
        {
            return new Click(By.CssSelector("button:last-child"));
        }
        
    }
}

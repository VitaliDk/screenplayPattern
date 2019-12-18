using System;
using ComponentLibrary.UserClasses;
using OpenQA.Selenium;

namespace ComponentLibrary.Observations
{
    // Return a boolean indicating if an element exists on the page
    public class Element
    {
        private By Id;
        private bool expectation;
        private bool counterExpectation;

        public Element(By id)
        {
            this.Id = id;
        }

        public static Element WithId(By id)
        {
            return new Element(id);
        }

        public bool CanBeFoundOnThePageBy(User user)
        {
            this.expectation = true;
            this.counterExpectation = false;

            try
            {
                user.driver.FindElement(this.Id);
                return expectation;
            }
            catch (Exception)
            {
                return counterExpectation;
            }
        }
        public bool CannotBeFoundOnThePageBy(User user)
        {
            this.expectation = false;
            this.counterExpectation = true;
            user.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                user.driver.FindElement(this.Id);
                return expectation;
            }
            catch (Exception)
            {
                return counterExpectation;
            }
        }
               
    }
}


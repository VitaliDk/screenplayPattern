using System;
using OpenQA.Selenium;
using ComponentLibrary.HelperFunctions;

namespace ComponentLibrary.Actions
{
    // Return an interactable webelement if it exists on the page
    public class FindElement
    {

        public static IWebElement By(IWebDriver driver, By selector)
        {
            
            IWebElement elementToReturn = null;
            string dirPath = System.IO.Directory.GetCurrentDirectory();
            String format = "dd.hh.mm.ss.ffffff";//"dd-mm-yyyy.hh.mm.tt";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            try
            {
                elementToReturn = driver.FindElement(selector);
            }
            catch (NoSuchElementException e)
            {
                TakeScreenshot.SaveAs(driver, $"{dirPath}\\Screenshots", DateTime.Now.ToString(format));
                throw new NoSuchElementException("exception thrown", e);
            }
            catch (Exception e)
            {
                TakeScreenshot.SaveAs(driver, $"{dirPath}\\Screenshots", DateTime.Now.ToString(format));
                throw e;
            }
            // return either the element or null
            return elementToReturn;
        }
    }
}

using System;
using BoDi;
using TechTalk.SpecFlow;
using ComponentLibrary.Factories;
using OpenQA.Selenium;
using NUnit.Framework;
using ComponentLibrary.Config;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Abilities;
using NLog;
using ComponentLibrary.HelperFunctions;

namespace UITestProject
{
    [Binding]
    public class TestSetup
    {

        private readonly IObjectContainer _objectContainer;

        public TestSetup(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void LogTestRunInformation()
        {
            Log.MetaData($"   -----   Start Test Run   -----   ");
            Log.MetaData($"DateTime:  {DateTime.Now}");
            Log.MetaData($"Environment: {ComponentLibrary.Config.Environment.QAEnvironment}");
            Log.MetaData($"Users generated for client: {ComponentLibrary.Config.Environment.ClientId}");
            Log.MetaData($"DMI URL: {ComponentLibrary.Config.Environment.DmiUrl}");
        }

        [AfterTestRun]
        public static void LogTestRunInformationEnd()
        {
            Log.MetaData($"   -----   End of Test Run   -----   ");
        }

        [BeforeScenario]
        public void InitialiseTest()
        {
            WebDriverFactory factory = new WebDriverFactory();
            IWebDriver driver = factory.Create(ComponentLibrary.Config.Environment.browser);
            driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
                        
            User user = new User();
            user.HasTheAbilityTo(BrowseTheWeb.WithHisBrowser(driver));
            user.HasTheAbilityTo(Access.TheDmi(), 
                                 View.Orders(), 
                                 View.Settlements());

            _objectContainer.RegisterInstanceAs<User>(user);
            Log.MetaData($"Test start DateTime:  {DateTime.Now}");
        }


        [AfterScenario]
        public void TearDown(IWebDriver driver)
        {
            var result = TestContext.CurrentContext.Result.Outcome.ToString();
            var testName = TestContext.CurrentContext.Test.Name;

            Logger logger = LogManager.GetLogger($"Scenario: { testName }");

            if (result == "Passed")
            {
                logger.Info("Test Passed");
            }
            else if (result == "Failed")
            {
                Console.WriteLine("it failed"); 
                string dirPath = System.IO.Directory.GetCurrentDirectory();
                String format = "dd.hh.mm.ss.ffffff";//"dd-mm-yyyy.hh.mm.tt";
                string dateTime = testName + DateTime.Now.ToString(format);
                string filePath = $"{ dirPath }\\Screenshots";
                string fileName = $"{ dateTime }";
                TakeScreenshot.SaveAs(driver, $"{ dirPath }\\Screenshots", dateTime);
                logger.Info($"Test Failed: see screenshot: { filePath + "\\" + fileName + ".Png" }");
            }
            else
            {
                logger.Info(result);
                string dirPath = System.IO.Directory.GetCurrentDirectory();
                String format = "dd.hh.mm.ss.ffffff";//"dd-mm-yyyy.hh.mm.tt";
                string dateTime = testName + DateTime.Now.ToString(format);
                string filePath = $"{ dirPath }\\Screenshots";
                string fileName = $"{ dateTime }";
                TakeScreenshot.SaveAs(driver, $"{ dirPath }\\Screenshots", dateTime);
                logger.Info($"Test Failed: see screenshot: { filePath + "\\" + fileName + ".Png" }");

            }
            driver.Close();
            driver.Quit();
        } 

    }
}

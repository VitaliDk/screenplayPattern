using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using ComponentLibrary.Config;

namespace ComponentLibrary.Factories
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.Firefox:
                    return GetFirefoxDriver();
                case BrowserType.Edge:
                    return GetEdgeDriver();
                default:
                    throw new ArgumentOutOfRangeException(browserType + " was not recognised as a valid browser type");

            }
        }

        public IWebDriver GetChromeDriver()
        {
            Log.MetaData("Running on Chrome browser");
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            return driver;
        }

        public IWebDriver GetFirefoxDriver()
        {
            Log.MetaData("Running on Firefox browser");
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
        public IWebDriver GetEdgeDriver()
        {
            Log.MetaData("Running on Microsoft Edge browser");
            IWebDriver driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            return driver;
        }
    }


}

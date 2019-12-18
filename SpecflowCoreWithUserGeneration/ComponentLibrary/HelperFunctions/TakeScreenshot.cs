using OpenQA.Selenium;
using System.IO;

namespace ComponentLibrary.HelperFunctions
{
    public class TakeScreenshot
    {
        public static void SaveAs(IWebDriver driver, string filePath, string fileName)
        {
            var ssdriver = driver as ITakesScreenshot;
            var screenshot = ssdriver.GetScreenshot();
            var location = filePath + "\\" + fileName + ".Png";

            if (File.Exists(location))
            {
                var locationIncremented = filePath + "\\" + fileName + "i" + ".Png";
                screenshot.SaveAsFile(locationIncremented, ScreenshotImageFormat.Png);
            }
            else
            {
                screenshot.SaveAsFile(location, ScreenshotImageFormat.Png);
            }
        }
    }
}

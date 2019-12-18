using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Config;

namespace ComponentLibrary.Tasks
{
    public class OpenTheBrowserOn : ITask
    {
        string url;

        public OpenTheBrowserOn(string url)
        {
            this.url = url;
        }

        public static OpenTheBrowserOn DMI()
        {
            return new OpenTheBrowserOn(Config.Environment.DmiUrl);
        }

        public void PerformAs(User user)
        {
            Log.Task($"Open the browser on {this.url}");
            user.driver.Navigate().GoToUrl(this.url);
        }

    }
}

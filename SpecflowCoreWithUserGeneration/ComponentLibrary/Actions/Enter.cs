using OpenQA.Selenium;
using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Observations;
using ComponentLibrary.Config;
using System.Threading;

namespace ComponentLibrary.Actions
{
    public class Enter : ITask
    {

        private readonly string text;
        private By id;

        public void PerformAs(User user)
        {
            const int maxRetries = 3;
            int retries = 0;


            while (TextFieldDoesNotHaveExpectedText(user.driver, id, text) && retries < maxRetries)
            {
                Element.WithId(id).CanBeFoundOnThePageBy(user);
                Log.Action($"entering the text {this.text} into the field {this.id}");
                ClearTextFieldAndReplaceByText(user.driver, id, text);
                Thread.Sleep(1000);
                retries++;
            }

            if (TextFieldDoesNotHaveExpectedText(user.driver, id, text) && retries >= maxRetries)
            {
                throw Log.Exception($"Unable to enter text {text} into the text field: '{id}' \n Text retrieved from the text field was '{Get.Text(user.driver, id)}' ");
            }
        }

        private static void ClearTextFieldAndReplaceByText(IWebDriver driver, By id, string text)
        {
            FindElement.By(driver, id).Clear();
            FindElement.By(driver, id).SendKeys(text);     
        }

        private static Boolean TextFieldDoesNotHaveExpectedText(IWebDriver driver, By id, string expectedtext)
        {
            if (Get.Text(driver, id) != expectedtext)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Enter(string text)
        {
           this.text = text;
        }

        public static Enter TheText(string text)
        {
           return new Enter(text);
        }

        public Enter Into(By id)
        {
           this.id = id;
           return this;
        }
    }
}

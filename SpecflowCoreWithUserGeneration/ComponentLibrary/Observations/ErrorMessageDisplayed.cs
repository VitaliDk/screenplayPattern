using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using OpenQA.Selenium;

namespace ComponentLibrary.Observations
{
    public class ErrorMessageDisplayed : IObservation
    {
        private By errorMessageId;
        public bool CanBeSeen(User user)
        {
            return Element.WithId(this.errorMessageId).CanBeFoundOnThePageBy(user);
        }

        public static ErrorMessageDisplayed Is(By errorMessageId)
        {
            return new ErrorMessageDisplayed(errorMessageId);
        }
        public ErrorMessageDisplayed(By errorMessageId)
        {
            this.errorMessageId = errorMessageId;
        }

    }
}

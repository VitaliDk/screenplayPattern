using OpenQA.Selenium;
using ComponentLibrary.Interfaces;
using NUnit.Framework;

namespace ComponentLibrary.UserClasses
{
    public class User
    {
        public IWebDriver driver;
        public DMIUser dmiuser;
        public By FoundOrderId;


        public User AttemptsTo(params ITask[] listOfTasks)
        {
            for (int task = 0; task < listOfTasks.Length; task++)
            {
                listOfTasks[task].PerformAs(this);
            }

            return this;
        }

        public User HasTheAbilityTo(params IAbility[] listOfAbilities)
        {
            for (int ability = 0; ability < listOfAbilities.Length; ability++)
            {
                listOfAbilities[ability].AddAbilityFor(this);
            }

            return this;
        }

        public void ShouldSee(IObservation observation)
        {
            Assert.That(observation.CanBeSeen(this));
        }

    }
}

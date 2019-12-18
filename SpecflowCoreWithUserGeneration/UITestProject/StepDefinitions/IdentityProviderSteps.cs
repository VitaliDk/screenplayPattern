using System;
using TechTalk.SpecFlow;
using ComponentLibrary.Screens;
using OpenQA.Selenium;
using ComponentLibrary.Tasks;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Observations;
using ComponentLibrary.DMIFilters;

namespace UITestProject
{
    [Binding]
    public class IdentityProviderSteps
    {

        private readonly IWebDriver driver;
        private readonly User user;


        public IdentityProviderSteps(IWebDriver driver, User user)
        {
            this.driver = driver;
            this.user = user;
        }

        [Given(@"the user is disabled and attempts to log in")]
        public void GivenTheUserIsDisabledAndAttemptsToLogIn()
        {
            user.dmiuser.DisableUser();
            user.AttemptsTo(Login.ToTheDmi());
        }

        [Given(@"the user is deleted and attempts to log in")]
        public void GivenTheUserIsDeletedAndAttemptsToLogIn()
        {
            user.dmiuser.DeleteUser();
            user.AttemptsTo(Login.ToTheDmi());
        }

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            user.AttemptsTo(OpenTheBrowserOn.DMI());

        }

        [When(@"the user attempts to log in")]
        public void WhenTheUserAttemptsToLogIn()
        {
            user.AttemptsTo(Login.ToTheDmi());
        }

        [When(@"the user attempts to log in with an invalid username")]
        public void WhenTheUserAttemptsToLogInWithAnInvalidUsername()
        {
            user.AttemptsTo(Login.ToTheDmi().WithAnIncorrectUsername());
        }

        [When(@"the user attempts to log in with an invalid password")]
        public void WhenTheUserAttemptsToLogInWithAnInvalidPassword()
        {
            user.AttemptsTo(Login.ToTheDmi().WithAnIncorrectPassword());
        }

        [When(@"the user attempts to log out")]
        public void WhenTheUserAttemptsToLogOut()
        {
            user.AttemptsTo(Logout.DMI());
        }

        [Then(@"the user is redirected to the DMI")]
        public void ThenTheUserIsRedirectedToTheDMI()
        {
            user.ShouldSee(PageDisplayed.Is("dashboard"));
        }

        [Then(@"the user is redirected to the DMI login page")]
        public void ThenTheUserIsRedirectedToTheDMILoginPage()
        {
            user.ShouldSee(PageDisplayed.Is("login"));
        }

        [Then(@"the user is shown a validation message explaining that their login attempt was unsuccessful")]
        public void ThenTheUserIsUnsuccessfulInLoggingIntoTheDMI()
        {
            user.ShouldSee(ErrorMessageDisplayed.Is(DMILoginPageScreen.InvalidLoginAttemptMessage));
        }

        [When(@"the user searches for all orders submitted after 1st June 2009")]
        public void WhenTheUserSearchesForAllOrdersSubmittedAfter1stJun2009()
        {
            // PlayStep for now
            user.AttemptsTo(FilterResults.By(SubmittedFromDateFilter.EqualTo(1, "Aug","2004")));
        }

        [Given(@"the user's password is 1825 days old")]
        public void GivenTheUsersPasswordIs1825DaysOld()
        {
            user.dmiuser.SetAgeOfPassword(1825);
        }

        [Given(@"the user's password is 1824 days old")]
        public void GivenTheUsersPasswordIs1824DaysOld()
        {
            user.dmiuser.SetAgeOfPassword(1824);
        }

        [Then(@"the user is redirected to the change password page")]
        public void ThenTheUserIsRedirectedToTheChangePasswordPage()
        {
            user.ShouldSee(ChangePasswordPage.IsDisplayed());
        }

        [When(@"the user attempts to log in 2 times with an incorrect password")]
        public void WhenTheUserAttemptsToLogIn2TimesWithAnIncorrectpassword()
        {
            user.AttemptsTo(Login.ToTheDmi().WithAnIncorrectPassword(),
                            Login.ToTheDmi().WithAnIncorrectPassword());
                            
;        }

        [When(@"the user attempts to log in 3 times with an incorrect password")]
        public void WhenTheUserAttemptsToLogIn3TimesWithAnIncorrectpassword()
        {
            user.AttemptsTo(Login.ToTheDmi().WithAnIncorrectPassword(),
                            Login.ToTheDmi().WithAnIncorrectPassword(),
                            Login.ToTheDmi().WithAnIncorrectPassword());
        }

        [Given(@"I can read emails")]
        public void GivenICanReadEmails()
        {
            Console.WriteLine("point 1");
            Console.WriteLine("point 2");
            //string link = Email.getEmailLink();
            //GoTo.Link(driver, link);
            //PasswordResetRequest.SubmitAs(driver, dmiuser);
            Console.WriteLine("point 3");
            // Enter.Into(driver, By.Id("Username"), dmiuser.username);
            // Enter.Into(driver, DMIPasswordResetRequestPage.EmailField, dmiuser.email);
            // Click.Button(driver, DMIPasswordResetRequestPage.SubmitButton);

            /*
            Console.WriteLine("DMIUSER Password:  " + dmiuser.password);
            //Console.WriteLine("The retrieved email link is:  " + link);
            ResetUserPassword.To(driver, dmiuser, "a23Qkjnd£$%");
            GoTo.DMILoginPage(driver);
            dmiuser.password = "a23Qkjnd£$%";
            Console.WriteLine("DMIUSER Password:  " + dmiuser.password);
            LoginTo.DmiAs(driver, dmiuser);
            */

        }
        [Given(@"I test my method")]
        public void GivenITestMyMethod()
        {
            //ITask a = Login.ToTheDmi();
           // Instrumented.InstanceOf<Login>();
        }

    }
}

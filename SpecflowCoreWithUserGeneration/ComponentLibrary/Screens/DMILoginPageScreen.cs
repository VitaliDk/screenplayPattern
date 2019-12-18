using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{
    public class DMILoginPageScreen
    {
        public static By UsernameField = By.Id("Username");
        public static By PasswordField = By.Id("Password");

        public static By LoginButton = By.Name("button");
        public static By SubmitButton = By.Name("button");

        public static By ForgotPasswordLink = By.PartialLinkText("Forgot Password");

        public static By InvalidLoginAttemptMessage = By.ClassName("validation-summary-errors");

    }
}

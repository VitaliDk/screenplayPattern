using OpenQA.Selenium;

namespace ComponentLibrary.Screens
{
    public class DMIPasswordResetPageScreen
    {
        public static By UsernameField = By.Name("Username");
        public static By PasswordField = By.Name("Password");
        public static By ConfirmPasswordField = By.Id("ConfirmPassword");
        public static By ResetPasswordButton = By.Name("submit");
    }
}

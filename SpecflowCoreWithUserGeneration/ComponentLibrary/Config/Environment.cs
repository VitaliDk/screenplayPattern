namespace ComponentLibrary.Config
{
    public static class Environment
    {
        public static string QAEnvironment = "7";
        public static string Email = "danial.khan@calastone.com";
        public static string ClientId = "2436"; // (for qa7 )"2436"; // was 2436 // 2542 for qa8

        public static string SqlServerUser = "ui_test_project"; //SQL USER with write permissions on CTN.Report, CAL_IdentityUser, ASPNetDb databases
        public static string SqlServerPassword = "h8VbTMTA65";
        public static BrowserType browser = BrowserType.Chrome;

        public static string DmiBaseUrl = $"https://dmiqa{QAEnvironment}.calastonetest.com/";
        public static string DmiUrl = $"https://dmiqa{QAEnvironment}.calastonetest.com/dmi";
        public static string GetTokenEndpoint = $"https://dmiqa{QAEnvironment}.calastonetest.com/login/oauth/connect/token";

        public static string SqlServer = $"QA-AZUKS-DMI{QAEnvironment}";

        public static string IdentityProviderUsersEndpoint = $"https://dmiqa{QAEnvironment}.calastonetest.com/login/oauth/users/";
    }
}

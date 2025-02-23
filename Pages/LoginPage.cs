using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;

namespace SpecFlowProjectMars.Pages
{
    public class LoginPage : CommonDriver
    {
        // Define the locators for the elements on the Login page
        private readonly By signInButtonLocator = By.XPath("//a[text()='Sign In']");
        IWebElement signInButton;
        private readonly By usernameTextboxLocator = By.XPath("//input[@name='email']");
        IWebElement usernameTextbox;
        private readonly By passwordTextboxLocator = By.XPath("//input[@name='password']");
        IWebElement passwordTextbox;
        private readonly By loginButtonLocator = By.XPath("//button[text()='Login']");
        IWebElement logInButton;

        public void LoginActions(string username, string password)
        {
            // Launch the portal and navigate to the login page
            string baseURL = "http://localhost:5000/";
            Console.WriteLine("Navigating to the base URL: " + baseURL);
            driver.Navigate().GoToUrl(baseURL);

            // Identify and click the "Sign In" button
            Console.WriteLine("Attempting to locate and click the 'Sign In' button.");
            signInButton = driver.FindElement(signInButtonLocator);
            signInButton.Click();
            Console.WriteLine("Clicked on the 'Sign In' button.");

            // Identify the Username textbox and enter the provided username
            Console.WriteLine("Locating the username textbox and entering the username: " + username);
            usernameTextbox = driver.FindElement(usernameTextboxLocator);
            usernameTextbox.SendKeys(username);
            Console.WriteLine("Entered username: " + username);

            // Identify the Password textbox and enter the provided password
            Console.WriteLine("Locating the password textbox and entering the password.");
            passwordTextbox = driver.FindElement(passwordTextboxLocator);
            passwordTextbox.SendKeys(password);
            Console.WriteLine("Entered password: ********");

            // Identify and click the "Login" button
            Console.WriteLine("Locating and clicking the 'Login' button.");
            logInButton = driver.FindElement(loginButtonLocator);
            logInButton.Click();
            Console.WriteLine("Clicked on the 'Login' button.");
        }
    }
}

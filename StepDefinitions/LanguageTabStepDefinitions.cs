using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProjectMars.Pages;
using SpecFlowProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectMars.StepDefinitions
{
    [Binding] // SpecFlow binding class to link step definitions with feature file steps
    public class LanguageTabStepDefinitions : CommonDriver
    {
        // Initialize page object models for Login, Profile, and Language pages
        LoginPage loginPageObj;
        ProfileHomePage profilePageObj;
        LanguagePage languagePageObj;

        // Define locators for popup messages that show the status of actions
        private static IWebElement popupmsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        // Define expected popup messages for different scenarios
        string popupMsgInv = "Please enter language and level";
        string popMsgSame = "This language is already added to your language list.";
        string popMsgDup = "Duplicated data";
        string popMsgUndefined = "Undefined";

        // Constructor to instantiate the page objects
        public LanguageTabStepDefinitions()
        {
            loginPageObj = new LoginPage();
            profilePageObj = new ProfileHomePage();
            languagePageObj = new LanguagePage();
        }

        // Step definition for logging into the Mars Portal
        [Given(@"user logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {           
            loginPageObj.LoginActions("amysarababy7@gmail.com", "12JuneB&A"); // Perform login actions with the provided credentials
            profilePageObj.VerifyLoggedInUser();// Verify the user is logged in
        }

        // Step definition for navigating to the Languages tab in Profile Page
        [Given(@"navigates to Languages tab in Profile Page")]
        public void GivenNavigatesToLanguagesTabInProfilePage()
        {           
            profilePageObj.NavigateToLanguagePanel();// Navigate to the Language section of the profile
        }

        // Step definition for entering a new language and its level
        [When(@"user enters Language ""([^""]*)"" and Language Level ""([^""]*)""")]
        public void WhenUserEntersLanguageAndLanguageLevel(string language, string level)
        {          
            languagePageObj.ClearData(); // Clear any pre-existing language data
            languagePageObj.AddLanguage(language, level);  // Add the provided language and level
        }

        // Step definition for verifying the addition of the language
        [Then(@"the language ""([^""]*)"" should be added to Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeAddedToLanguagesTabInProfilePage(string language)
        {           
            Thread.Sleep(3000);// Wait for the popup message to appear
            string popupMsgBox = popupmsg.Text;// Capture the popup message text
            Console.WriteLine(popupMsgBox);            
            string popupMsgadd = language + " has been added to your languages"; // Form the expected message for successful language addition
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popMsgSame).Or.EqualTo(popMsgUndefined).Or.EqualTo(popMsgDup));  // Verify that the popup message matches the expected success or error messages
        }

        // Step definition for editing an existing language and its level
        [When(@"user edits Language ""([^""]*)"" and Language Level ""([^""]*)""")]
        public void WhenUserEditsLanguageAndLanguageLevel(string language, string level)
        {           
            languagePageObj.EditLanguage(language, level); // Edit the existing language with the new level
        }

        // Step definition for verifying the successful editing of a language
        [Then(@"the language ""([^""]*)"" should be edited into Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeEditedIntoLanguagesTabInProfilePage(string language)
        {
            // Wait for the popup message box to be visible
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box-inner']")));

            // Capture the popup message text
            string popupMsgBox = popupmsg.Text;
            Console.WriteLine(popupMsgBox);            
            string expectedMessage = $"{language} has been updated to your languages";  // Expected message with dynamic language insertion

            // Verify that the popup message matches the expected dynamic message
            Assert.That(popupMsgBox,
                        Is.EqualTo(expectedMessage) // Check for the exact message
                        .Or.EqualTo(popupMsgInv)    // Check for other possible messages
                        .Or.EqualTo(popMsgSame)
                        .Or.EqualTo(popMsgDup)
                        .Or.EqualTo(popMsgUndefined));
        }

        // Step definition for deleting a language
        [When(@"user deletes the Language ""([^""]*)""")]
        public void WhenUserDeletesTheLanguage(string language)
        {           
            languagePageObj.RemoveLanguage();  // Remove the specified language from the profile
        }

        // Step definition for verifying that a language was deleted
        [Then(@"the language ""([^""]*)"" should be deleted from Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeDeletedFromLanguagesTabInProfilePage(string language)
        {
            // Wait for the popup message box to be visible
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box-inner']")));
            Thread.Sleep(3000);
            // Capture the popup message text
            string popupMsgBox = popupmsg.Text;
            Console.WriteLine(popupMsgBox);           
            string popupMsgadd = language + " has been deleted from your languages";// Form the expected message for successful deletion
            Assert.AreEqual(popupMsgadd, popupmsg.Text); // Verify that the popup message matches the expected deletion message
        }
    }
}

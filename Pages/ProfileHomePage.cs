using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProjectMars.Pages
{
    public class ProfileHomePage : CommonDriver
    {
        // Navigate to Language tab in the Profile Page
        public void NavigateToLanguagePanel()
        {
            try
            {
                // Wait for the Language tab to be visible and clickable
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement languageTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Languages']")));
                languageTab.Click();
                Console.WriteLine("Navigated to Languages panel.");
            }
            catch (NoSuchElementException ex)
            {
                // Error message for element not found
                Console.WriteLine("Error: Language tab not found. " + ex.Message);
                Assert.Fail("Language panel tab is not clickable.");
            }
            catch (Exception ex)
            {   
                Console.WriteLine("Error while navigating to Language panel: " + ex.Message);
                Assert.Fail("Unexpected error while navigating to Language panel.");
            }
        }

        // Navigate to Skills tab in the Profile Page
        public void NavigateToSkillsPanel()
        {
            try
            {
                // Wait for the Skills tab to be visible and clickable
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement skillsTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Skills']")));
                skillsTab.Click();
                Console.WriteLine("Navigated to Skills panel.");
            }
            catch (NoSuchElementException ex)
            {
                // Error message for element not found
                Console.WriteLine("Error: Skills tab not found. " + ex.Message);
                Assert.Fail("Skills panel tab is not clickable.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while navigating to Skills panel: " + ex.Message);
                Assert.Fail("Unexpected error while navigating to Skills panel.");
            }
        }

        // Verify if the user is logged in by checking the greeting text
        public void VerifyLoggedInUser()
        {          
            Thread.Sleep(1000);
            Console.WriteLine("Verifying if the user is logged in...");

            try
            {
                
                IWebElement checkUser = driver.FindElement(By.XPath("//span[contains(text(),'Hi')]"));               
                Console.WriteLine("Found user greeting text: " + checkUser.Text);              
                if (checkUser.Text == "Hi Amy")
                {                    
                    Console.WriteLine("Successful Login: User 'Amy' is logged in.");
                }
                else
                {
                    Console.WriteLine("Invalid Login: User not recognized.");
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Error: User greeting element not found. " + ex.Message);
            }
            catch (Exception ex)
            {               
                Console.WriteLine("Unexpected error during login verification: " + ex.Message);
            }
        }



    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;
using System;
using System.Threading;

namespace SpecFlowProjectMars.Pages
{
    public class LanguagePage : CommonDriver
    {
        // Define WebElement locators
        private static IWebElement addNewLangButton => driver.FindElement(By.XPath("//div[contains(text(),'Add New')]"));
        private static IWebElement languageTextbox => driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Language']"));
        private static IWebElement selectLangLevelOption => driver.FindElement(By.Name("level"));
        private static IWebElement addLangButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement popupmsg => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
        private static IWebElement editNewLangButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement editLangTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement editselectLangLevelOption => driver.FindElement(By.Name("level"));
        private static IWebElement updateLangButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement editLangAdded => driver.FindElement(By.XPath("//td[text()='Manglish']"));
        private static IWebElement deleteLangButton => driver.FindElement(By.CssSelector("i[class='remove icon']"));
        private static IWebElement deleteLangAdded => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));

        // Method to clear all previously added languages
        public void ClearData()
        {
            try
            {
                // Find all delete buttons for each language
                var deleteButtons = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));

                // Click delete on all found language entries
                foreach (var button in deleteButtons)
                {
                    button.Click();
                    Console.WriteLine("Language entry deleted.");
                }
            }
            catch (NoSuchElementException)
            {
                // If no delete button is found, print message
                Console.WriteLine("No language entries found to delete.");
            }
        }

        // Method to add a new language
        public void AddLanguage(string language, string level)
        {
            try
            {
                // Click to add a new language
                Console.WriteLine("Clicking 'Add New Language' button...");
                addNewLangButton.Click();

                // Enter language name
                Console.WriteLine($"Entering language: {language}");
                languageTextbox.SendKeys(language);

                // Choose language level from dropdown
                Console.WriteLine($"Selecting language level: {level}");
                selectLangLevelOption.Click();
                selectLangLevelOption.SendKeys(level);

                // Click the add button to save the language
                Console.WriteLine("Clicking 'Add' to add language...");
                addLangButton.Click();
                Thread.Sleep(3000); // Wait for the language to be added
                Console.WriteLine("Language added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while adding language: {ex.Message}");
            }
        }

        // Method to edit an existing language
        public void EditLanguage(string language, string level)
        {
            try
            {
                // Click to edit existing language
                Console.WriteLine("Clicking 'Edit' on the language...");
                editNewLangButton.Click();
                Thread.Sleep(1000);

                // Clear the current language and enter the new language
                Console.WriteLine($"Editing language to: {language}");
                editLangTextbox.Clear();
                editLangTextbox.SendKeys(language);

                // Choose language level from dropdown
                Console.WriteLine($"Selecting new language level: {level}");
                editselectLangLevelOption.Click();
                editselectLangLevelOption.SendKeys(level);
                Thread.Sleep(1000);

                // Click the update button to save changes
                Console.WriteLine("Clicking 'Update' to save language changes...");
                updateLangButton.Click();
                Console.WriteLine("Language updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while editing language: {ex.Message}");
            }
        }

        // Method to remove a language
        public void RemoveLanguage()
        {
            try
            {
                // Click to remove the language
                Console.WriteLine("Clicking 'Delete' to remove the language...");
                deleteLangButton.Click();
                Console.WriteLine("Language removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while removing language: {ex.Message}");
            }
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;

namespace SpecFlowProjectMars.Pages
{
    public class SkillsPage : CommonDriver
    {
        // Locators for elements on the Skills page
        IWebElement addNewSkillButton => driver.FindElement(By.CssSelector("div[class='ui teal button']"));
        IWebElement skillsTextbox => driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Skill']"));
        IWebElement skillLevelOption => driver.FindElement(By.Name("level"));
        IWebElement addSkillButton => driver.FindElement(By.CssSelector("input[class='ui teal button ']"));
        IWebElement editSkillTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        IWebElement editSkillLevel => driver.FindElement(By.Name("level"));
        IWebElement newSkillAdded => driver.FindElement(By.XPath("//td[text()='Multitasking']"));
        IWebElement editNewSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        IWebElement updateSkillButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        IWebElement editSkillAdded => driver.FindElement(By.XPath("//td[text()='Multitasker']"));
        IWebElement deleteSkillButton => driver.FindElement(By.CssSelector("i[class='remove icon']"));
        IWebElement deleteSkillAdded => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
        private static IWebElement popupmsg => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));

        // Method to clear any existing skill data from the profile
        public void ClearData()
        {
            try
            {
                // Find all delete icons (remove skill buttons)
                var deleteButton = driver.FindElements(By.CssSelector("i[class='remove icon']"));
                // Click each delete button to remove any existing skills
                foreach (var button in deleteButton)
                {
                    button.Click();
                }
            }
            catch
            {
                // In case of any exception, nothing is done, just continue
            }
        }

        // Method to add a new skill with a specified skill level
        public void AddSkills(string skills, string skillLevel)
        {            
            addNewSkillButton.Click();// Click on the "Add New Skill" button
            skillsTextbox.SendKeys(skills); // Enter the skill in the text field
            // Select the skill level from the dropdown
            skillLevelOption.Click();
            skillLevelOption.SendKeys(skillLevel);           
            addSkillButton.Click();// Click on the "Add" button to submit the skill
        }

        // Method to edit an existing skill and its level
        public void EditSkill(string skills, string skillLevel)
        {
            Thread.Sleep(1000); // Wait for any transition or load delay (consider using WebDriverWait instead of Thread.Sleep)            
            editNewSkillButton.Click();// Click the "Edit" button for the skill
            editSkillTextbox.Clear();// Clear the existing skill value in the text field
            editSkillTextbox.SendKeys(skills);  // Enter the new skill
            // Click on the skill level dropdown and select the new level
            editSkillLevel.Click();
            editSkillLevel.SendKeys(skillLevel);          
            updateSkillButton.Click(); // Click the "Update" button to save the edited skill
        }

        // Method to remove a skill
        public void RemoveSkill()
        {           
            deleteSkillButton.Click(); // Click on the "Delete" button for the skill
        }
    }
}

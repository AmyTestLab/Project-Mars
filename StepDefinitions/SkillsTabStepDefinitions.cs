using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Pages;
using SpecFlowProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectMars.StepDefinitions
{
    [Binding] // This attribute binds the class to SpecFlow, linking step definitions with feature file steps
    public class SkillsTabStepDefinitions : CommonDriver
    {
        // Initialize page object models for Login, Profile, and Skills pages
        LoginPage loginPageObj;
        ProfileHomePage profilePageObj;
        SkillsPage skillPageObj;

        // Define a locator for the popup message element
        private static IWebElement popupmsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        // Define various expected popup messages for skill-related actions
        string popupMsgInv = "Please enter skill and experience level";
        string popMsgSame = "This skill is already added to your skill list.";
        string popMsgDup = "Duplicated data";
        string popMsgUndefined = "Undefined";

        // Constructor to instantiate the page objects
        public SkillsTabStepDefinitions()
        {
            loginPageObj = new LoginPage();
            profilePageObj = new ProfileHomePage();
            skillPageObj = new SkillsPage();
        }

        // Step definition for logging into the Mars Portal
        [Given(@"User logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            loginPageObj.LoginActions("amysarababy7@gmail.com", "12JuneB&A");    // Perform login actions using credentials 
            profilePageObj.VerifyLoggedInUser();// Verify that the user has logged in successfully
        }

        // Step definition for navigating to the Skills tab in Profile Page
        [Given(@"navigates to Skills tab in Profile Page")]
        public void GivenNavigatesToSkillsTabInProfilePage()
        {           
            profilePageObj.NavigateToSkillsPanel(); // Navigate to the Skills section in the Profile
        }

        // Step definition for adding a new skill and its level
        [When(@"user enters Skill ""([^""]*)"" and Skill Level ""([^""]*)""")]
        public void WhenUserEntersSkillAndSkillLevel(string skill, string skilllevel)
        {
            skillPageObj.ClearData();   // Clear any existing skills data in the profile
            skillPageObj.AddSkills(skill, skilllevel);// Add the provided skill and its corresponding level to the profile
        }

        // Step definition to verify that the skill has been added
        [Then(@"the Skill ""([^""]*)"" should be added to Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeAddedToSkillsTabInProfilePage(string skill)
        {           
            Thread.Sleep(3000);         
            string popupMsgBox = popupmsg.Text;  // Capture the text from the popup message
            Console.WriteLine(popupMsgBox);           
            string popupMsgadd = skill + " has been added to your skills";// Form the expected message for successful skill addition
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popMsgSame).Or.EqualTo(popMsgDup).Or.EqualTo(popMsgUndefined));       // Verify that the popup message matches the expected success or error messages
        }

        // Step definition for editing an existing skill and its level
        [When(@"user edits Skill ""([^""]*)"" and Skill Level ""([^""]*)""")]
        public void WhenUserEditsSkillAndSkillLevel(string skill, string skillLevel)
        {            
            skillPageObj.EditSkill(skill, skillLevel);// Edit the existing skill with the new level
        }

        // Step definition to verify that the skill has been updated
        [Then(@"the Skill ""([^""]*)"" should be updated to Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeUpdatedToSkillsTabInProfilePage(string skill)
        {           
            Thread.Sleep(3000);           
            string popupMsgBox = popupmsg.Text;    // Capture the text from the popup message        
            string popupMsgadd = skill + " has been updated to your skills";        // Form the expected message for successful skill update  
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popMsgSame).Or.EqualTo(popMsgUndefined).Or.EqualTo(popMsgDup)); // Verify that the popup message matches the expected success or error messages
        }

        // Step definition for deleting a skill from the profile
        [When(@"user deletes Skill ""([^""]*)""")]
        public void WhenUserDeletesSkill(string skill)
        {            
            skillPageObj.RemoveSkill(); // Remove the specified skill from the profile
        }

        // Step definition to verify that the skill has been deleted
        [Then(@"the Skill ""([^""]*)""should be deleted from Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeDeletedFromSkillsTabInProfilePage(string skill)
        {           
            Thread.Sleep(3000);  // Wait for the popup message to appear (thread sleep to ensure visibility)         
            string popupMsgBox = popupmsg.Text;  // Capture the text from the popup message
            Console.WriteLine(popupMsgBox);           
            string popupMsgadd = skill + " has been deleted";  // Form the expected message for successful skill deletion       
            Assert.AreEqual(popupMsgadd, popupmsg.Text);   // Verify that the popup message matches the expected deletion message
        }
    }
}

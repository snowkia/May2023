using System;
using May2023.Pages;
using May2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace May2023.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        [Given(@"I logged into turnup up portal successfully")]
        public void GivenILoggedIntoTurnupUpPortalSuccessfully()
        {
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            T_MPage tmPageObj = new T_MPage();
            tmPageObj.CreateTM(driver);
        }

        [Then(@"The record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            T_MPage tmPageObj = new T_MPage();

            string newDescription = tmPageObj.GetDescription(driver);
            string newCode = tmPageObj.GetCode(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.AreEqual("May2023", newDescription, "Actual Description and expected description do not match.");
            Assert.AreEqual("May2023", newCode, "Actual Code and expected code do not match.");
            Assert.AreEqual("$12.00", newPrice, "Actual Price and expected price do not match.");
        }

        [When(@"I update '([^']*)', '([^']*)' and '([^']*)' on an existing time and material record")]
        public void WhenIUpdateAndOnAnExistingTimeAndMaterialRecord(string description, string code, string price)

        {
            T_MPage tmPageObj = new T_MPage();
            tmPageObj.EditTM(driver, description, code, price);
        }

        [Then(@"The record should been updated '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldBeenUpdatedAnd(string description, string code, string price)
        {
            T_MPage tmPageObj = new T_MPage();

            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedCode = tmPageObj.GetEditedCode(driver);
            string editedPrice = tmPageObj.GetEditedPrice(driver);

            Assert.AreEqual(code, editedCode, "Actual edited description and expected edited description do not match.");
            Assert.AreEqual(description, editedDescription, "Actual edited description and expected edited description do not match.");
            Assert.AreEqual(price, editedPrice, "Actual Price and expected price do not match.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using May2023.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using May2023.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace May2023.Tests
{


    
        [TestFixture]
        [Parallelizable]
        public class TM_Tests : CommonDriver
        {
            [SetUp]
            public void SetUpActions()
            {
                // open chrome browser
                driver = new ChromeDriver();

                // Login page object initialization and definition
                LoginPage loginPageObj = new LoginPage();
                loginPageObj.LoginSteps(driver);

                // Home page object initialization and definition
                HomePage homePageObj = new HomePage();
                homePageObj.GoToTMPage(driver);
            }

            [Test, Order(1)]
            public void CreateTime_Test()
            {
                // TM page object initialization and definition
                T_MPage tmPageObj = new T_MPage();
                tmPageObj.CreateTM(driver);
            }

            [Test, Order(2)]
            public void EditTime_Test()
            {
                // TM page object initialization and definition
                T_MPage tmPageObj = new T_MPage();
                // Edit Time record
                tmPageObj.EditTM(driver);
            }

            [Test, Order(3)]
            public void DeleteTime_Test()
            {
                // TM page object initialization and definition
                T_MPage tmPageObj = new T_MPage();
                // Delete Time record
                tmPageObj.DeleteTM(driver);
            }

            [TearDown]
            public void CloseTestRun()
            {
                driver.Quit();

            }
        }
    }


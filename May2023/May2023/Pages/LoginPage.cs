using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using May2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace May2023.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            //launch turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            Thread.Sleep(4000);

            Wait.WaitToExist(driver, "Id", "UserName", 3);

            try
            {
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");
            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal page didn not load.", ex);
            }

            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(1000);

        }


    }
}

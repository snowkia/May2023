using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using May2023.Utilities;
using OpenQA.Selenium;

namespace May2023.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            //NAVIGATE TO TIME AND MATERIAL PAGE
            IWebElement ADMINTAB = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            ADMINTAB.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 7);

            IWebElement TMoption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TMoption.Click();
        }

            public void GoToEmployeesPage(IWebDriver driver)
            {
                // Code to go to employees page
            }
        }
    }

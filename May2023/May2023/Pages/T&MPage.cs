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
    public class T_MPage
    {
        public void CreateTM(IWebDriver driver)
        {
            //CLICK ON CREATE NEW BUTTON 
            IWebElement createnewbutton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createnewbutton.Click();


            //SELECT TIME FROM DROP DOWN LIST
            IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            TypeCode.Click();
            IWebElement TimeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            TimeOption.Click();


            //INPUT TYPECODE
            IWebElement CodeTextbox = driver.FindElement(By.Id("Code"));
            CodeTextbox.SendKeys("May2023");


            //INPUT DESCRIPTION
            IWebElement DescriptionTextbox = driver.FindElement(By.Id("Description"));
            DescriptionTextbox.SendKeys("May2023");

            //INPUT PRICE PER UNIT
            IWebElement PriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            PriceTextbox.SendKeys("12");


            //CLICK ON SAVE BUTTON
            IWebElement SaveButton = driver.FindElement(By.Id("SaveButton"));
            SaveButton.Click();
            Thread.Sleep(3000);

            //CHK IF NEW T&m RECORD HAS BEEN CREATED SUCCESSFULLY

            //navigate to last page 
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
            IWebElement gotolastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            Thread.Sleep(3000);
            gotolastpagebutton.Click();




            //find the last record on list page 
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(newCode.Text == "May2023", "Actual Code and expected code do not match.");
            Assert.That(newTypeCode.Text == "T", "Actual TypeCode and expected typecode do not match.");
            Assert.That(newDescription.Text == "May2023", "Actual Description and expected description do not match.");
            Assert.That(newPrice.Text == "$12.00", "Actual Price and expected price do not match.");

        

    }
        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();


            IWebElement lastElement = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lastElement.Text == "May2023")
            {
                Thread.Sleep(2000);
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(3000);
            }
            else
            {
                Assert.Fail("New record created hasn't been found.");
            }

            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("June2023");

            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys("June2023");

            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("30");
            Thread.Sleep(2000);

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1000);
        }

        public void DeleteTM(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            Thread.Sleep(1000);
            IWebElement deleteRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteRecord.Click();


            // To Click OK in altert window
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(editedCode.Text != "June2023", "Record hasn't been deleted.");
        }
    }
}
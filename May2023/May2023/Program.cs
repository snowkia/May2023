using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
       //open chrome browser 
       IWebDriver driver = new ChromeDriver();


        //launch turnup portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

       //identify username textbox enter valid username
       IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");
     
       //identify password textbox enter valid password
       IWebElement passwordtextbox = driver.FindElement(By.Id("Password"));
        passwordtextbox.SendKeys("123123");

        //click login button
        IWebElement loginbutton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));

            loginbutton.Click();


        //check if user has logged in successfully
        IWebElement hellohari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (hellohari.Text == "Hello hari!")

            Console.WriteLine("User log in successful");

        else Console.WriteLine("User has NOT logged in.");


        //CREATE NEW RECORD

        //NAVIGATE TO TIME AND MATERIAL PAGE
        IWebElement ADMINTAB = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        ADMINTAB.Click();

        IWebElement TMoption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        TMoption.Click();


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
        IWebElement gotolastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        gotolastpagebutton.Click();
        

        //check if record is present in the table
        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newCode.Text == "May2023")

            Console.WriteLine("Time record created successfully");

        else
            Console.WriteLine("Time record has NOT been created");





    }
}
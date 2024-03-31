// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Selenium_Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver chromedriver = new ChromeDriver();
            chromedriver.Manage().Window.Maximize();

            //Register
            chromedriver.Navigate().GoToUrl("http://localhost:3000/signup");
            Thread.Sleep(2000);

            IWebElement name = chromedriver.FindElement(By.Id("registerName"));
            name.SendKeys("Jeni");
            Thread.Sleep(2000);

            IWebElement registeremail = chromedriver.FindElement(By.Id("email"));
            registeremail.SendKeys("jenifer@gmail.com");
            Thread.Sleep(2000);

            IWebElement phone_No = chromedriver.FindElement(By.Id("phone_No"));
            phone_No.SendKeys("9876549898");
            Thread.Sleep(2000);

            IWebElement registerpassword = chromedriver.FindElement(By.Id("customer_password"));
            registerpassword.SendKeys("1234567");
            Thread.Sleep(2000);

            IWebElement confirmpassword = chromedriver.FindElement(By.Id("Confirm_Password"));
            confirmpassword.SendKeys("1234567");
            Thread.Sleep(2000);

            IWebElement register = chromedriver.FindElement(By.Id("registerBtn"));
            register.Click();
            Thread.Sleep(2000);

            // Handle alert
            try
            {
                IAlert alert = chromedriver.SwitchTo().Alert();
                string alertText = alert.Text;
                Console.WriteLine("Alert text: " + alertText);
                alert.Accept(); // To accept the alert (click OK)
                                //alert.Dismiss(); // To dismiss the alert (click Cancel)

                string nextPageUrl = "http://localhost:3000/login";
                chromedriver.Navigate().GoToUrl(nextPageUrl);

            }
            catch (NoAlertPresentException)
            {
                // No alert present, continue with the rest of the code
            }



            //Login
            chromedriver.Navigate().GoToUrl("http://localhost:3000/login");
            Thread.Sleep(2000);

            IWebElement loginemail = chromedriver.FindElement(By.Id("loginEmail"));
            loginemail.SendKeys("jenifer@gmail.com");
            Thread.Sleep(2000);

            IWebElement loginpassword = chromedriver.FindElement(By.Id("loginPassword"));
            loginpassword.SendKeys("1234567");
            Thread.Sleep(2000);

            IWebElement login = chromedriver.FindElement(By.Id("loginButton"));
            login.Click();
            Thread.Sleep(2000);

            // Handle alert
            try
            {
                IAlert alert = chromedriver.SwitchTo().Alert();
                string alertText = alert.Text;
                Console.WriteLine("Alert text: " + alertText);
                alert.Accept(); // To accept the alert (click OK)
                                //alert.Dismiss(); // To dismiss the alert (click Cancel)

                string nextPageUrl = "http://localhost:3000/home";
                chromedriver.Navigate().GoToUrl(nextPageUrl);

            }
            catch (NoAlertPresentException)
            {
                // No alert present, continue with the rest of the code
            }
        }
    }
}
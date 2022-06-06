using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace
ProductAppsTest
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            var options = new ChromeOptions();
            options.AddArgument("--disable-extensions");
            options.AddArguments("disable-infobars");
            options.AddArgument("--no-sandbox");
            driver = new ChromeDriver(options);
        }
        [Test]
        public void test_Creat_Product_form()
        {
            driver.Url = "http://localhost:44319/";
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("http://localhost:44319/Product/Create");
            driver.Manage().Window.Maximize();
            // IWebElement ap = driver.FindElement(By.Id("learn"));
            IWebElement FeedCreate = driver.FindElement(By.XPath("/html/body/div[2]/h2"));
            string text = FeedCreate.Text;
            //String title = driver.Title;
            NUnit.Framework.Assert.AreEqual("Create", text);
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
        }
        [Test]
        public void testCreate()
        {
            driver.Url = "http://localhost:44319/";
            driver.Navigate().GoToUrl("http://localhost:44319/Product/Create");
            driver.Manage().Window.Maximize();
            // IWebElement ap = driver.FindElement(By.ID("learn"));
            IWebElement ProductNameTextbox = 
                driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[1]/div/input"));
            ProductNameTextbox.Click();
            ProductNameTextbox.SendKeys("Orange");
            System.Threading.Thread.Sleep(2000);
            IWebElement PriceTextbox =
            driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[2]/div/input"));
            PriceTextbox.Click();
            PriceTextbox.SendKeys("2.0");
            System.Threading.Thread.Sleep(2000);
            IWebElement DescriptionTextbox =
            driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[3]/div/input"));
            DescriptionTextbox.Click();
            DescriptionTextbox.SendKeys("Juicy orange");
            System.Threading.Thread.Sleep(2000);
            IWebElement SubmitButton =
            driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[4]/div/input"));
            SubmitButton.Click();
            IWebElement IndexLabel = driver.FindElement(By.XPath("/html/body/div[2]/h2"));
            String labelText = IndexLabel.Text;
            System.Threading.Thread.Sleep(2000);
            NUnit.Framework.Assert.AreEqual("Index", labelText);
            System.Threading.Thread.Sleep(2000);
            //driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
        }
        [TearDown] public void
        closeBrowser()
        {
            driver.Close();
        }
    }
}
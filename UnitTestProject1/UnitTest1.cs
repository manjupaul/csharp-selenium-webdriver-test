using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;

        public object Browser { get; private set; }

        [AssemblyInitialize]
        public static void setup(TestContext context)
        {

            driver = new FirefoxDriver();
            driver.Url = "http://www.dice.com/";

        }
        [TestMethod]
        public void TestDiceHomePage()
        {

            Assert.IsTrue(driver.PageSource.Contains("Find Tech Jobs"));

        }
        [TestMethod]
        public void SearchJob()
        {
            var searchBox = driver.FindElement(By.Id("search-field-keyword"));
            searchBox.SendKeys("Test Automation Engineer");
            var SearchLocation = driver.FindElement(By.Id("search-field-location"));
            SearchLocation.SendKeys("Washington,DC");
            var FindTechJob = driver.FindElement(By.XPath("//*[@id='search-form']/fieldset/div[4]/div/div[1]/button"));
            FindTechJob.Click();              
            Assert.IsTrue(driver.PageSource.Contains("Current page is 1"));

        }
       


    }
}

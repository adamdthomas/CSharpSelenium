using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GeicoTest.GeicoDotCom;

namespace GeicoTest
{
    [TestClass]
    public class UnitTest1
    {

        IWebDriver driver;

        [TestCleanup]
        public void teardown()
        {
            driver.Quit();
        }

        [TestInitialize]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.gecio.com");
        }


        [TestMethod]
        public void RentersIconTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.SelectProduct("Renters");
            homePage.StartQuote("20878");

            CustomerInformationPage customerInformationPage = new CustomerInformationPage(driver);
            customerInformationPage.FillForm();
            

           // Assert.AreEqual("Customer Information", iconSelected);
        }


        //[TestMethod]
        //public void FailedTestExample()
        //{
    
        //}

    }
}

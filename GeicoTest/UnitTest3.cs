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
            string zip = "20878";
            string city = "GAITHERSBURG";
            string streetAddress = "15705 Mahogany Cir";

            HomePage homePage = new HomePage(driver);
            homePage.SelectProduct("Renters");
            homePage.StartQuote(zip);
  
            CustomerInformationPage customerInformationPage = new CustomerInformationPage(driver);
            customerInformationPage.FillForm(streetAddress, city);

            ResidenceInformationPage residenceInformation = new ResidenceInformationPage(driver);

            residenceInformation.GetAddress();

            Assert.AreEqual(zip, residenceInformation.zip);
            Assert.AreEqual(city, residenceInformation.city);
            Assert.AreEqual(streetAddress.ToUpper(), residenceInformation.address);
            Assert.AreEqual(customerInformationPage.state, residenceInformation.state);

        }


        [TestMethod]
        public void theothertest()
        {
            ResidenceInformationPage residenceInformation = new ResidenceInformationPage(driver);
        }

    }
}

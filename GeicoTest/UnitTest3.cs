using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GeicoTest.GeicoDotCom;
using OpenQA.Selenium.Remote;
using System.Linq;
using System.Threading;
using AutoIt;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace GeicoTest
{
    [TestFixture]
    [Parallelizable]
    public class UnitTest1
    {

        IWebDriver driver;

        [Test]
        [Ignore("not needed")]
        public void TableTest()
        {
            string searchHeader = "Contact";
            string searchData = "Adam Thomas";
            bool foundSearchTerm = false;
            int foundColumn = -1;

            driver.Navigate().GoToUrl("https://www.w3schools.com/html/html_tables.asp");

            IWebElement table = driver.FindElement(By.Id("customers"));

            IList<IWebElement> tableRows = table.FindElements(By.TagName("tr"));

            IList<IWebElement> tableHeaders = tableRows[0].FindElements(By.TagName("th"));

            //Find data/column nunmber for a certain header
            for (int i = 0; i < tableHeaders.Count - 1; i++)
            {
                if (tableHeaders[i].Text == searchHeader)
                {
                    foundColumn = i;
                }
            }


            for (int r = 1; r < tableRows.Count - 1; r++)
            {
                IList<IWebElement> tableData = tableRows[r].FindElements(By.TagName("td"));

                if (tableData[foundColumn].Text == searchData)
                {
                    foundSearchTerm = true;
                    break;
                }
                
            }


            foreach (var row in tableRows)
            {
                IList<IWebElement> tableData = row.FindElements(By.TagName("td"));

                foreach (var data in tableData)
                {
                    string foundData = data.Text;
                }
            }
        }
     

        [Test]
        [Ignore ("not needed")]
        public void AutoITPictureUpload()
        {
            driver.Navigate().GoToUrl("http://www.picresize.com/");
            driver.FindElement(By.Id("im_file")).Click();

            AutoItX.WinActivate("Open");
            AutoItX.Send(@"C:\Temp\fly.png");
            AutoItX.Send("{ENTER}");
            Thread.Sleep(7500);
        }


        [Test]
        [Ignore("not needed")]
        public void CalcTest()
        {

            IWebElement allClearBTN = driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc='All clear']"));
            allClearBTN.Click();

            IWebElement sevenBTN = driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc='7']"));
            sevenBTN.Click();

            IWebElement plusBTN = driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc='Addition']"));
            plusBTN.Click();

            IWebElement threeBTN = driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc='3']"));
            threeBTN.Click();

            IWebElement equalsBTN = driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc='equal']"));
            equalsBTN.Click();

            IWebElement outputWindow = driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.ViewSwitcher/com.android.calculator2.CalculatorEditText"));
            string answer = outputWindow.Text;

            string[] parts = answer.Split(' ');

            Assert.AreEqual("10", parts.Last());

        }


        [Test]
        [Category("Smoke")]
        public void RentersIconTest()
        {
            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://www.geico.com");
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
            //driver.Quit();
        }

      




        [Test]
        [Ignore("not needed")]
        public void theothertest()
        {
            ResidenceInformationPage residenceInformation = new ResidenceInformationPage(driver);
        }

        [TearDown]
        public void teardown()
        {

            driver.Quit();
            //driver.Quit();
        }


        [SetUp]
        public void setup()
        {

            //Appium Driver instantiation
            //DesiredCapabilities caps = new DesiredCapabilities();
            //caps.SetCapability("deviceName", "LGLS992d45fa362");
            //caps.SetCapability("platformName", "Android");
            ////caps.SetCapability("browserName", "Chrome");
            //caps.SetCapability("appPackage", "com.android.calculator2");
            //caps.SetCapability("appActivity", "com.android.calculator2.Calculator");
            //driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), caps);

            //Grid
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, "chrome");
            caps.SetCapability(CapabilityType.Platform, "WIN10");
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), caps);

            //Basic Driver instantiation 
          //  driver = new ChromeDriver();


            //Navigation
            driver.Navigate().GoToUrl("http://www.geico.com");
        }

    }
}

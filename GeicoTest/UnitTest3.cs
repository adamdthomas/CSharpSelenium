using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GeicoTest.GeicoDotCom;
using OpenQA.Selenium.Remote;
using System.Linq;
using System.Threading;
using AutoIt;
using NUnit.Framework;

namespace GeicoTest
{
    [TestFixture]
    public class UnitTest1
    {

        IWebDriver driver;

        [TearDown]
        public void teardown()
        {
            driver.Quit();
        }

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            //DesiredCapabilities caps = new DesiredCapabilities();
            //caps.SetCapability("deviceName", "LGLS992d45fa362");
            //caps.SetCapability("platformName", "Android");
            ////caps.SetCapability("browserName", "Chrome");
            //caps.SetCapability("appPackage", "com.android.calculator2");
            //caps.SetCapability("appActivity", "com.android.calculator2.Calculator");

            //driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), caps);

            driver.Navigate().GoToUrl("http://www.geico.com");
        }

        [Test]
        [Ignore ("not needed")]
        public void AutoITPictureUpload()
        {
            driver.Navigate().GoToUrl("http://www.picresize.com/");
            driver.FindElement(By.Id("im_file")).Click();

            //AutoItX autoIt = new AutoItX();

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

        [Test]
        public void RentersIconTest2()
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



        [Test]
        [Ignore("not needed")]
        public void theothertest()
        {
            ResidenceInformationPage residenceInformation = new ResidenceInformationPage(driver);
        }

    }
}

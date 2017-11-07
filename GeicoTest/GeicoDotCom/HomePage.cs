using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeicoTest.GeicoDotCom
{
    public class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectProduct(string productName)
        {
            By productLocator = By.XPath("//p[.='" + productName + "']/..//span");
            driver.FindElement(productLocator).Click();

            // Thread.Sleep(1750);
            //By iconLocator = By.XPath("//div[@class='product selected']");
            ////WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            ////wait.Until(ExpectedConditions.ElementIsVisible(iconLocator));
            //return driver.FindElement(iconLocator).Text;
        }

        public void StartQuote(string zip)
        {
            driver.FindElement(By.Id("zip")).SendKeys(zip);
            driver.FindElement(By.Id("submitButton")).Click();
        }

        public void StartQuote()
        {
            driver.FindElement(By.Id("submitButton")).Click();
        }



    }
}

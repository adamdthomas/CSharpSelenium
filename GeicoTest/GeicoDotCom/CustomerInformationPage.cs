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
    public class CustomerInformationPage
    {
        IWebDriver driver;

        public CustomerInformationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillForm()
        {
            driver.FindElement(By.XPath("//label[.='First Name']/following::input[1]")).SendKeys("Adam");
            driver.FindElement(By.XPath("//label[.='Last Name']/following::input[1]")).SendKeys("Thomas");
            driver.FindElement(By.XPath("//label[.='Date of Birth']/following::input[1]")).SendKeys("01/01/1980");
            driver.FindElement(By.XPath("//label[.='Street Address']/following::input[1]")).SendKeys("123 Main St");
            SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath("//select[contains(@id, 'PropertyCityList')]")));
            selectElement.SelectByText("GAITHERSBURG");

            Thread.Sleep(30000);
        }

    }
}

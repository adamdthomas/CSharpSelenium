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
        public string state;

        public CustomerInformationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillForm(string streetAddress, string city)
        {
            driver.FindElement(By.XPath("//label[.='First Name']/following::input[1]")).SendKeys("Adam");
            driver.FindElement(By.XPath("//label[.='Last Name']/following::input[1]")).SendKeys("Thomas");
            IWebElement birthDate = driver.FindElement(By.XPath("//label[.='Date of Birth']/following::input[1]"));
            birthDate.Clear();
            birthDate.SendKeys("01011980");

            driver.FindElement(By.XPath("//label[.='Street Address']/following::input[1]")).SendKeys(streetAddress);
            SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath("//select[contains(@id, 'PropertyCityList')]")));
            selectElement.SelectByText(city);

            IWebElement startRent = driver.FindElement(By.XPath("//label[contains(., 'started renting')]/following::input[1]"));
            startRent.Clear();
            startRent.SendKeys("01012001");

            driver.FindElement(By.XPath("//label[(contains(@class, 'radio')) and (contains(., '15'))]")).Click();

            DateTime tomorrow = DateTime.Now.AddDays(1);
            IWebElement startDate = driver.FindElement(By.XPath("//label[contains(., 'Desired coverage')]/following::input[1]"));
            startDate.Clear();
            startDate.SendKeys(tomorrow.ToString("MMddyyyy"));

            state = driver.FindElement(By.XPath("//input[contains(@id, 'PropertyState')]")).GetAttribute("value");

            driver.FindElement(By.Id("submitButton")).Click();


 
        }

    }
}

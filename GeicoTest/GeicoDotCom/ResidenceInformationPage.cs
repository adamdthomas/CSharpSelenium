using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoTest.GeicoDotCom
{
    public class ResidenceInformationPage
    {
        IWebDriver driver;
        public string city;
        public string state;
        public string zip;
        public string address;

        public ResidenceInformationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GetAddress()
        {
            string fullAdress = driver.FindElement(By.Id("QuoteForAddress")).Text;
            string[] addressParts = fullAdress.Split(',');

            //15705 MAHOGANY CIR, GAITHERSBURG, MD, 20878
            address = addressParts[0].Trim();
            city = addressParts[1].Trim();
            state = addressParts[2].Trim();
            zip = addressParts[3].Trim();
        }
    }
}

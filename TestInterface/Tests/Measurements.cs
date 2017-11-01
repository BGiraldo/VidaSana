using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterface.Tests
{
    public class Measurements
    {
        public Measurements() { }

        public void Create(string personDocumentId = null)
        {
            IWebDriver driver = new ChromeDriver("C:\\Driver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:56447");

            IWebElement linkMedicos = driver.FindElement(By.LinkText("Measurements"));
            linkMedicos.Click();
            IWebElement linkCreate = driver.FindElement(By.LinkText("Create New"));
            linkCreate.Click();

            var person = driver.FindElement(By.Id("Personid"));
            var selectElement = new SelectElement(person);

            System.Threading.Thread.Sleep(5000);
            if(personDocumentId == null)
            {
                selectElement.SelectByText("11111111");
            } else
            {
                selectElement.SelectByText(personDocumentId);
            }

            IWebElement bodyFat = driver.FindElement(By.Id("bodyFat"));
            IWebElement date = driver.FindElement(By.Id("date"));
            IWebElement heartRate = driver.FindElement(By.Id("heartRate"));
            IWebElement height = driver.FindElement(By.Id("height"));

            IWebElement weight = driver.FindElement(By.Id("weight"));
            IWebElement button = driver.FindElement(By.Id("createMeasurement"));


            bodyFat.SendKeys("10");
            weight.SendKeys("10");
            date.SendKeys("12/12/12");
            heartRate.SendKeys("10");
            height.SendKeys("10");
            button.Click();
            System.Threading.Thread.Sleep(10000);
            driver.Close();
        }
    }
}

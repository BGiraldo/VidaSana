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
    public class PeopleCreate
    {

        public PeopleCreate() { }

        public string Create()
        {
            IWebDriver driver = new ChromeDriver("C:\\Driver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:56447");

            IWebElement linkMedicos = driver.FindElement(By.LinkText("People"));
            linkMedicos.Click();
            IWebElement linkCreate = driver.FindElement(By.LinkText("Create New"));
            linkCreate.Click();

            IWebElement address = driver.FindElement(By.Id("address"));
            IWebElement age = driver.FindElement(By.Id("age"));
            IWebElement document = driver.FindElement(By.Id("documentId"));
            IWebElement email = driver.FindElement(By.Id("email"));
            var gym = driver.FindElement(By.Id("gymid"));
            var selectElement = new SelectElement(gym);

            System.Threading.Thread.Sleep(5000);

            selectElement.SelectByText("Matagym");

            IWebElement lastname = driver.FindElement(By.Id("lastname"));
            IWebElement name = driver.FindElement(By.Id("name"));
            IWebElement phone = driver.FindElement(By.Id("phone"));
            IWebElement button = driver.FindElement(By.Id("createPerson"));


            address.SendKeys("direccion de prueba");
            name.SendKeys("nombre de prueba");
            lastname.SendKeys("apellido de prueba");
            age.SendKeys("18");
            Random rnd = new Random();
            int random = rnd.Next(1, 999999999);
            string documentid = random.ToString();
            document.SendKeys(documentid);
            email.SendKeys("prueba@hotmail.com");
            phone.SendKeys("010101010");
            button.Click();

            System.Threading.Thread.Sleep(10000);
            driver.Close();
            return documentid;
        }

    }
}

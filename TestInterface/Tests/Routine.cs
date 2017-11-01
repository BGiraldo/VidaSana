using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterface.Tests
{
    public class Routine
    {
        public Routine() { }

        public void Create()
        {
            IWebDriver driver = new ChromeDriver("C:\\Driver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:56447");

            IWebElement linkMedicos = driver.FindElement(By.LinkText("Routines"));
            linkMedicos.Click();
            IWebElement linkCreate = driver.FindElement(By.LinkText("Create New"));
            linkCreate.Click();

            IWebElement description = driver.FindElement(By.Id("description"));
            IWebElement name = driver.FindElement(By.Id("name"));
            IWebElement typeRoutine = driver.FindElement(By.Id("typeRoutine"));
            IWebElement kindOfRoutine = driver.FindElement(By.Id("kindOfRoutine"));
            IWebElement button = driver.FindElement(By.Id("createRoutine"));


            description.SendKeys("descripcion de prueba");
            name.SendKeys("nombre de prueba");
            typeRoutine.SendKeys("Cardio");
            kindOfRoutine.SendKeys("Ejercicio");
            button.Click();
            System.Threading.Thread.Sleep(10000);
            driver.Close();
        }
    }
}

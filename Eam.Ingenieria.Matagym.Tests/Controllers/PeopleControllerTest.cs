using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eam.Ingenieria.Matagym.Controllers;
using Eam.Ingenieria.Matagym.Models;
using System.Web.Mvc;

namespace Eam.Ingenieria.Matagym.Tests.Controllers
{
    /// <summary>
    /// Summary description for PeopleControllerTest
    /// </summary>
    [TestClass]
    public class PeopleControllerTest
    {

        private PeopleController controller;

        public PeopleControllerTest()
        {
            controller = new PeopleController();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Create()
        {
            Person person = new Person();
            person.address = "prueba";
            person.age = 1;
            person.documentId = 01234;
            person.email = "prueba";
            person.lastname = "prueba";
            person.name = "prubate";
            person.phone = "123456789";
            controller.Create(person);
            //ViewResult result = controller.Create(person).Result as ViewResult;

            //Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            Person person = new Person();
            person.address = "prueba";
            person.age = 1;
            person.documentId = 01234;
            person.email = "editado";
            person.lastname = "editado";
            person.name = "editado";
            person.phone = "123456789";
            controller.Edit(person);
        }

        [TestMethod]
        public void Delete()
        {
            Person person = new Person();
            person.documentId = 01234;
            controller.DeleteConfirmed(person.documentId);
        }
    }
}

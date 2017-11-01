using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eam.Ingenieria.Matagym.Controllers;

namespace Eam.Ingenieria.Matagym.Tests.Controllers
{
    /// <summary>
    /// Summary description for MeasurementsControllerTest
    /// </summary>
    [TestClass]
    public class MeasurementsControllerTest
    {

        private MeasurementsController controller;

        public MeasurementsControllerTest()
        {
            controller = new MeasurementsController();   
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
            Measurement m = new Measurement();
            m.bodyFat = 0;
            m.date = new DateTime();
            m.heartRate = 0;
            m.height = 0;
            m.weight = 0;

            Person p = new Person();
            p.documentId = 11111;

            PeopleController peopleController = new PeopleController();
            peopleController.Create(p);

            m.Person = p;

            controller.Create(m);
        }

        [TestMethod]
        public void Edit()
        {
            Measurement m = new Measurement();
            m.bodyFat = 1;
            m.date = new DateTime();
            m.heartRate = 1;
            m.height = 1;
            m.weight = 1;

            controller.Edit(m);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eam.Ingenieria.Matagym.Controllers;

namespace Eam.Ingenieria.Matagym.Tests.Controllers
{
    /// <summary>
    /// Summary description for RoutineControllerTest
    /// </summary>
    [TestClass]
    public class RoutineControllerTest
    {

        private RoutinesController controller;

        public RoutineControllerTest()
        {
            controller = new RoutinesController();
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
            Routine r = new Routine();
            r.description = "descripcion de prueba";
            r.kindOfRoutine = "kind";
            r.name = "name";
            r.typeRoutine = "type";

            controller.Create(r);
        }

        [TestMethod]
        public void Edit()
        {
            Routine r = new Routine();
            r.description = "descripcion de prueba editado";
            r.kindOfRoutine = "kind editado";
            r.name = "name editado";
            r.typeRoutine = "type editado";

            controller.Edit(r);
        }
        }
}

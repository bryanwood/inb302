using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using System.Linq;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for EventServiceTest and is intended
    ///to contain all EventServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EventServiceTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for EventService Constructor
        ///</summary>
        [TestMethod()]
        public void EventServiceConstructorTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            EventService target = new EventService(unitOfWork);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddFileAccessEvent
        ///</summary>
        [TestMethod()]
        public void AddFileAccessEventTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            EventService target = new EventService(unitOfWork); // TODO: Initialize to an appropriate value
            File file = null; // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            target.AddFileAccessEvent(file, user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddTransmittalEvent
        ///</summary>
        [TestMethod()]
        public void AddTransmittalEventTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            EventService target = new EventService(unitOfWork); // TODO: Initialize to an appropriate value
            Transmittal transmittal = null; // TODO: Initialize to an appropriate value
            target.AddTransmittalEvent(transmittal);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddUserEvent
        ///</summary>
        [TestMethod()]
        public void AddUserEventTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            EventService target = new EventService(unitOfWork); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            target.AddUserEvent(user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetEvent
        ///</summary>
        [TestMethod()]
        public void GetEventTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            EventService target = new EventService(unitOfWork); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Event expected = null; // TODO: Initialize to an appropriate value
            Event actual;
            actual = target.GetEvent(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEventsByFile
        ///</summary>
        [TestMethod()]
        public void GetEventsByFileTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            EventService target = new EventService(unitOfWork); // TODO: Initialize to an appropriate value
            File file = null; // TODO: Initialize to an appropriate value
            IQueryable<Event> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<Event> actual;
            actual = target.GetEventsByFile(file);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEventsByTransmittal
        ///</summary>
        [TestMethod()]
        public void GetEventsByTransmittalTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            EventService target = new EventService(unitOfWork); // TODO: Initialize to an appropriate value
            Transmittal transmittal = null; // TODO: Initialize to an appropriate value
            IQueryable<Event> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<Event> actual;
            actual = target.GetEventsByTransmittal(transmittal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEventsByUser
        ///</summary>
        [TestMethod()]
        public void GetEventsByUserTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            EventService target = new EventService(unitOfWork); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            IQueryable<Event> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<Event> actual;
            actual = target.GetEventsByUser(user);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

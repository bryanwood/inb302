using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using System.Linq;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for TransmittalServiceTest and is intended
    ///to contain all TransmittalServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TransmittalServiceTest
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
        ///A test for TransmittalService Constructor
        ///</summary>
        [TestMethod()]
        public void TransmittalServiceConstructorTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            TransmittalService target = new TransmittalService(unitOfWork);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddRestriction
        ///</summary>
        [TestMethod()]
        public void AddRestrictionTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            TransmittalService target = new TransmittalService(unitOfWork); // TODO: Initialize to an appropriate value
            Transmittal transmittal = null; // TODO: Initialize to an appropriate value
            Restriction restriction = null; // TODO: Initialize to an appropriate value
            Transmittal expected = null; // TODO: Initialize to an appropriate value
            Transmittal actual;
            actual = target.AddRestriction(transmittal, restriction);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateNewTransmittal
        ///</summary>
        [TestMethod()]
        public void CreateNewTransmittalTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            TransmittalService target = new TransmittalService(unitOfWork); // TODO: Initialize to an appropriate value
            Transmittal t = null; // TODO: Initialize to an appropriate value
            target.CreateNewTransmittal(t);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetTransmittalById
        ///</summary>
        [TestMethod()]
        public void GetTransmittalByIdTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            TransmittalService target = new TransmittalService(unitOfWork); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Transmittal expected = null; // TODO: Initialize to an appropriate value
            Transmittal actual;
            actual = target.GetTransmittalById(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTransmittalsByRecipient
        ///</summary>
        [TestMethod()]
        public void GetTransmittalsByRecipientTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            TransmittalService target = new TransmittalService(unitOfWork); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            IQueryable<Transmittal> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<Transmittal> actual;
            actual = target.GetTransmittalsByRecipient(user);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTransmittalsBySender
        ///</summary>
        [TestMethod()]
        public void GetTransmittalsBySenderTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            TransmittalService target = new TransmittalService(unitOfWork); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            IQueryable<Transmittal> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<Transmittal> actual;
            actual = target.GetTransmittalsBySender(user);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

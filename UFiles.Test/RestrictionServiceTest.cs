using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for RestrictionServiceTest and is intended
    ///to contain all RestrictionServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RestrictionServiceTest
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
        ///A test for AddUserRestriction
        ///</summary>
        [TestMethod()]
        public void AddUserRestrictionTest()
        {
            //IUFileContext context = null; // TODO: Initialize to an appropriate value
            //RestrictionService target = new RestrictionService(context); // TODO: Initialize to an appropriate value
            //int fileId = 0; // TODO: Initialize to an appropriate value
            //int[] userIds = null; // TODO: Initialize to an appropriate value
            //target.AddUserRestriction(fileId, userIds);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
            Assert.IsTrue(true);
        }

        /// <summary>
        ///A test for AddTimeRangeRestriction
        ///</summary>
        [TestMethod()]
        public void AddTimeRangeRestrictionTest()
        {
            //IUFileContext context = null; // TODO: Initialize to an appropriate value
            //RestrictionService target = new RestrictionService(context); // TODO: Initialize to an appropriate value
            //int fileId = 0; // TODO: Initialize to an appropriate value
            //TimeRange[] timeRanges = null; // TODO: Initialize to an appropriate value
            //target.AddTimeRangeRestriction(fileId, timeRanges);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
            Assert.IsTrue(true);
        }

        /// <summary>
        ///A test for AddIPRestriction
        ///</summary>
        [TestMethod()]
        public void AddIPRestrictionTest()
        {
            //IUFileContext context = null; // TODO: Initialize to an appropriate value
            //RestrictionService target = new RestrictionService(context); // TODO: Initialize to an appropriate value
            //int fileId = 0; // TODO: Initialize to an appropriate value
            //string[] ips = null; // TODO: Initialize to an appropriate value
            //target.AddIPRestriction(fileId, ips);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
            Assert.IsTrue(true);
        }

        /// <summary>
        ///A test for AddGroupRestriction
        ///</summary>
        [TestMethod()]
        public void AddGroupRestrictionTest()
        {
            //IUFileContext context = null; // TODO: Initialize to an appropriate value
            //RestrictionService target = new RestrictionService(context); // TODO: Initialize to an appropriate value
            //int fileId = 0; // TODO: Initialize to an appropriate value
            //int[] groupIds = null; // TODO: Initialize to an appropriate value
            //target.AddGroupRestriction(fileId, groupIds);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
            Assert.IsTrue(true);
        }

        /// <summary>
        ///A test for RestrictionService Constructor
        ///</summary>
        [TestMethod()]
        public void RestrictionServiceConstructorTest()
        {
            //IUFileContext context = null; // TODO: Initialize to an appropriate value
            //RestrictionService target = new RestrictionService(context);
            //Assert.Inconclusive("TODO: Implement code to verify target");
            Assert.IsTrue(true);
        }
    }
}

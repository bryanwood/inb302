using UFiles.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using UFiles.Domain.Abstract;
using System.Collections.Generic;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for OverviewModelTest and is intended
    ///to contain all OverviewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OverviewModelTest
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
        ///A test for OverviewModel Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void OverviewModelConstructorTest()
        {
            IUserService userService = null; // TODO: Initialize to an appropriate value
            IFileService fileService = null; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string ipAddress = string.Empty; // TODO: Initialize to an appropriate value
            OverviewModel target = new OverviewModel(userService, fileService, email, ipAddress);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for RecentlyReceivedTransmittals
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void RecentlyReceivedTransmittalsTest()
        {
            IUserService userService = null; // TODO: Initialize to an appropriate value
            IFileService fileService = null; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string ipAddress = string.Empty; // TODO: Initialize to an appropriate value
            OverviewModel target = new OverviewModel(userService, fileService, email, ipAddress); // TODO: Initialize to an appropriate value
            List<TransmittalListingModel> expected = null; // TODO: Initialize to an appropriate value
            List<TransmittalListingModel> actual;
            target.RecentlyReceivedTransmittals = expected;
            actual = target.RecentlyReceivedTransmittals;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RecentlySentTransmittals
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void RecentlySentTransmittalsTest()
        {
            IUserService userService = null; // TODO: Initialize to an appropriate value
            IFileService fileService = null; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string ipAddress = string.Empty; // TODO: Initialize to an appropriate value
            OverviewModel target = new OverviewModel(userService, fileService, email, ipAddress); // TODO: Initialize to an appropriate value
            List<TransmittalListingModel> expected = null; // TODO: Initialize to an appropriate value
            List<TransmittalListingModel> actual;
            target.RecentlySentTransmittals = expected;
            actual = target.RecentlySentTransmittals;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RestrictionClassList
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void RestrictionClassListTest()
        {
            IUserService userService = null; // TODO: Initialize to an appropriate value
            IFileService fileService = null; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string ipAddress = string.Empty; // TODO: Initialize to an appropriate value
            OverviewModel target = new OverviewModel(userService, fileService, email, ipAddress); // TODO: Initialize to an appropriate value
            List<Type> expected = null; // TODO: Initialize to an appropriate value
            List<Type> actual;
            target.RestrictionClassList = expected;
            actual = target.RestrictionClassList;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for preloadedOverview
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void preloadedOverviewTest()
        {
            IUserService userService = null; // TODO: Initialize to an appropriate value
            IFileService fileService = null; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string ipAddress = string.Empty; // TODO: Initialize to an appropriate value
            OverviewModel target = new OverviewModel(userService, fileService, email, ipAddress); // TODO: Initialize to an appropriate value
            TransmittalOverviewModel expected = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel actual;
            target.preloadedOverview = expected;
            actual = target.preloadedOverview;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

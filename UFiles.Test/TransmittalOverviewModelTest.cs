using UFiles.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using UFiles.Domain.Entities;
using System.Collections.Generic;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for TransmittalOverviewModelTest and is intended
    ///to contain all TransmittalOverviewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TransmittalOverviewModelTest
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
        ///A test for TransmittalOverviewModel Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void TransmittalOverviewModelConstructorTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DownloadLink
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void DownloadLinkTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.DownloadLink = expected;
            actual = target.DownloadLink;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FileName
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void FileNameTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.FileName = expected;
            actual = target.FileName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupRestrictions
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void GroupRestrictionsTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            List<GroupRestriction> expected = null; // TODO: Initialize to an appropriate value
            List<GroupRestriction> actual;
            target.GroupRestrictions = expected;
            actual = target.GroupRestrictions;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IPRestrictions
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void IPRestrictionsTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            List<IPRestriction> expected = null; // TODO: Initialize to an appropriate value
            List<IPRestriction> actual;
            target.IPRestrictions = expected;
            actual = target.IPRestrictions;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LocationRestrictions
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void LocationRestrictionsTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            List<LocationRestriction> expected = null; // TODO: Initialize to an appropriate value
            List<LocationRestriction> actual;
            target.LocationRestrictions = expected;
            actual = target.LocationRestrictions;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Sender
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void SenderTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Sender = expected;
            actual = target.Sender;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SentDate
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void SentDateTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.SentDate = expected;
            actual = target.SentDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TimeRangeRestrictions
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void TimeRangeRestrictionsTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            List<TimeRangeRestriction> expected = null; // TODO: Initialize to an appropriate value
            List<TimeRangeRestriction> actual;
            target.TimeRangeRestrictions = expected;
            actual = target.TimeRangeRestrictions;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserRestrictions
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void UserRestrictionsTest()
        {
            Transmittal t = null; // TODO: Initialize to an appropriate value
            TransmittalOverviewModel target = new TransmittalOverviewModel(t); // TODO: Initialize to an appropriate value
            List<UserRestriction> expected = null; // TODO: Initialize to an appropriate value
            List<UserRestriction> actual;
            target.UserRestrictions = expected;
            actual = target.UserRestrictions;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

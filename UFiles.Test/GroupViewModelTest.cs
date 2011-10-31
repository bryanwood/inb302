﻿using UFiles.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using UFiles.Domain.Abstract;
using System.Collections.Generic;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for GroupViewModelTest and is intended
    ///to contain all GroupViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GroupViewModelTest
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
        ///A test for GroupViewModel Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void GroupViewModelConstructorTest()
        {
            IUserService userService = null; // TODO: Initialize to an appropriate value
            IGroupService groupService = null; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            GroupViewModel target = new GroupViewModel(userService, groupService, email);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for groupList
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void groupListTest()
        {
            IUserService userService = null; // TODO: Initialize to an appropriate value
            IGroupService groupService = null; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            GroupViewModel target = new GroupViewModel(userService, groupService, email); // TODO: Initialize to an appropriate value
            List<GroupListingModel> expected = null; // TODO: Initialize to an appropriate value
            List<GroupListingModel> actual;
            target.groupList = expected;
            actual = target.groupList;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

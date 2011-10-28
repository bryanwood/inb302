using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using System.Linq;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for GroupServiceTest and is intended
    ///to contain all GroupServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GroupServiceTest
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
        ///A test for GroupService Constructor
        ///</summary>
        [TestMethod()]
        public void GroupServiceConstructorTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            GroupService target = new GroupService(unitOfWork);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddMember
        ///</summary>
        [TestMethod()]
        public void AddMemberTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            GroupService target = new GroupService(unitOfWork); // TODO: Initialize to an appropriate value
            Group group = null; // TODO: Initialize to an appropriate value
            User member = null; // TODO: Initialize to an appropriate value
            target.AddMember(group, member);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateGroup
        ///</summary>
        [TestMethod()]
        public void CreateGroupTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            GroupService target = new GroupService(unitOfWork); // TODO: Initialize to an appropriate value
            User owner = null; // TODO: Initialize to an appropriate value
            Group group = null; // TODO: Initialize to an appropriate value
            target.CreateGroup(owner, group);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteGroup
        ///</summary>
        [TestMethod()]
        public void DeleteGroupTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            GroupService target = new GroupService(unitOfWork); // TODO: Initialize to an appropriate value
            Group group = null; // TODO: Initialize to an appropriate value
            target.DeleteGroup(group);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetGroup
        ///</summary>
        [TestMethod()]
        public void GetGroupTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            GroupService target = new GroupService(unitOfWork); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Group expected = null; // TODO: Initialize to an appropriate value
            Group actual;
            actual = target.GetGroup(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetGroupsByOwner
        ///</summary>
        [TestMethod()]
        public void GetGroupsByOwnerTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            GroupService target = new GroupService(unitOfWork); // TODO: Initialize to an appropriate value
            User owner = null; // TODO: Initialize to an appropriate value
            IQueryable<Group> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<Group> actual;
            actual = target.GetGroupsByOwner(owner);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveMember
        ///</summary>
        [TestMethod()]
        public void RemoveMemberTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            GroupService target = new GroupService(unitOfWork); // TODO: Initialize to an appropriate value
            Group group = null; // TODO: Initialize to an appropriate value
            User member = null; // TODO: Initialize to an appropriate value
            target.RemoveMember(group, member);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveGroup
        ///</summary>
        [TestMethod()]
        public void SaveGroupTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            GroupService target = new GroupService(unitOfWork); // TODO: Initialize to an appropriate value
            Group group = null; // TODO: Initialize to an appropriate value
            target.SaveGroup(group);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}

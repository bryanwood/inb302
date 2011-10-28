using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UFiles.Domain.Entities;
using UFiles.Domain.Abstract;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for UnitOfWorkTest and is intended
    ///to contain all UnitOfWorkTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UnitOfWorkTest
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
        ///A test for UnitOfWork Constructor
        ///</summary>
        [TestMethod()]
        public void UnitOfWorkConstructorTest()
        {
            IRepository<Event> eventRepository = null; // TODO: Initialize to an appropriate value
            IRepository<File> fileRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Group> groupRepository = null; // TODO: Initialize to an appropriate value
            IRepository<IPAddress> iPAddressRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Location> locationRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Restriction> restrictionRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Role> roleRepository = null; // TODO: Initialize to an appropriate value
            IRepository<TimeRange> timeRangeRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Transmittal> transmittalRepository = null; // TODO: Initialize to an appropriate value
            IRepository<User> userRepository = null; // TODO: Initialize to an appropriate value
            UnitOfWork target = new UnitOfWork(eventRepository, fileRepository, groupRepository, iPAddressRepository, locationRepository, restrictionRepository, roleRepository, timeRangeRepository, transmittalRepository, userRepository);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void DisposeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest1()
        {
            IRepository<Event> eventRepository = null; // TODO: Initialize to an appropriate value
            IRepository<File> fileRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Group> groupRepository = null; // TODO: Initialize to an appropriate value
            IRepository<IPAddress> iPAddressRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Location> locationRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Restriction> restrictionRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Role> roleRepository = null; // TODO: Initialize to an appropriate value
            IRepository<TimeRange> timeRangeRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Transmittal> transmittalRepository = null; // TODO: Initialize to an appropriate value
            IRepository<User> userRepository = null; // TODO: Initialize to an appropriate value
            UnitOfWork target = new UnitOfWork(eventRepository, fileRepository, groupRepository, iPAddressRepository, locationRepository, restrictionRepository, roleRepository, timeRangeRepository, transmittalRepository, userRepository); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            IRepository<Event> eventRepository = null; // TODO: Initialize to an appropriate value
            IRepository<File> fileRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Group> groupRepository = null; // TODO: Initialize to an appropriate value
            IRepository<IPAddress> iPAddressRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Location> locationRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Restriction> restrictionRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Role> roleRepository = null; // TODO: Initialize to an appropriate value
            IRepository<TimeRange> timeRangeRepository = null; // TODO: Initialize to an appropriate value
            IRepository<Transmittal> transmittalRepository = null; // TODO: Initialize to an appropriate value
            IRepository<User> userRepository = null; // TODO: Initialize to an appropriate value
            UnitOfWork target = new UnitOfWork(eventRepository, fileRepository, groupRepository, iPAddressRepository, locationRepository, restrictionRepository, roleRepository, timeRangeRepository, transmittalRepository, userRepository); // TODO: Initialize to an appropriate value
            target.Save();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EventRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void EventRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<Event> expected = null; // TODO: Initialize to an appropriate value
            IRepository<Event> actual;
            target.EventRepository = expected;
            actual = target.EventRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FileRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void FileRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<File> expected = null; // TODO: Initialize to an appropriate value
            IRepository<File> actual;
            target.FileRepository = expected;
            actual = target.FileRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GroupRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void GroupRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<Group> expected = null; // TODO: Initialize to an appropriate value
            IRepository<Group> actual;
            target.GroupRepository = expected;
            actual = target.GroupRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IPAddressRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void IPAddressRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<IPAddress> expected = null; // TODO: Initialize to an appropriate value
            IRepository<IPAddress> actual;
            target.IPAddressRepository = expected;
            actual = target.IPAddressRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LocationRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void LocationRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<Location> expected = null; // TODO: Initialize to an appropriate value
            IRepository<Location> actual;
            target.LocationRepository = expected;
            actual = target.LocationRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RestrictionRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void RestrictionRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<Restriction> expected = null; // TODO: Initialize to an appropriate value
            IRepository<Restriction> actual;
            target.RestrictionRepository = expected;
            actual = target.RestrictionRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RoleRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void RoleRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<Role> expected = null; // TODO: Initialize to an appropriate value
            IRepository<Role> actual;
            target.RoleRepository = expected;
            actual = target.RoleRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TimeRangeRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void TimeRangeRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<TimeRange> expected = null; // TODO: Initialize to an appropriate value
            IRepository<TimeRange> actual;
            target.TimeRangeRepository = expected;
            actual = target.TimeRangeRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TransmittalRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void TransmittalRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<Transmittal> expected = null; // TODO: Initialize to an appropriate value
            IRepository<Transmittal> actual;
            target.TransmittalRepository = expected;
            actual = target.TransmittalRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UserRepository
        ///</summary>
        [TestMethod()]
        [DeploymentItem("UFiles.Domain.dll")]
        public void UserRepositoryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            UnitOfWork_Accessor target = new UnitOfWork_Accessor(param0); // TODO: Initialize to an appropriate value
            IRepository<User> expected = null; // TODO: Initialize to an appropriate value
            IRepository<User> actual;
            target.UserRepository = expected;
            actual = target.UserRepository;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for RepositoryTest and is intended
    ///to contain all RepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RepositoryTest
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
        ///A test for Repository`1 Constructor
        ///</summary>
        public void RepositoryConstructorTestHelper<T>()
            where T : class
        {
            UFileContext context = null; // TODO: Initialize to an appropriate value
            Repository<T> target = new Repository<T>(context);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void RepositoryConstructorTest()
        {
            RepositoryConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTestHelper<T>()
            where T : class
        {
            UFileContext context = null; // TODO: Initialize to an appropriate value
            Repository<T> target = new Repository<T>(context); // TODO: Initialize to an appropriate value
            T entity = null; // TODO: Initialize to an appropriate value
            target.Add(entity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for All
        ///</summary>
        public void AllTestHelper<T>()
            where T : class
        {
            UFileContext context = null; // TODO: Initialize to an appropriate value
            Repository<T> target = new Repository<T>(context); // TODO: Initialize to an appropriate value
            IQueryable<T> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<T> actual;
            actual = target.All();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void AllTest()
        {
            AllTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        public void DeleteTestHelper<T>()
            where T : class
        {
            UFileContext context = null; // TODO: Initialize to an appropriate value
            Repository<T> target = new Repository<T>(context); // TODO: Initialize to an appropriate value
            T entity = null; // TODO: Initialize to an appropriate value
            target.Delete(entity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            DeleteTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        public void UpdateTestHelper<T>()
            where T : class
        {
            UFileContext context = null; // TODO: Initialize to an appropriate value
            Repository<T> target = new Repository<T>(context); // TODO: Initialize to an appropriate value
            T entity = null; // TODO: Initialize to an appropriate value
            target.Update(entity);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void UpdateTest()
        {
            UpdateTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Where
        ///</summary>
        public void WhereTestHelper<T>()
            where T : class
        {
            UFileContext context = null; // TODO: Initialize to an appropriate value
            Repository<T> target = new Repository<T>(context); // TODO: Initialize to an appropriate value
            Expression<Func<T, bool>> expression = null; // TODO: Initialize to an appropriate value
            IQueryable<T> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<T> actual;
            actual = target.Where(expression);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void WhereTest()
        {
            WhereTestHelper<GenericParameterHelper>();
        }
    }
}

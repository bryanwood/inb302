using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for EmailServiceTest and is intended
    ///to contain all EmailServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmailServiceTest
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
        ///A test for EmailService Constructor
        ///</summary>
        [TestMethod()]
        public void EmailServiceConstructorTest()
        {
            EmailService target = new EmailService();
            Assert.IsInstanceOfType(target, typeof(EmailService));
        }

        /// <summary>
        ///A test for SendEmail
        ///</summary>
        [TestMethod()]
        public void SendEmailTest()
        {
            foreach (var file in Directory.GetFiles("C:\\emails"))
            {
                File.Delete(file);
            }
            EmailService target = new EmailService();
            string[] recipients = new string[]{"test@example.com"}; 
            string message = "email message body";
            target.SendEmail(recipients, message);
     
            Assert.IsTrue(Directory.GetFiles("C:\\emails").Length > 0);
        }
    }
}

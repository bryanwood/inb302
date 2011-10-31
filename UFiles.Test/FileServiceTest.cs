using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UFiles.Domain.Abstract;
using System.Data.Entity;
using System.Linq;
using UFiles.Domain.Entities;
using System.Collections.Generic;

namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for FileServiceTest and is intended
    ///to contain all FileServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FileServiceTest
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
        ///A test for FileService Constructor
        ///</summary>
        [TestMethod()]
        public void FileServiceConstructorTest()
        {
            IUFileContext context = null; // TODO: Initialize to an appropriate value
            IEventService eventService = null;
            FileService target = new FileService(context, eventService);
            Assert.IsInstanceOfType(target, typeof(FileService));
        }

        /// <summary>
        ///A test for CreateFile
        ///</summary>
        [TestMethod()]
        public void CreateFileTest()
        {

            IUFileContext context = new UFileContext(); // TODO: Initialize to an appropriate value
            IEventService eventService = null;
            FileService target = new FileService(context, eventService);
            File file = new File
            {
                ContentType = "image/jpg",
                DateCreated = DateTime.Now,
                FileData = new byte[1]{0xFF},
                Name = "CreateFile.Test",
                Owner = context.Users.First(),
                Revoked = false,
                Size = 1
            }; // TODO: Initialize to an appropriate value
            target.CreateFile(file);
            var file2 = target.GetFileById(file.FileId);
            Assert.AreEqual(file, file2);
        }

        /// <summary>
        ///A test for GetFileById
        ///</summary>
        [TestMethod()]
        public void GetFileByIdTest()
        {
            IUFileContext context = new UFileContext(); // TODO: Initialize to an appropriate value
            IEventService eventService = null;
            FileService target = new FileService(context, eventService);

            var file = new File
            {
                DateCreated = DateTime.Now,
                Name = "RevokeFile.Test",
                Owner = context.Users.First(),
                Size = 1,
                FileData = new byte[1] { 0xFF },
                ContentType = "image/test",
                Revoked = false
            };
            context.Files.Add(file);
            context.SaveChanges();
            int id = file.FileId; // TODO: Initialize to an appropriate value
            File expected = file; // TODO: Initialize to an appropriate value
            File actual;
            actual = target.GetFileById(id);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RevokeFile
        ///</summary>
        [TestMethod()]
        public void RevokeFileTest()
        {
            IUFileContext context = new UFileContext(); // TODO: Initialize to an appropriate value
            IEventService eventService = null;
            FileService target = new FileService(context, eventService);
            var file = new File
            {
                DateCreated = DateTime.Now,
                Name = "RevokeFile.Test",
                Owner = context.Users.First(),
                Size = 1,
                FileData = new byte[1]{0xFF},
                ContentType = "image/test",
                Revoked = false
            };
            context.Files.Add(file);
            context.SaveChanges();
            int id = file.FileId; // TODO: Initialize to an appropriate value
            target.RevokeFile(id);
            Assert.AreEqual(file.Revoked, true);
        }

        /// <summary>
        ///A test for UserCanAccessFile
        ///</summary>
        [TestMethod()]
        public void UserCanAccessFileTest()
        {
            IUFileContext context = new UFileContext(); // TODO: Initialize to an appropriate value
            IEventService eventService = null;
            FileService target = new FileService(context, eventService);
            var user = context.Users.First();
            var user2 = context.Users.Where(u=>u.UserId!=user.UserId).First();

            var file = new File
            {
                DateCreated = DateTime.Now,
                Name = "RevokeFile.Test",
                Owner = user,
                Size = 1,
                FileData = new byte[1] { 0xFF },
                ContentType = "image/test",
                Revoked = false,
                Restrictions = new List<Restriction>{new UserRestriction{
                    Users = new List<User>{user2}
                }
                }
            };
            context.Files.Add(file);
            context.SaveChanges();
            int id = file.FileId; // TODO: Initialize to an appropriate value

            int userId = user2.UserId; // TODO: Initialize to an appropriate value
            int locationId = 0; // TODO: Initialize to an appropriate value
            string iPAddress = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UserCanAccessFile(id, userId, locationId, iPAddress);
            Assert.AreEqual(expected, actual);

            
        }
    }
}

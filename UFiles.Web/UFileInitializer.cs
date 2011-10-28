using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UFiles.Domain.Concrete;

namespace UFiles.Domain.Entities
{
    public class UFileInitializer : DropCreateDatabaseIfModelChanges<UFileContext>
    {
        protected override void Seed(UFileContext context)
        {
            var standardRole = new Role
            {
                Name = "Standard"
            };

            var adminRole = new Role
            {
                Name = "Administrator"
            };

            
            #region Users
            var user1 = new User
            {
                Role=adminRole,
                FirstName = "Mitchell",
                LastName = "Peason",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "mitch@mpears.com.au",
                Verified = true

            };
            var user2 = new User
            {
                Role=standardRole,
                FirstName = "Bryan",
                LastName = "Wood",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "bryan@bryanwood.com.au",
                Verified = true
            };
            var user3 = new User
            {
                Role = standardRole,
                FirstName = "Dylan",
                LastName = "Toohey",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "dj.toohey@connect.qut.edu.au",
                Verified = true
            };
            var user4 = new User
            {
                Role = standardRole,
                FirstName = "Carl",
                LastName = "Francia",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "cf.nachos@gmail.com",
                Verified = true
            };
            var user5 = new User
            {
                Role = standardRole,
                FirstName = "Daniel",
                LastName = "Smith",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "xxobot@gmail.com",
                Verified = true
            };
            var user6 = new User
            {
                Role = standardRole,
                FirstName = "Bob",
                LastName = "Hawke",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "birdsarebig@gmail.com",
                Verified = true
            };
            var user7 = new User
            {
                Role = standardRole,
                FirstName = "John",
                LastName = "Howard",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "onlyif@live.com",
                Verified = true
            };
            var user8 = new User
            {
                Role = standardRole,
                FirstName = "Paul",
                LastName = "Keating",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "i_love_peter_pan@hotmail.com",
                Verified = true
            };
            var user9 = new User
            {
                Role = standardRole,
                FirstName = "Julia",
                LastName = "Gillard",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "birdsandbees@hotmail.com",
                Verified = true
            };
            var user10 = new User
            {
                Role = standardRole,
                FirstName = "Nick",
                LastName = "Xenaphon",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "love@yahoo.com",
                Verified = true
            };
            var user11 = new User
            {
                Role = standardRole,
                FirstName = "Angelina",
                LastName = "Morrison",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "peoplebelieveinaliens@hotmail.com",
                Verified = true
            };
            var user12 = new User
            {
                Role = standardRole,
                FirstName = "Pat",
                LastName = "Postman",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "pigscanprobablyfly@gmail.com",
                Verified = true
            };
            var user13 = new User
            {
                Role = standardRole,
                FirstName = "James",
                LastName = "Downing",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "bumblebee3@yahoo.com",
                Verified = true
            };
            var user14 = new User
            {
                Role = standardRole,
                FirstName = "Michael",
                LastName = "Jagger",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "cool_dude1992@hotmail.com",
                Verified = true
            };
            var user15 = new User
            {
                Role = standardRole,
                FirstName = "Rob",
                LastName = "McDonald",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "happymeals@gmail.com",
                Verified = true
            };
            var user16 = new User
            {
                Role = standardRole,
                FirstName = "Doctor",
                LastName = "Evil",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "sharksgot2laserz@live.com",
                Verified = true
            };
            var user17 = new User
            {
                Role = standardRole,
                FirstName = "Michael",
                LastName = "Arrington",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "blogging4fun@msn.com",
                Verified = true
            };
            var user18 = new User
            {
                Role = standardRole,
                FirstName = "Daniel",
                LastName = "Freeman",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "black.guy.on.plane@gmail.com",
                Verified = true
            };
            var user19 = new User
            {
                Role = standardRole,
                FirstName = "Smith",
                LastName = "Doe",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "random_dude2@gmail.com",
                Verified = true
            };
            var user20 = new User
            {
                Role = standardRole,
                FirstName = "Roger",
                LastName = "Moore",
                PasswordHash = "password",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "bond@gmail.com",
                Verified = true
            };
            #endregion

            #region Groups
            var group = new Group
            {
                Name = "Students",
                Owner = user1,
                Users = new List<User> { user1, user2 },
            };
            var group2 = new Group
            {
                Name = "Staff",
                Owner = user2,
                Users = new List<User> { user1, user2, user16, user17, user18, user19 },
            };
            var group3 = new Group
            {
                Name = "Share",
                Owner = user1,
                Users = new List<User> { user4, user5, user6, user10, user11 },
            };
            var group4 = new Group
            {
                Name = "Sys Admins",
                Owner = user2,
                Users = new List<User> { user1, user2 },
            };
            #endregion

            #region IPs
            var ip1 = new IPAddress
            {
                IP = "203.143.13.11",
            };
            var ip2 = new IPAddress
            {
                IP = "4.4.4.4"
            };
            var ip3 = new IPAddress
            {
                IP = "72.46.16.55",
            };
            #endregion

            #region Files
            var file1 = new File
            {
                Name = "Random",
                DateCreated = new DateTime(2010, 01, 30, 10, 25, 0),
                Owner = user1,
                ContentType = "image/png",
                Size = 2048,
                FileData = new byte[1] { 0xFF },
                Revoked = false,
                Restrictions = new List<Restriction>{new GroupRestriction{
                Groups = new List<Group>{group,group2}
                },
                new IPRestriction{
                    IPAddress = new List<IPAddress>{ip1}
                }
                },
                FileAccessEvents = new List<FileAccessEvent> {

                }
            };

            file1.FileAccessEvents.Add(new FileAccessEvent
            {
                User = user1,
                File = file1,
                Occurred = DateTime.Now,
            });

            file1.FileAccessEvents.Add(new FileAccessEvent{
                Occurred = DateTime.Now.AddHours(-2),
                File = file1,
                User = user2
            });
            var file2 = new File
            {
                Name = "Video Title With Space",
                DateCreated = new DateTime(2009, 06, 02, 5, 50, 0),
                Owner = user1,
                ContentType = "image/png",
                Size = 2048,
                FileData = new byte[1] { 0xFF },
                Revoked = false,
            };

            var file3 = new File
            {
                Name = "Picture",
                DateCreated = new DateTime(2011, 01, 22, 15, 52, 0),
                Owner = user1,
                ContentType = "image/png",
                Size = 2048,
                FileData = new byte[1] { 0xFF },
                Revoked = false,
            };

            var file4 = new File
            {
                Name = "Document",
                DateCreated = new DateTime(2009, 09, 22, 5, 50, 0),
                Owner = user1,
                ContentType = "image/png",
                Size = 2048,
                FileData = new byte[1] { 0xFF },
                Revoked = false,
            };
            var file5 = new File
            {
                Name = "Report",
                DateCreated = new DateTime(2010, 05, 13, 9, 55, 0),
                Owner = user2,
                ContentType = "image/png",
                Size = 2048,
                FileData = new byte[1] { 0xFF },
                Revoked = false,
            };
            #endregion

          
           


          

            var file = new File
            {
              
                Name = "File Name",
                Owner = user1,
                DateCreated = DateTime.Now,
                Revoked = false,
                ContentType = "image/png",
                Size = 2048,
                FileData = new byte[1]{0xFF},
            };

            var transmittal = new Transmittal
            {
                Files = new List<File>
                {
                    file,
                },
                Recipients = new List<User>
                {
                    user2,
                },
                Sender = user1,
            };
            
            context.Roles.Add(standardRole);
            context.Roles.Add(adminRole);
            context.SaveChanges();
            context.IPAddresses.Add(ip1);
            context.IPAddresses.Add(ip2);
            context.IPAddresses.Add(ip3);
            context.SaveChanges();
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);
            context.Users.Add(user6);
            context.Users.Add(user7);
            context.Users.Add(user8);
            context.Users.Add(user9);
            context.Users.Add(user10);
            context.Users.Add(user11);
            context.Users.Add(user13);
            context.Users.Add(user12);
            context.Users.Add(user14);
            context.Users.Add(user15);
            context.Users.Add(user16);
            context.Users.Add(user17);
            context.Users.Add(user18);
            context.Users.Add(user19);
            context.Users.Add(user20);
            context.SaveChanges();
            context.Groups.Add(group);
            context.Groups.Add(group2);
            context.Groups.Add(group3);
            context.Groups.Add(group4);
            context.SaveChanges();
            

            context.Files.Add(file1);
            context.Files.Add(file2);
            context.Files.Add(file3);
            context.Files.Add(file4);
            context.Files.Add(file5);

            context.Files.Add(file);
            context.SaveChanges();
            context.Transmittals.Add(transmittal);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}

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
            var user = new User
            {
                Role=adminRole,
                FirstName = "Bryan",
                LastName = "Wood",
                PasswordHash = "1234567890123456789012345678901234567890",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "bryan@bryanwood.com.au",
                Verified = false

            };
            var user2 = new User
            {
                Role=standardRole,
                FirstName = "Mitchell",
                LastName = "Pearson",
                PasswordHash = "1234567890123456789012345678901234567890",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "bryan@bryanwood.com.au",
                Verified = false
            };
            var group = new Group
            {
                 Name = "Bryan's Group",
                 Owner = user,
                 Users = new User[]{ user, user2},
            };
            var group2 = new Group
            {
                Name = "Mitch's Group",
                Owner = user2,
                Users = new User[] { user, user2},
            };

            var fileData = new FileData
            {
                Extension = "pdf",
                Hash = "123",
                Size = 1048,
            };

            var file = new File
            {
                FileData = fileData,
                Name = "File Name",
                Owner = user,
                DateCreated = DateTime.Now,
                Revoked = false
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
                Sender = user,
            };
            
            context.Roles.Add(standardRole);
            context.Roles.Add(adminRole);
            context.Users.Add(user2);
            context.Users.Add(user);
            context.Groups.Add(group);
            context.Groups.Add(group2);
            context.FileDatas.Add(fileData);
            context.Files.Add(file);
            context.Transmittals.Add(transmittal);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}

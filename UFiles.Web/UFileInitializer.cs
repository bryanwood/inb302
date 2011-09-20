using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace UFiles.Domain.Entities
{
    public class UFileInitializer : DropCreateDatabaseIfModelChanges<UFileContext>
    {
        protected override void Seed(UFileContext context)
        {
            var user = new User
            {
                FirstName = "Bryan",
                LastName = "Wood",
                PasswordHash = "1234567890123456789012345678901234567890",
                VerifiedHash = "1234567890123456789012345678901234567890",
                Email = "bryan@bryanwood.com.au",
                Verified = false

            };
            var user2 = new User
            {
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
            context.Users.Add(user2);
            context.Users.Add(user);
            context.Groups.Add(group);
            context.Groups.Add(group2);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}

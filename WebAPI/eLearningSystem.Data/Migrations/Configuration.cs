namespace eLearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using eLearningSystem.Data.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using static eLearningSystem.Data.Model.User;

    internal sealed class Configuration : DbMigrationsConfiguration<eLearningDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eLearningDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //AddRole(context);
            addUser(context);
        }

        private void addUser(eLearningDataContext context)
        {
            if (!context.Users.Any(t => t.UserName == "admin@gmail.com"))
            {
                var store = new UserStore<User, Role, int,
    UserLogin, UserRole, UserClaim>(context);
                var manager = new UserManager<User, int>(store);
                var user = new User
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    PhoneNumber = "19001001"
                };
                manager.Create(user, "123456");
                context.SaveChanges();
                //var user1 = context.Users.FirstOrDefault(t => t.UserName.Equals(user.UserName));
                //manager.AddToRole(user1.Id, "Admin");
                //context.SaveChanges();
            }
            if (!context.Users.Any(t => t.UserName == "student@gmail.com"))
            {
                var store = new UserStore<User, Role, int,
    UserLogin, UserRole, UserClaim>(context);
                var manager = new UserManager<User, int>(store);
                var user = new User
                {
                    UserName = "student@gmail.com",
                    Email = "student@gmail.com",
                    PhoneNumber = "19001001"
                };
                manager.Create(user, "123456");
                context.SaveChanges();
                //var user1 = context.Users.FirstOrDefault(t => t.UserName.Equals(user.UserName));
                //manager.AddToRole(user1.Id, "Student");
                //context.SaveChanges();
            }
            if (!context.Users.Any(t => t.UserName == "teacher@gmail.com"))
            {
                var store = new UserStore<User, Role, int,
    UserLogin, UserRole, UserClaim>(context);
                var manager = new UserManager<User, int>(store);
                var user = new User
                {
                    UserName = "teacher@gmail.com",
                    Email = "teacher@gmail.com",
                    PhoneNumber = "19001001"
                };
                manager.Create(user, "123456");
                context.SaveChanges();
                //var user1 = context.Users.FirstOrDefault(t => t.UserName.Equals(user.UserName));
                //manager.AddToRole(user1.Id, "Teacher");
                //context.SaveChanges();
            }
        }

        private void AddRole(eLearningDataContext context)
        {
            if (!context.Roles.Any(t => t.Name == "Admin" && t.Name == "Student" && t.Name == "Teacher"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var roleAdmin = new IdentityRole { Name = "Admin" };
                var roleUse = new IdentityRole { Name = "Student" };
                var roleTeacher = new IdentityRole { Name = "Teacher" };

                manager.Create(roleAdmin);
                manager.Create(roleUse);
                manager.Create(roleTeacher);

                context.SaveChanges();
            }
        }
    }
}

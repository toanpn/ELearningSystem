namespace eLearningSystem.Data.Migrations
{
    using eLearningSystem.Data.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            //  to avoid creating duplicate seed data.
            AddRole(context);
            AddUserAdmin(context);
            AddTeacher(context);
            AddStudent(context);
        }

        private void AddRole(eLearningDataContext context)
        {
            if (!context.Roles.Any(t => t.Name == "Admin" && t.Name == "Student" && t.Name == "Teacher"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var roleAdmin = new IdentityRole { Name = "Admin" };
                var roleStudent = new IdentityRole { Name = "Student" };
                var roleTeacher = new IdentityRole { Name = "Teacher" };

                manager.Create(roleAdmin);
                manager.Create(roleStudent);
                manager.Create(roleTeacher);

                context.SaveChanges();
            }
        }

        private void AddStudent(eLearningDataContext context)
        {
            if (!context.Users.Any(t => t.UserName == "StudentDemo1"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User
                {
                    UserName = "StudentDemo1",
                    Email = "studentdemo1@gmail.com",
                    PhoneNumber = "123123123",
                    address = "",
                    birth_day = DateTime.Now
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Student");

                context.SaveChanges();
            }
        }

        private void AddTeacher(eLearningDataContext context)
        {
            if (!context.Users.Any(t => t.UserName == "TeacherDemo1"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User
                {
                    UserName = "TeacherDemo1",
                    Email = "teacherdemo1@gmail.com",
                    PhoneNumber = "19001001",
                    address = "",
                    birth_day = DateTime.Now
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Teacher");

                context.SaveChanges();
            }
        }

        private void AddUserAdmin(eLearningDataContext context)
        {
            if (!context.Users.Any(t => t.UserName == "AdminDemo1"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User
                {
                    UserName = "AdminDemo1",
                    Email = "admindemo1@gmail.com",
                    PhoneNumber = "19001001",
                    address = "",
                    birth_day = DateTime.Now
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");

                context.SaveChanges();
            }
        }
    }
}

namespace Users.Repository.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Users.Model;
    using Users.Repository;

    internal sealed class Configuration : DbMigrationsConfiguration<Users.Repository.UsersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UsersDbContext context)
        {
            var role = new Role()
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Priority = 5,
                Description = "Important"
            };
            context.Roles.AddOrUpdate(role);

            var interests = new Interest()
            {
                Id = Guid.NewGuid(),
                Name = "Id",
                Description = "Very great job!"

            };
            context.Interests.AddOrUpdate(interests);

            var skill = new Skill()
            {
                Id = Guid.NewGuid(),
                Name = "Funny",
                Description = "Collective guy!",
                Difficulty = 10
            };
            context.Skills.AddOrUpdate(skill);

            context.SaveChanges();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = "zizi",
                Password = "123",
                FirstName = "Zdravko",
                LastName = "Katsarov",
                Email = "zdravkomai@mail.com",
                BirthDay = new DateTime(1987, 06, 11),
                Interests = new List<Interest> { interests },
                Skills = new List<Skill> { skill },
                RoleId = role.Id
            };
          
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
        }
    }
}

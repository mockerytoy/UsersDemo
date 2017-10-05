using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Model;
using Users.Model.Contracts;

namespace Users.Repository
{
    public class UsersDbContext : DbContext
    { 
        public UsersDbContext() : base("DefaultConnection")
        {
        }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Skill> Skills { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Role> Roles { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public static UsersDbContext Create()
        {
            return new UsersDbContext();
        }
    }
}

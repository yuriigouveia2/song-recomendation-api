using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CNX.UserService.Model.Entities;
using CNX.UserService.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CNX.UserService.Data.DataContext
{
    public class UserContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        #region DbSets
        public DbSet<PersonalNote> PersonalNotes { get; set; }
        public override DbSet<User> Users { get; set; }
        #endregion

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public UserContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=cnxinstanceyuri.cis6odahbbfw.sa-east-1.rds.amazonaws.com; Database=postgres; Username=postgres; Password=1qaz2wsx3edc");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(fk => fk.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}

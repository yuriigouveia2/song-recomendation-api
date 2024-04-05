using CNX.LogService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CNX.LogService.Data.DataContext
{
    public class LogContext : DbContext
    {
        #region DbSets
        public DbSet<Log> Logs { get; set; }
        #endregion

        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {
        }
        public LogContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=ctxinstancelog.cis6odahbbfw.sa-east-1.rds.amazonaws.com; Database=postgres; Username=postgres; Password=1qaz2wsx3edc");
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

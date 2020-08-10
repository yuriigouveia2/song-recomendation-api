using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CNX.UserService.Data.DataContext
{
    public class DesignTimeDbContextFactory //: IDesignTimeDbContextFactory<UserContext>
    {
        //public UserContext CreateDbContext(string[] args)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(Directory.GetCurrentDirectory() + "/../CNX.UserService.WebApi/" + GetEnvFile()).Build();
        //    var builder = new DbContextOptionsBuilder<UserContext>();
        //    var connectionString = configuration.GetConnectionString("BDConnection");
        //    builder.UseNpgsql(connectionString);
        //    return new UserContext(builder.Options);
        //}

        //public string GetConnectionString()
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + GetEnvPath(), true).Build();

        //    if (string.IsNullOrEmpty(configuration.GetConnectionString("REGConnection")))
        //    {
        //        configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + GetEnvFile()).Build();
        //    }

        //    return configuration.GetConnectionString("REGConnection");
        //}

        private string GetEnvPath()
        {
            return !IsDebug() ?
                " /../../../../../SESMA.REGULACAO.WebApi/appsettings.json" :
                " /../../../../../SESMA.REGULACAO.WebApi/appsettings.Development.json";
        }

        private string GetEnvFile()
        {
            return !IsDebug() ? "appsettings.json" : "appsettings.Development.json";
        }

        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
                    return false;
#endif
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ControlCenter.DB
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            string connectionString = "Server=(localdb)\\mssqllocaldb;Initial Catalog=ControlCenter_Db;Trusted_Connection=True;";

            builder.UseSqlServer(connectionString);
            builder.EnableSensitiveDataLogging();

            return new AppDbContext(builder.Options);
        }
    }
}
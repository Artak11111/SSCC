using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ControlCenter.DB
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ControlCenterDbContext>
    {
        public ControlCenterDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ControlCenterDbContext>();
            string connectionString = "Server=(localdb)\\mssqllocaldb;Initial Catalog=ControlCenter_Db;Trusted_Connection=True;";

            builder.UseSqlServer(connectionString);
            builder.EnableSensitiveDataLogging();

            return new ControlCenterDbContext(builder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace ControlCenter.DB
{
    public class ControlCenterDbContext : DbContext
    {

        public ControlCenterDbContext(DbContextOptions<ControlCenterDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ControlCenterDbContext).Assembly);
        }
    }
}
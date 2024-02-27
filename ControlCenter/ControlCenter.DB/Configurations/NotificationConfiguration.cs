using ControlCenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.DB.Configurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(n => n.Department);

            builder.HasMany(n => n.TargetDepartments)
                .WithOne(tg => tg.Notification)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

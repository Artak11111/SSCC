using ControlCenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.DB.Configurations
{
    public class DepartmentNotificationConfiguration : IEntityTypeConfiguration<DepartmentNotification>
    {
        public void Configure(EntityTypeBuilder<DepartmentNotification> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(i => new { i.DepartmentId, i.NotificationId })
                .IsUnique();
        }
    }
}

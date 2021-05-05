using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.DB.Configurations
{
    public class DepartmentNotificationConfiguration : IEntityTypeConfiguration<DepartmentNotification>
    {
        public void Configure(EntityTypeBuilder<DepartmentNotification> builder)
        {
            builder.HasKey(i => new { i .DepartmentId, i.NotificationId });

            builder
                .HasOne(un => un.Notification)
                .WithMany(n => n.TargetDepartments)
                .HasForeignKey(u => u.NotificationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
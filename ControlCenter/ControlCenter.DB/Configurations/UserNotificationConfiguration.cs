using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.DB.Configurations
{
    public class UserNotificationConfiguration: IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.HasKey(i => new { i .UserId, i.NotificationId });

            builder
                .HasOne(un => un.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(un => un.Notification)
                .WithMany(n => n.TargetUsers)
                .HasForeignKey(u => u.NotificationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
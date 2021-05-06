using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.DB.Configurations
{
    public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.HasKey(i => i.Id);

            builder
                .HasOne(un => un.User)
                .WithMany(u => u.Notifications)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(un => un.Notification)
                .WithMany(n => n.TargetUsers)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
using ControlCenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.DB.Configurations
{
    internal class DisabledDepartmentConfiguration : IEntityTypeConfiguration<DisabledDepartment>
    {
        public void Configure(EntityTypeBuilder<DisabledDepartment> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasIndex(i => new { i.DepartmentId, i.UserId })
                .IsUnique();

            builder
                .HasOne(un => un.User)
                .WithMany(u => u.DisabledDepartments)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(un => un.Department);
        }
    }
}

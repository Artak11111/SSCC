using System;
using ControlCenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.DB.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasData(new Department
            {
                Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "HR"
            },new Department
            {
                Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Name = "Development"
            },new Department
            {
                Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                Name = "DevOps"
            },new Department
            {
                Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                Name = "Sales"
            },new Department
            {
                Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                Name = "Management"
            });
        }
    }
}

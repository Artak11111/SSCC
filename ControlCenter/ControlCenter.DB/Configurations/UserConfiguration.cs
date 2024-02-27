using System;
using ControlCenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.DB.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(u=>u.Department);

            // HR department
            builder.HasData(new User
            {
                Id = new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Ani",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                Email = "hr1@solarsystem.com"
            }, new User
            {
                Id = new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Arsen",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                Email = "hr2@solarsystem.com"
            }, new User
            {
                Id = new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Davit",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                Email = "hr3@solarsystem.com"
            }, new User
            {
                Id = new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Shushan",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                Email = "hr4@solarsystem.com"
            });
            
            // Development department
            builder.HasData(new User
            {
                Id = new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Abgar",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer1@solarsystem.com"
            },new User
            {
                Id = new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Alex",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer2@solarsystem.com"
            },new User
            {
                Id = new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Armen",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer3@solarsystem.com"
            },new User
            {
                Id = new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Arshak",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer4@solarsystem.com"
            },new User
            {
                Id = new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Tigran",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer5@solarsystem.com"
            },new User
            {
                Id = new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Artyom",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer6@solarsystem.com"
            },new User
            {
                Id = new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Margarita",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer7@solarsystem.com"
            },new User
            {
                Id = new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Tatevik",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer8@solarsystem.com"
            },new User
            {
                Id = new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Mihran",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer9@solarsystem.com"
            },new User
            {
                Id = new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Dianna",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer10@solarsystem.com"
            },new User
            {
                Id = new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Murad",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer11@solarsystem.com"
            },new User
            {
                Id = new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Gurgen",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer12@solarsystem.com"
            },new User
            {
                Id = new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Elen",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer13@solarsystem.com"
            },new User
            {
                Id = new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Hasmik",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer14@solarsystem.com"
            },new User
            {
                Id = new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                Name = "Gor",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                Email = "developer15@solarsystem.com"
            });
            
            // DevOps department
            builder.HasData(new User
            {
                Id = new Guid("e886b336-8073-4004-befc-65f792585efd"),
                Name = "Viktor",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                Email = "devops1@solarsystem.com"
            },new User
            {
                Id = new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                Name = "Karen",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                Email = "devops2@solarsystem.com"
            },new User
            {
                Id = new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                Name = "Ashot",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                Email = "devops3@solarsystem.com"
            },new User
            {
                Id = new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                Name = "Kolya",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                Email = "devops4@solarsystem.com"
            });
            
            // Sales department
            builder.HasData(new User
            {
                Id = new Guid("f886b336-8073-4004-befc-65f792585efd"),
                Name = "Anahit",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                Email = "sales1@solarsystem.com"
            },new User
            {
                Id = new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                Name = "Edgar",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                Email = "sales2@solarsystem.com"
            },new User
            {
                Id = new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                Name = "Arsen",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                Email = "sales3@solarsystem.com"
            },new User
            {
                Id = new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                Name = "Arto",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                Email = "sales4@solarsystem.com"
            },new User
            {
                Id = new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                Name = "Rafo",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                Email = "sales5@solarsystem.com"
            },new User
            {
                Id = new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                Name = "Ando",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                Email = "sales6@solarsystem.com"
            });
            
            // Management department
            builder.HasData(new User
            {
                Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                Name = "Mxitar",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                Email = "management1@solarsystem.com"
            },new User
            {
                Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                Name = "Nver",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                Email = "management2@solarsystem.com"
            },new User
            {
                Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                Name = "Narek",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                Email = "management3@solarsystem.com"
            },new User
            {
                Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                Name = "Syuzi",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                Email = "management4@solarsystem.com"
            },new User
            {
                Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                Name = "Katya",
                Birthday = GenerateRandomBirthday(),
                DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                Email = "management5@solarsystem.com"
            });
        }

        private DateTime GenerateRandomBirthday()
        {
            var r = new Random();

            return DateTime.UtcNow.Date.AddYears(-r.Next(18, 35))
                .AddDays(r.Next(0, 365));
        }
    }
}

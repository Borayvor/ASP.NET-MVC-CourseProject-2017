namespace PhotoArtSystem.Data.Seeders
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.EnumTypes;
    using PhotoArtSystem.Common.Constants;

    public static class StaticDataSeeder
    {
        public static void SeedRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var administratorRole = new IdentityRole { Name = AuthConstants.AdministratorRoleName };
            roleManager.Create(administratorRole);

            context.SaveChanges();
        }

        public static void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            //// admin data
            const string AdministratorEmail = "admin@admin.com";

            // By default at ASP.NET MVC Username must be same as Email (to login)
            const string AdministratorUsername = AdministratorEmail;
            const string AdministratorPassword = "admin";

            //// Create admin user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new MinimumLengthValidator(AuthConstants.PasswordMinLength);

            var userAdmin = new ApplicationUser()
            {
                Email = AdministratorEmail,
                UserName = AdministratorUsername
            };

            userManager.Create(userAdmin, AdministratorPassword);

            //// Assign user to admin role
            userManager.AddToRole(userAdmin.Id, AuthConstants.AdministratorRoleName);

            //// End add.
            context.SaveChanges();
        }

        public static void SeedPhotocourses(ApplicationDbContext context)
        {
            if (context.Photocourses.Any())
            {
                return;
            }

            var photocourses1 = new Photocourse()
            {
                Name = "Photo courses 1",
                DescriptionShort = "Tincidunt integer eu augue augue nunc elit dolor.",
                Description = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel. \n\rTincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                DurationHours = 42,
                StartDate = DateTime.UtcNow.AddDays(7),
                EndDate = DateTime.UtcNow.AddDays(49),
                MaxStudents = 10
            };

            context.Photocourses.Add(photocourses1);

            var photocourses2 = new Photocourse()
            {
                Name = "Photo courses 2",
                DescriptionShort = "Vehicula ut laoreet ac, tincidunt integer.",
                Description = "Vehicula ut laoreet ac, tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                DurationHours = 24,
                StartDate = DateTime.UtcNow.AddDays(4),
                EndDate = DateTime.UtcNow.AddDays(28),
                MaxStudents = 7
            };

            context.Photocourses.Add(photocourses2);

            //// End add.
            context.SaveChanges();
        }

        public static void SeedImages(ApplicationDbContext context)
        {
            if (context.Images.Any())
            {
                return;
            }

            var photocourseId1 = context.Photocourses.FirstOrDefault().Id;

            var imageLink1 = new Image()
            {
                FileName = "World-of-Warcraft-Legion-Cinematic-Trailer-3",
                FileExtension = "jpg",
                UrlPath = "https://dl.dropboxusercontent.com/1/view/zkg913bztl4zrla/Apps/EntertainmentSystem/91cee43d-0904-4b58-983a-565e09ccd433.jpg",
                FileSize = FileSizeType.Width1200,
                PhotocourseId = photocourseId1
            };

            context.Images.Add(imageLink1);

            var photocourseId2 = context.Photocourses.FirstOrDefault(x => x.Id != photocourseId1).Id;

            var imageLink2 = new Image()
            {
                FileName = "Warcraft-Movie-Mobile-Wallpapers-1200x675",
                FileExtension = "jpg",
                UrlPath = "https://dl.dropboxusercontent.com/1/view/i1j0hpk6lpv2mjt/Apps/EntertainmentSystem/bb3f265e-6e89-4d66-9007-b0edeec2796e.jpg",
                FileSize = FileSizeType.Width1200,
                PhotocourseId = photocourseId2
            };

            context.Images.Add(imageLink2);

            //// End add.
            context.SaveChanges();
        }

        public static void SeedMainInfo(ApplicationDbContext context)
        {
            if (context.MainInfos.Any())
            {
                return;
            }

            var info_1 = new MainInfo()
            {
                Title = "Test Info 111",
                Description = "Luctus placerat scelerisque euismod"
            };

            context.MainInfos.Add(info_1);

            var info_2 = new MainInfo()
            {
                Title = "Test Info 222",
                Description = "Tincidunt integer eu augue"
            };

            context.MainInfos.Add(info_2);

            //// End add.
            context.SaveChanges();
        }

        public static void SeedStudents(ApplicationDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            var photocourseId = context.Photocourses.FirstOrDefault().Id;

            var student_1 = new Student()
            {
                FirstName = "Student_1_fn",
                LastName = "Student_1_ln",
                PhotocourseId = photocourseId
            };

            context.Students.Add(student_1);

            var student_2 = new Student()
            {
                FirstName = "Student_2_fn",
                LastName = "Student_2_ln",
                PhotocourseId = photocourseId
            };

            context.Students.Add(student_2);

            //// End add.
            context.SaveChanges();
        }
    }
}

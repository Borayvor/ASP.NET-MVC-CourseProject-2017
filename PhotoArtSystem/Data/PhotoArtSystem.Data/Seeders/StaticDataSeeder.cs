namespace PhotoArtSystem.Data.Seeders
{
    using System.Linq;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.PhotocourseModels;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Common.EnumTypes;

    internal static class StaticDataSeeder
    {
        internal static void SeedRoles(ApplicationDbContext context)
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

        internal static void SeedUsers(ApplicationDbContext context)
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

            var userAdmin = new ApplicationUser
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

        internal static void SeedPhotoArtServices(ApplicationDbContext context)
        {
            if (context.PhotoArtServices.Any())
            {
                return;
            }

            var photocourseService = new PhotoArtService()
            {
                Name = "Photo courses",
                Description = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel. \n\rTincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                Image = "https://www.dropbox.com/s/cn1kfrh5q9ddikt/cover14.jpg?dl=0"
            };

            context.PhotoArtServices.Add(photocourseService);

            var teambuildingService = new PhotoArtService()
            {
                Name = "Team building",
                Description = "Vehicula ut laoreet ac, tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                Image = "https://www.dropbox.com/s/17m1quk772bxj49/Photo_Kurs_Plovdiv.png?dl=0"
            };

            context.PhotoArtServices.Add(teambuildingService);

            //// End add.
            context.SaveChanges();
        }

        internal static void SeedPhotocourses(ApplicationDbContext context)
        {
            if (context.Photocourses.Any())
            {
                return;
            }

            var photocourses1 = new Photocourse()
            {
                Name = "Photo courses 1",
                Description = "Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel. \n\rTincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                PhotoArtServiceId = 1
            };

            context.Photocourses.Add(photocourses1);

            var photocourses2 = new Photocourse()
            {
                Name = "Photo courses 2",
                Description = "Vehicula ut laoreet ac, tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.",
                PhotoArtServiceId = 1
            };

            context.Photocourses.Add(photocourses2);

            //// End add.
            context.SaveChanges();
        }

        internal static void SeedImageLinks(ApplicationDbContext context)
        {
            if (context.ImageLinks.Any())
            {
                return;
            }

            var photocourseId = context.Photocourses.FirstOrDefault().Id;

            var imageLink1 = new Image()
            {
                FileName = "World-of-Warcraft-Legion-Cinematic-Trailer-3.jpg",
                Content = "https://dl.dropboxusercontent.com/1/view/zkg913bztl4zrla/Apps/EntertainmentSystem/91cee43d-0904-4b58-983a-565e09ccd433.jpg",
                FileSize = FileSizeType.Width1200,
                PhotocourseId = photocourseId
            };

            context.ImageLinks.Add(imageLink1);

            var imageLink2 = new Image()
            {
                FileName = "Warcraft-Movie-Mobile-Wallpapers-1200x675.jpg",
                Content = "https://dl.dropboxusercontent.com/1/view/i1j0hpk6lpv2mjt/Apps/EntertainmentSystem/bb3f265e-6e89-4d66-9007-b0edeec2796e.jpg",
                FileSize = FileSizeType.Width1200,
                PhotocourseId = photocourseId
            };

            context.ImageLinks.Add(imageLink2);

            //// End add.
            context.SaveChanges();
        }
    }
}

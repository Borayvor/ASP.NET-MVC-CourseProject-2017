namespace PhotoArtSystem.Data.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.EnumTypes;
    using PhotoArtSystem.Common.Constants;

    public static class StaticDataSeeder
    {
        private static Guid imageFirstId;
        private static Guid imageSecondId;

        private static IList<Image> imagesList1 = new List<Image>();
        private static IList<Image> imagesList2 = new List<Image>();

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

        public static void SeedImages(ApplicationDbContext context)
        {
            if (context.Images.Any())
            {
                return;
            }

            var imageLink1 = new Image()
            {
                FileName = "Photo_Cours_Sofia",
                FileExtension = "jpg",
                UrlPath = "https://firebasestorage.googleapis.com/v0/b/photoartsystem.appspot.com/o/cover14.jpg?alt=media&token=78ad7e9c-de8b-47d7-87d9-7654bdb3cc00",
                Format = ImageFormatType.Cover
            };

            imageFirstId = imageLink1.Id;
            context.Images.Add(imageLink1);

            var imageLink2 = new Image()
            {
                FileName = "Photo_Cours_Plovdiv",
                FileExtension = "jpg",
                UrlPath = "https://firebasestorage.googleapis.com/v0/b/photoartsystem.appspot.com/o/Photo_Kurs_Plovdiv.png?alt=media&token=75758313-481f-4259-a7ef-99a79b7e361f",
                Format = ImageFormatType.Cover
            };

            imageSecondId = imageLink2.Id;
            context.Images.Add(imageLink2);

            var imageLink3 = new Image()
            {
                FileName = "Wolves",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473243/Wolves_ac525794-b122-4697-96fe-319af7892dad.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList1.Add(imageLink3);
            context.Images.Add(imageLink3);

            var imageLink4 = new Image()
            {
                FileName = "Valley",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473241/Valley_abedd9c5-fbe0-49ea-b887-4ff78b7ae1f0.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList1.Add(imageLink4);
            context.Images.Add(imageLink4);

            var imageLink5 = new Image()
            {
                FileName = "Unicorn",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473240/Unicorn_1d70697d-db94-48c7-bf9b-395656ef993c.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList1.Add(imageLink5);
            context.Images.Add(imageLink5);

            var imageLink6 = new Image()
            {
                FileName = "Plain",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473239/Plain_b189aaae-b058-4184-ad2a-463e518435f6.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList1.Add(imageLink6);
            context.Images.Add(imageLink6);

            var imageLink7 = new Image()
            {
                FileName = "Night",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473237/Night_487b25ef-33e6-4449-8ded-db196c050ce6.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList1.Add(imageLink7);
            context.Images.Add(imageLink7);

            var imageLink8 = new Image()
            {
                FileName = "Forest",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473235/Forest_897c35e6-c901-4dab-8aae-2319950e2903.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList2.Add(imageLink7);
            context.Images.Add(imageLink8);

            var imageLink9 = new Image()
            {
                FileName = "Cloudsplain",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473234/Cloudsplain_1f947089-580e-4282-976a-179f40a49fa7.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList2.Add(imageLink9);
            context.Images.Add(imageLink9);

            var imageLink10 = new Image()
            {
                FileName = "CastleLabyrinth",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473232/CastleLabyrinth_2f640789-9ea7-4046-9984-bea958f3f204.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList2.Add(imageLink10);
            context.Images.Add(imageLink10);

            var imageLink11 = new Image()
            {
                FileName = "Castle",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491473230/Castle_47b2987c-aff4-4e29-92f7-edea8a2b4217.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList2.Add(imageLink11);
            context.Images.Add(imageLink11);

            var imageLink12 = new Image()
            {
                FileName = "Beach",
                FileExtension = "jpg",
                UrlPath = "http://res.cloudinary.com/hrmf5moev/image/upload/v1491470981/Beach_d603652e-3f54-475b-b3f8-4590ec97a26a.jpg",
                Format = ImageFormatType.Ordinary
            };

            imagesList2.Add(imageLink12);
            context.Images.Add(imageLink12);

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
                MaxStudents = 10,
                ImageCoverId = imageFirstId,
                Images = imagesList1
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
                MaxStudents = 7,
                ImageCoverId = imageSecondId,
                Images = imagesList2
            };

            context.Photocourses.Add(photocourses2);

            //// End add.
            context.SaveChanges();
        }

        public static void SeedInformation(ApplicationDbContext context)
        {
            if (context.Informations.Any())
            {
                return;
            }

            var info_1 = new Information()
            {
                Title = "Luctus",
                Description = "Luctus placerat scelerisque euismod, integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod"
            };

            context.Informations.Add(info_1);

            var info_2 = new Information()
            {
                Title = "Tincidunt",
                Description = "Tincidunt integer eu augue, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel."
            };

            context.Informations.Add(info_2);

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

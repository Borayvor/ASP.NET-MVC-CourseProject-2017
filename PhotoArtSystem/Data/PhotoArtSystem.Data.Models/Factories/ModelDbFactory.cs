namespace PhotoArtSystem.Data.Models.Factories
{
    using System;
    using System.Collections.Generic;
    using EnumTypes;

    public class ModelDbFactory : IModelDbFactory
    {
        public Image CreateImage(
            string fileName,
            string fileExtension,
            string urlPath,
            ImageFormatType format,
            Guid? photocourseId,
            Photocourse photocourse)
        {
            return new Image
            {
                FileName = fileName,
                FileExtension = fileExtension,
                UrlPath = urlPath,
                Format = format,
                PhotocourseId = photocourseId,
                Photocourse = photocourse
            };
        }

        public Photocourse CreatePhotocourse(
            string name,
            string descriptionShort,
            string description,
            string otherInfo,
            string teacher,
            int maxStudents,
            int durationHours,
            DateTime startDate,
            DateTime endDate,
            Guid? imageCoverId,
            Image imageCover,
            ICollection<Image> images,
            ICollection<Student> students)
        {
            if (images == null)
            {
                images = new List<Image>();
            }

            if (students == null)
            {
                students = new List<Student>();
            }

            return new Photocourse
            {
                Name = name,
                DescriptionShort = descriptionShort,
                Description = description,
                OtherInfo = otherInfo,
                Teacher = teacher,
                MaxStudents = maxStudents,
                DurationHours = durationHours,
                StartDate = startDate,
                EndDate = endDate,
                ImageCoverId = imageCoverId,
                ImageCover = imageCover,
                Images = images,
                Students = students
            };
        }

        public Multimedia CreateMultimedia(
            string title,
            string description,
            string urlPath,
            string imageUrlPath)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                description = string.Empty;
            }

            return new Multimedia
            {
                Title = title,
                Description = description,
                UrlPath = urlPath,
                ImageUrlPath = imageUrlPath
            };
        }
    }
}

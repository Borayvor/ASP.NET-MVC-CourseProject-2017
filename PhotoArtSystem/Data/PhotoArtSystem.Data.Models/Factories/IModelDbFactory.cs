namespace PhotoArtSystem.Data.Models.Factories
{
    using System;
    using System.Collections.Generic;
    using EnumTypes;

    public interface IModelDbFactory
    {
        Image CreateImage(
            string fileName,
            string fileExtension,
            string urlPath,
            ImageFormatType format,
            Guid? photocourseId,
            Photocourse photocourse);

        Photocourse CreatePhotocourse(
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
            ICollection<Student> students);

        Multimedia CreateMultimedia(
            string title,
            string description,
            string urlPath,
            string imageUrlPath);
    }
}

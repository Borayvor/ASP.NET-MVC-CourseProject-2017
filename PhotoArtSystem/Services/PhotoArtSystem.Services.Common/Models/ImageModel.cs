namespace PhotoArtSystem.Services.Common.Models
{
    using System;
    using Data.Models;
    using Data.Models.Contracts;
    using Data.Models.EnumTypes;

    public class ImageModel : IImage
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid PhotocourseId { get; set; }

        public Photocourse Photocourse { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string UrlPath { get; set; }

        public FileSizeType FileSize { get; set; }
    }
}

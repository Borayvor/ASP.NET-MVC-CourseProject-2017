namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using System.IO;
    using Common.Models;
    using EnumTypes;

    public abstract class FileInfoTransitional : BaseModelTransitional<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public Stream Stream { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string UrlPath { get; set; }

        public ImageFormatType Format { get; set; }
    }
}

namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using Common.Models;
    using EnumTypes;

    public abstract class FileInfoTransitional : BaseModelTransitional<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string UrlPath { get; set; }

        public FileSizeType FileSize { get; set; }
    }
}

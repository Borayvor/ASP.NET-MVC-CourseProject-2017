namespace PhotoArtSystem.Services.Common.Models
{
    using System;
    using Data.Common.Models;
    using Data.Models.EnumTypes;

    public abstract class FileInfoModel : BaseModelModel<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string UrlPath { get; set; }

        public FileSizeType FileSize { get; set; }
    }
}

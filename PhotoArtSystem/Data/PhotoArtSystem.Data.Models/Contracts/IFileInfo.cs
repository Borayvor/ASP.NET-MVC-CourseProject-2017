namespace PhotoArtSystem.Data.Models.Contracts
{
    using System;
    using Common.Models;
    using EnumTypes;

    public interface IFileInfo : IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        string FileName { get; set; }

        string FileExtension { get; set; }

        string UrlPath { get; set; }

        FileSizeType FileSize { get; set; }
    }
}

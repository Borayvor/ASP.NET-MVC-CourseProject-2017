namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using Contracts;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Common.EnumTypes;

    public abstract class FileInfo : BaseModelGuid, IFileInfo, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [Index]
        [MaxLength(ModelConstants.FileInfoFileNameMaxLength)]
        [MinLength(ModelConstants.FileInfoFileNameMinLength)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(ModelConstants.FileInfoFileExtensionMaxLength)]
        [MinLength(ModelConstants.FileInfoFileExtensionMinLength)]
        public string FileExtension { get; set; }

        [Required]
        [MaxLength(ModelConstants.FileInfoUrlPathMaxLength)]
        public string UrlPath { get; set; }

        public FileSizeType FileSize { get; set; }
    }
}

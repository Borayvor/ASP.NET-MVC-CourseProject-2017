namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Common.EnumTypes;
    using PhotocourseModels;

    public class ImageLink : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.PhotoLinkFileNameMaxLength)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotoLinkContentMaxLength)]
        public string Content { get; set; }

        public FileSizeType FileSize { get; set; }

        public Guid PhotocourseId { get; set; }

        public virtual Photocourse Photocourse { get; set; }

        public Guid PhotocourseGroupId { get; set; }

        public virtual PhotocourseGroup PhotocourseGroup { get; set; }
    }
}

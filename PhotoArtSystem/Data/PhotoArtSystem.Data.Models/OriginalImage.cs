namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class OriginalImage : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.ImageOriginalFileNameMaxLength)]
        [Index(IsUnique = true)]
        public string FileName { get; set; }

        [Required]
        [StringLength(ModelConstants.ImageOriginalContentTypeMaxLength)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}

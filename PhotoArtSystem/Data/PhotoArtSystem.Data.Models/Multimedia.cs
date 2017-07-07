namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.Models;

    public class Multimedia : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.MultimediaTitleMaxLength)]
        [MinLength(ModelConstants.MultimediaTitleMinLength)]
        public string Title { get; set; }

        [MaxLength(ModelConstants.MultimediaDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ModelConstants.MultimediaUrlPathMaxLength)]
        public string UrlPath { get; set; }

        [Required]
        [MaxLength(ModelConstants.MultimediaUrlPathMaxLength)]
        public string ImageUrlPath { get; set; }
    }
}

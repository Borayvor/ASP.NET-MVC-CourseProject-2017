namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class MainInfo : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.MainInfoTitleMaxLength)]
        [MinLength(ModelConstants.MainInfoTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ModelConstants.MainInfoDescriptionMaxLength)]
        [MinLength(ModelConstants.MainInfoDescriptionMinLength)]
        public string Description { get; set; }
    }
}

namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class Information : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.InformationTitleMaxLength)]
        [MinLength(ModelConstants.InformationTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ModelConstants.InformationDescriptionMaxLength)]
        [MinLength(ModelConstants.InformationDescriptionMinLength)]
        public string Description { get; set; }
    }
}

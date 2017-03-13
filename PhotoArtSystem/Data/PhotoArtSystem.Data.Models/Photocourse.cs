namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using Contracts;
    using PhotoArtSystem.Common.Constants;

    public class Photocourse : BaseModelGuid, IPhotocourse, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        public string Name { get; set; }
    }
}

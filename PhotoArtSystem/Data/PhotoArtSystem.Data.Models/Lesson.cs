namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class Lesson : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.LessonNameMaxLength)]
        [MinLength(ModelConstants.LessonNameMinLength)]
        public string Name { get; set; }

        [MaxLength(ModelConstants.LessonDescriptionMaxLength)]
        public string Description { get; set; }
    }
}

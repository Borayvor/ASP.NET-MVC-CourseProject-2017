namespace PhotoArtSystem.Data.Models.PhotocourseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class Lesson : BaseModel<int>, IBaseModel<int>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.LessonNameMaxLength)]
        [MinLength(ModelConstants.LessonNameMinLength)]
        public string Name { get; set; }

        public Guid PhotocourseId { get; set; }

        public virtual Photocourse Photocourse { get; set; }
    }
}

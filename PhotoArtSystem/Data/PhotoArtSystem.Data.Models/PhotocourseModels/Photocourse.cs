namespace PhotoArtSystem.Data.Models.PhotocourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class Photocourse : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        private ICollection<Lesson> lessons;

        public Photocourse()
        {
            this.lessons = new HashSet<Lesson>();
        }

        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotocourseDescriptionMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionMinLength)]
        public string Description { get; set; }

        public ushort DurationHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Teacher { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public virtual ICollection<Lesson> Lessons
        {
            get { return this.lessons; }
            set { this.lessons = value; }
        }
    }
}

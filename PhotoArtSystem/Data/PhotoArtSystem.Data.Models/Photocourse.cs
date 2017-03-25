namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class Photocourse : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        private ICollection<Image> images;
        private ICollection<Student> students;

        public Photocourse()
        {
            this.images = new HashSet<Image>();
            this.students = new HashSet<Student>();
        }

        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotocourseDescriptionShortMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionShortMinLength)]
        public string DescriptionShort { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotocourseDescriptionMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionMinLength)]
        public string Description { get; set; }

        [MaxLength(ModelConstants.PhotocourseOtherInfoMaxLength)]
        public string OtherInfo { get; set; }

        [Range(1, 1000)]
        public int DurationHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(ModelConstants.PhotocourseTeacherMaxLength)]
        public string Teacher { get; set; }

        [Range(1, 50)]
        public int MaxStudents { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}

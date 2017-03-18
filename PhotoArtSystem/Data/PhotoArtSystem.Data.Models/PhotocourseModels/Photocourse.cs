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
        private ICollection<ImageLink> images;
        private ICollection<PhotocourseGroup> groups;

        public Photocourse()
        {
            this.lessons = new HashSet<Lesson>();
            this.images = new HashSet<ImageLink>();
            this.groups = new HashSet<PhotocourseGroup>();
        }

        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotocourseDescriptionMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionMinLength)]
        public string Description { get; set; }

        [MaxLength(ModelConstants.PhotocourseOtherInfoMaxLength)]
        public string OtherInfo { get; set; }

        public int PhotoArtServiceId { get; set; }

        public virtual PhotoArtService PhotoArtService { get; set; }

        public virtual ICollection<Lesson> Lessons
        {
            get { return this.lessons; }
            set { this.lessons = value; }
        }

        public virtual ICollection<ImageLink> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<PhotocourseGroup> Groups
        {
            get { return this.groups; }
            set { this.groups = value; }
        }
    }
}

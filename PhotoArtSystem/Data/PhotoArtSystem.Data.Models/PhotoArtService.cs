namespace PhotoArtSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;
    using PhotocourseModels;

    public class PhotoArtService : BaseModel<int>, IBaseModel<int>, IAuditInfo, IDeletableEntity
    {
        private ICollection<Photocourse> photocourses;

        public PhotoArtService()
        {
            this.photocourses = new HashSet<Photocourse>();
        }

        [Required]
        [MaxLength(ModelConstants.PhotoArtServiceNameMaxLength)]
        [MinLength(ModelConstants.PhotoArtServiceNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotoArtServiceDescriptionMaxLength)]
        [MinLength(ModelConstants.PhotoArtServiceDescriptionMinLength)]
        public string Description { get; set; }

        public virtual ICollection<Photocourse> Photocourses
        {
            get { return this.photocourses; }
            set { this.photocourses = value; }
        }
    }
}

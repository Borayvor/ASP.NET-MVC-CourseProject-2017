namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models.TransitionalModels;
    using Web.ViewModels;

    public class PhotocourseCreateViewModel : BaseDbKeyViewModel<Guid>
    {
        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotocourseDescriptionShortMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionShortMinLength)]
        [Display(Name = "Short description")]
        public string DescriptionShort { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotocourseDescriptionMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionMinLength)]
        public string Description { get; set; }

        [MaxLength(ModelConstants.PhotocourseOtherInfoMaxLength)]
        [Display(Name = "Additional information")]
        public string OtherInfo { get; set; }

        [Range(1, 1000)]
        public int DurationHours { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [MaxLength(ModelConstants.PhotocourseTeacherMaxLength)]
        public string Teacher { get; set; }

        [Range(1, 50)]
        [Display(Name = "Max students")]
        public int MaxStudents { get; set; }

        public Guid? MainImageId { get; set; }

        public IEnumerable<ImageTransitional> Images { get; set; }

        public IEnumerable<StudentTransitional> Students { get; set; }
    }
}

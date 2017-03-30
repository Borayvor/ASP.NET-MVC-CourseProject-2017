namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Common.Constants;
    using Data.Models.TransitionalModels;
    using Infrastructure.Filters;

    public class PhotocourseCreateViewModel
    {
        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        [UIHint("StringLine")]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotocourseDescriptionShortMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionShortMinLength)]
        [UIHint("TinyMce")]
        [Display(Name = "Short Description")]
        public string DescriptionShort { get; set; }

        [Required]
        [MaxLength(ModelConstants.PhotocourseDescriptionMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionMinLength)]
        [UIHint("TinyMce")]
        public string Description { get; set; }

        [MaxLength(ModelConstants.PhotocourseOtherInfoMaxLength)]
        [Display(Name = "Additional information")]
        [UIHint("TinyMce")]
        public string OtherInfo { get; set; }

        [Range(1, 1000)]
        [UIHint("Number")]
        public int DurationHours { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [MaxLength(ModelConstants.PhotocourseTeacherMaxLength)]
        [UIHint("StringLine")]
        public string Teacher { get; set; }

        [Range(1, 50)]
        [Display(Name = "Max students")]
        [UIHint("Number")]
        public int MaxStudents { get; set; }

        public Guid? MainImageId { get; set; }

        [Required]
        [ValidateImageFile]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public IEnumerable<ImageTransitional> Images { get; set; }

        public IEnumerable<StudentTransitional> Students { get; set; }
    }
}

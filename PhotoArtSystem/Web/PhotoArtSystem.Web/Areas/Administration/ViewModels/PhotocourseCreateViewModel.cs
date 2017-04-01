namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class PhotocourseCreateViewModel : IMapTo<PhotocourseTransitional>
    {
        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        [UIHint("StringLine")]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("TinyMce")]
        [Display(Name = "Short Description")]
        [MaxLength(ModelConstants.PhotocourseDescriptionShortMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionShortMinLength)]
        public string DescriptionShort { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("TinyMce")]
        [MaxLength(ModelConstants.PhotocourseDescriptionMaxLength)]
        [MinLength(ModelConstants.PhotocourseDescriptionMinLength)]
        public string Description { get; set; }

        [AllowHtml]
        [UIHint("TinyMce")]
        [Display(Name = "Additional information")]
        [MaxLength(ModelConstants.PhotocourseOtherInfoMaxLength)]
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
    }
}

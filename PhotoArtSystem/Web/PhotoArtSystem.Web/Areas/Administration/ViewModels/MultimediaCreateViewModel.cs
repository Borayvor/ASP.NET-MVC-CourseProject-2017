namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Web.Infrastructure.Mapping;

    public class MultimediaCreateViewModel : IMapTo<MultimediaTransitional>
    {
        [Required]
        [MaxLength(ModelConstants.MultimediaTitleMaxLength)]
        [MinLength(ModelConstants.MultimediaTitleMinLength)]
        public string Title { get; set; }

        [AllowHtml]
        [UIHint("TinyMce")]
        [MaxLength(ModelConstants.MultimediaDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^(https://youtu.be/)\w+", ErrorMessage = GlobalConstants.YouTubeRequiredExceptionMessage)]
        [MaxLength(ModelConstants.MultimediaUrlPathMaxLength)]
        public string UrlPath { get; set; }
    }
}
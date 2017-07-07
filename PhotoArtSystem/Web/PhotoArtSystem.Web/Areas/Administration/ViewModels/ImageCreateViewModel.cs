namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.EnumTypes;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;
    using PhotoArtSystem.Common.Constants;

    public class ImageCreateViewModel : IMapTo<ImageTransitional>
    {
        [Required]
        [MaxLength(ModelConstants.FileInfoFileNameMaxLength)]
        [MinLength(ModelConstants.FileInfoFileNameMinLength)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(ModelConstants.FileInfoFileExtensionMaxLength)]
        [MinLength(ModelConstants.FileInfoFileExtensionMinLength)]
        public string FileExtension { get; set; }

        [Required]
        [MaxLength(ModelConstants.FileInfoUrlPathMaxLength)]
        public string UrlPath { get; set; }

        public ImageFormatType Format { get; set; }
    }
}

namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using Data.Models.EnumTypes;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class ImageCreateViewModel : IMapTo<ImageTransitional>
    {
        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string UrlPath { get; set; }

        public ImageFormatType Format { get; set; }
    }
}

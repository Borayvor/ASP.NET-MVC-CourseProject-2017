namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Web;
    using AutoMapper;
    using Data.Models.TransitionalModels;
    using EntertainmentSystem.Common.ExtensionMethods;
    using Infrastructure.Mapping;
    using PhotoArtSystem.Common.Constants;

    public class HttpPostedFileBaseViewModel : IMapFrom<HttpPostedFileBase>, IMapTo<ImageTransitional>, IHaveCustomMappings
    {
        public Stream FileStream { get; set; }

        [Required]
        [MaxLength(ModelConstants.FileInfoFileNameMaxLength)]
        [MinLength(ModelConstants.FileInfoFileNameMinLength)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(ModelConstants.FileInfoFileExtensionMaxLength)]
        [MinLength(ModelConstants.FileInfoFileExtensionMinLength)]
        public string FileExtension { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<HttpPostedFileBase, HttpPostedFileBaseViewModel>()
                .ForMember(m => m.FileStream, opt => opt.MapFrom(x => x.InputStream))
                .ForMember(m => m.FileName, opt => opt.MapFrom(x => x.FileName.GetFileName()))
                .ForMember(m => m.FileExtension, opt => opt.MapFrom(x => x.ContentType.GetFileExtensionFromContentType()));
        }
    }
}

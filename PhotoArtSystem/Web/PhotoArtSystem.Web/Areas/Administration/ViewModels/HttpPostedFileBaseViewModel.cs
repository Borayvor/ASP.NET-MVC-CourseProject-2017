namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System.IO;
    using System.Web;
    using AutoMapper;
    using Data.Models.TransitionalModels;
    using EntertainmentSystem.Common.ExtensionMethods;
    using Infrastructure.Mapping;

    public class HttpPostedFileBaseViewModel : IMapFrom<HttpPostedFileBase>, IMapTo<ImageTransitional>, IHaveCustomMappings
    {
        public Stream FileStream { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<HttpPostedFileBase, HttpPostedFileBaseViewModel>()
                .ForMember(m => m.FileStream, opt => opt.MapFrom(x => x.InputStream))
                .ForMember(m => m.FileName, opt => opt.MapFrom(x => x.FileName.GetFileName()))
                .ForMember(m => m.FileExtension, opt => opt.MapFrom(x => x.ContentType.GetFileExtension()));
        }
    }
}

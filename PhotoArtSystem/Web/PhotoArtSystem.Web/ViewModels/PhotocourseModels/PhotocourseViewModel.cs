namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using AutoMapper;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class PhotocourseViewModel : BaseDbKeyViewModel<Guid>,
        IMapFrom<PhotocourseTransitional>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int DurationHours { get; set; }

        public string Description { get; set; }

        public string CoverImage { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PhotocourseTransitional, PhotocourseViewModel>()
                .ForMember(m => m.CoverImage, opt => opt.MapFrom(x => x.MainImage.UrlPath));
        }
    }
}

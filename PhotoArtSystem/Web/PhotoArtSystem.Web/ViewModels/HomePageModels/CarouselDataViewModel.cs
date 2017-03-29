namespace PhotoArtSystem.Web.ViewModels.HomePageModels
{
    using System;
    using AutoMapper;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class CarouselDataViewModel : BaseDbKeyViewModel<Guid>,
        IMapFrom<PhotocourseTransitional>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string CoverImage { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PhotocourseTransitional, CarouselDataViewModel>()
                .ForMember(m => m.CoverImage, opt => opt.MapFrom(x => x.MainImage.UrlPath));
        }
    }
}
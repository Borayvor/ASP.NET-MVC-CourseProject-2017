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

        public string CoverImageSmall { get; set; }

        public string CoverImageLarge { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            // TODO: refactor
            configuration.CreateMap<PhotocourseTransitional, CarouselDataViewModel>()
                .ForMember(
                m => m.CoverImageSmall,
                opt => opt.MapFrom(x => x.ImageCover.UrlPath))
                .ForMember(
                m => m.CoverImageLarge,
                opt => opt.MapFrom(x => x.ImageCover.UrlPath));
        }
    }
}
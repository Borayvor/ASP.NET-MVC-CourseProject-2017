namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data.Models.PhotocourseModels;
    using Infrastructure.Mapping;

    public class PhotocourseViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<Photocourse>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MainImage { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Photocourse, PhotocourseViewModel>()
               .ForMember(m => m.MainImage, opt => opt.MapFrom(x => x.Images.FirstOrDefault().Content));
        }
    }
}

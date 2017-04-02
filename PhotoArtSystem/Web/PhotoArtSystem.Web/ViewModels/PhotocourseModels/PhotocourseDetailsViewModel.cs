namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models.EnumTypes;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class PhotocourseDetailsViewModel : BaseDbKeyViewModel<Guid>,
        IMapFrom<PhotocourseTransitional>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public int DurationHours { get; set; }

        public string Description { get; set; }

        public string OtherInfo { get; set; }

        public IEnumerable<ImageTransitional> Images { get; set; }

        public IEnumerable<StudentTransitional> Students { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PhotocourseTransitional, PhotocourseDetailsViewModel>()
                .ForMember(
                m => m.Images,
                opt => opt.MapFrom(x => x.Images.Where(i => i.Format == ImageFormatType.Ordinary)));
        }
    }
}

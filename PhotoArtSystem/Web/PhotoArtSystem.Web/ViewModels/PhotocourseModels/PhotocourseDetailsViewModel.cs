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

        public int StudentPositionCount { get; set; }

        public int DurationHours { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string DescriptionShort { get; set; }

        public string Description { get; set; }

        public string OtherInfo { get; set; }

        public string Teacher { get; set; }

        public IEnumerable<ImageTransitional> Images { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PhotocourseTransitional, PhotocourseDetailsViewModel>()
                .ForMember(
                m => m.StartDate,
                opt => opt.MapFrom(x => x.StartDate.ToLocalTime().ToShortDateString()))
                .ForMember(
                m => m.EndDate,
                opt => opt.MapFrom(x => x.EndDate.ToLocalTime().ToShortDateString()))
                .ForMember(
                m => m.Images,
                opt => opt.MapFrom(x => x.Images.Where(i => i.Format == ImageFormatType.Ordinary)))
                .ForMember(
                m => m.StudentPositionCount,
                opt => opt.MapFrom(x => (x.MaxStudents - x.Students.Count())));
        }
    }
}

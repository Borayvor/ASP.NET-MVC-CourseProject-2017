﻿namespace PhotoArtSystem.Web.ViewModels.HomePageModels
{
    using System;
    using AutoMapper;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class CarouselDataViewModel : BaseDbKeyViewModel<Guid>,
        IMapFrom<PhotocourseTransitional>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string ImageCover { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PhotocourseTransitional, CarouselDataViewModel>()
                .ForMember(
                m => m.ImageCover,
                opt => opt.MapFrom(x => x.ImageCover.UrlPath));
        }
    }
}
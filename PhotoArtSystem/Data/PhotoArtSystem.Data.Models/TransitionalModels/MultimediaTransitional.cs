namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using PhotoArtSystem.Web.Infrastructure.Mapping;

    public class MultimediaTransitional : BaseModelTransitional<Guid>,
        IMapFrom<Multimedia>, IMapTo<Multimedia>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string UrlPath { get; set; }

        public string ImageUrlPath { get; set; }
    }
}

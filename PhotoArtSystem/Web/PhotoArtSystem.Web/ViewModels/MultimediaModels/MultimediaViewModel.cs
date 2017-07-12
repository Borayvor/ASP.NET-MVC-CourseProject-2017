namespace PhotoArtSystem.Web.ViewModels.MultimediaModels
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Web.Infrastructure.Mapping;

    public class MultimediaViewModel : BaseDbKeyViewModel<Guid>,
        IMapFrom<MultimediaTransitional>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string UrlPath { get; set; }

        public string ImageUrlPath { get; set; }
    }
}
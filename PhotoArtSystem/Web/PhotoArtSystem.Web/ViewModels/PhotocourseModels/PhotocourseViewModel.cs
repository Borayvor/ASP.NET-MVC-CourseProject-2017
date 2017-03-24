namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using System.Collections.Generic;
    using Data.Models.TransitionalModels;
    using Services.Web.Mapping;

    public class PhotocourseViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<PhotocourseTransitional>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ImageTransitional> Images { get; set; }
    }
}

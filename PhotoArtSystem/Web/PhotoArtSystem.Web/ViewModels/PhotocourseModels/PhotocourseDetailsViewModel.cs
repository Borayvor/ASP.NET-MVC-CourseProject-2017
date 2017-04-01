namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using System.Collections.Generic;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class PhotocourseDetailsViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<PhotocourseTransitional>
    {
        public string Name { get; set; }

        public int DurationHours { get; set; }

        public string Description { get; set; }

        public string OtherInfo { get; set; }

        public IEnumerable<ImageTransitional> Images { get; set; }

        public IEnumerable<StudentTransitional> Students { get; set; }
    }
}

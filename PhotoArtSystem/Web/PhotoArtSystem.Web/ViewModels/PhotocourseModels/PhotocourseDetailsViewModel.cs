namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using System.Collections.Generic;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class PhotocourseDetailsViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<PhotocourseTransitional>
    {
        public string OtherInfo { get; set; }

        public IEnumerable<ImageTransitional> Images { get; set; }

        public IEnumerable<StudentTransitional> Students { get; set; }
    }
}

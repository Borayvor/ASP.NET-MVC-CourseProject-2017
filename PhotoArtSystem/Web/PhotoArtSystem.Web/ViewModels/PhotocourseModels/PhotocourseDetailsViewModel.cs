namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Data.Models.TransitionalModels;
    using Services.Web.Mapping;

    public class PhotocourseDetailsViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<Photocourse>
    {
        public string OtherInfo { get; set; }

        public IEnumerable<ImageTransitional> Images { get; set; }

        public IEnumerable<StudentTransitional> Groups { get; set; }
    }
}

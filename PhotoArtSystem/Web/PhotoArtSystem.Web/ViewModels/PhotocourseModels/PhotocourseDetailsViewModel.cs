namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Data.Models.PhotocourseModels;
    using Infrastructure.Mapping;

    public class PhotocourseDetailsViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<Photocourse>
    {
        public string OtherInfo { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }

        public IEnumerable<ImageLink> Images { get; set; }

        public IEnumerable<PhotocourseGroup> Groups { get; set; }
    }
}

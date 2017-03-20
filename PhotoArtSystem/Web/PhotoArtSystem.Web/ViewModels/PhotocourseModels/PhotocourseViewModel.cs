namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using Data.Models;
    using Data.Models.PhotocourseModels;
    using Infrastructure.Mapping;

    public class PhotocourseViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<Photocourse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string OtherInfo { get; set; }

        public IEquatable<Lesson> Lessons { get; set; }

        public IEquatable<ImageLink> Images { get; set; }

        public IEquatable<PhotocourseGroup> Groups { get; set; }
    }
}

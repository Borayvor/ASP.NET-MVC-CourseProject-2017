namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PhotocourseDetailsViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<Photocourse>
    {
        public string OtherInfo { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<Student> Groups { get; set; }
    }
}

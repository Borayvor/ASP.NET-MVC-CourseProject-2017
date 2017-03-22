namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PhotocourseViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<Photocourse>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

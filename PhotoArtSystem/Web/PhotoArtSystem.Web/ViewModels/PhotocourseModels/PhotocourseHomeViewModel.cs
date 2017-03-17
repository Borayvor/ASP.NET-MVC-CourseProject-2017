namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using Data.Models.PhotocourseModels;
    using Infrastructure.Mapping;

    public class PhotocourseHomeViewModel : BaseViewModel<Guid>, IMapFrom<Photocourse>
    {
        public string Name { get; set; }
    }
}

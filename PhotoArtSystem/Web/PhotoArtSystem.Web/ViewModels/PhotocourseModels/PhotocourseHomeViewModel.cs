namespace PhotoArtSystem.Web.ViewModels.PhotocourseModels
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PhotocourseHomeViewModel : BaseViewModel<Guid>, IMapFrom<Photocourse>
    {
        public string Name { get; set; }
    }
}

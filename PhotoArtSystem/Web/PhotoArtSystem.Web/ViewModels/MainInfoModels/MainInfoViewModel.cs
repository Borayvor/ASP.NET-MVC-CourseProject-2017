namespace PhotoArtSystem.Web.ViewModels.MainInfoModels
{
    using System;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class MainInfoViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<MainInfoTransitional>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
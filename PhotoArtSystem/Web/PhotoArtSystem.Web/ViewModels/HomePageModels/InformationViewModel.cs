namespace PhotoArtSystem.Web.ViewModels.HomePageModels
{
    using System;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class InformationViewModel : BaseDbKeyViewModel<Guid>, IMapFrom<InformationTransitional>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
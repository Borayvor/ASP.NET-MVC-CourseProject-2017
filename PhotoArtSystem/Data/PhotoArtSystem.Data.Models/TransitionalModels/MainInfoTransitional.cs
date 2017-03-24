namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using Models;
    using Web.Infrastructure.Mapping;

    public class MainInfoTransitional : BaseModelTransitional<Guid>,
        IMapFrom<MainInfo>, IMapTo<MainInfo>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

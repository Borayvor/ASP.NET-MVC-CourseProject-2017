namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using Models;
    using Web.Infrastructure.Mapping;

    public class InformationTransitional : BaseModelTransitional<Guid>,
        IMapFrom<Information>, IMapTo<Information>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

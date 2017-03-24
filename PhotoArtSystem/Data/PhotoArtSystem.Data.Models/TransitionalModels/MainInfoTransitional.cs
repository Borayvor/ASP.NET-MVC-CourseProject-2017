namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using Common.Models;
    using Models;
    using Web.Infrastructure.Mapping;

    public class MainInfoTransitional : BaseModelTransitional<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity,
        IMapFrom<MainInfo>, IMapTo<MainInfo>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

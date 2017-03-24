namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using Common.Models;
    using Models;
    using Web.Infrastructure.Mapping;

    public class ImageTransitional : FileInfoTransitional, IBaseModel<Guid>, IAuditInfo, IDeletableEntity,
        IMapFrom<Image>, IMapTo<Image>
    {
        public Guid PhotocourseId { get; set; }

        public PhotocourseTransitional Photocourse { get; set; }
    }
}

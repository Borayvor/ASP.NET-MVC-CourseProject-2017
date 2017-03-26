namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using Models;
    using Web.Infrastructure.Mapping;

    public class ImageTransitional : FileInfoTransitional,
        IMapFrom<Image>, IMapTo<Image>
    {
        public Guid? PhotocourseId { get; set; }

        public Photocourse Photocourse { get; set; }
    }
}

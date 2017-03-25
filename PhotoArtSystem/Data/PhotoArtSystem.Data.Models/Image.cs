namespace PhotoArtSystem.Data.Models
{
    using System;
    using Common.Models;

    public class Image : FileInfo, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public Guid PhotocourseId { get; set; }

        public virtual Photocourse Photocourse { get; set; }
    }
}

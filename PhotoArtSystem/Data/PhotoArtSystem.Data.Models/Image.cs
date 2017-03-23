namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using Contracts;

    [Table("Images")]
    public class Image : FileInfo, IImage, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public Guid PhotocourseId { get; set; }

        [InverseProperty("Images")]
        public virtual Photocourse Photocourse { get; set; }
    }
}

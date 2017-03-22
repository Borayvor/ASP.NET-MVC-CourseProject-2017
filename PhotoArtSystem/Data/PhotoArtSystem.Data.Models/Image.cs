namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    [Table("Images")]
    public class Image : FileInfo, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public Guid PhotocourseId { get; set; }

        [InverseProperty("Images")]
        public virtual Photocourse Photocourse { get; set; }
    }
}

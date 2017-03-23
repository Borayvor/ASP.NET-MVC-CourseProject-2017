namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class OriginalImage : FileInfo, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [NotMapped]
        public byte[] Content { get; set; }
    }
}

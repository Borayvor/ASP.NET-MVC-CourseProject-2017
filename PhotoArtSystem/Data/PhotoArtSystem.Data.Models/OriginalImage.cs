namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using Contracts;

    public class OriginalImage : FileInfo, IOriginalImage, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [NotMapped]
        public byte[] Content { get; set; }
    }
}

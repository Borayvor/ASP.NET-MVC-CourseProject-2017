namespace PhotoArtSystem.Services.Common.Models
{
    using System;
    using Data.Common.Models;

    public abstract class BaseModelModel<TKey> : IBaseModel<TKey>, IAuditInfo, IDeletableEntity
    {
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

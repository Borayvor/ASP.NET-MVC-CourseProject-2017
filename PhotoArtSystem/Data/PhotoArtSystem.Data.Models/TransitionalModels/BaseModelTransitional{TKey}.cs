namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using Common.Models;

    public abstract class BaseModelTransitional<TKey> : IBaseModel<TKey>, IAuditInfo, IDeletableEntity
    {
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

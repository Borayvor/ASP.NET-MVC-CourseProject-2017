namespace PhotoArtSystem.Web.ViewModels
{
    using System;

    public abstract class BaseInfoViewModel<TKey> : BaseCreatedOnViewModel<TKey>
    {
        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

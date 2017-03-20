namespace PhotoArtSystem.Web.ViewModels
{
    using System;

    public abstract class BaseInfoViewModel<T> : BaseCreatedOnViewModel<T>
    {
        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

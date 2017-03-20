namespace PhotoArtSystem.Web.ViewModels
{
    using System;

    public abstract class BaseCreatedOnViewModel<T> : BaseDbKeyViewModel<T>
    {
        public DateTime CreatedOn { get; set; }
    }
}

namespace PhotoArtSystem.Web.ViewModels
{
    using System;

    public abstract class BaseCreatedOnViewModel<TKey> : BaseDbKeyViewModel<TKey>
    {
        public DateTime CreatedOn { get; set; }
    }
}

namespace PhotoArtSystem.Web.ViewModels
{
    using System.Web.Mvc;

    public abstract class BaseDbKeyViewModel<TKey>
    {
        [HiddenInput(DisplayValue = false)]
        public TKey Id { get; set; }
    }
}

namespace PhotoArtSystem.Web.ViewModels
{
    using System.Web.Mvc;

    public abstract class BaseDbKeyViewModel<T>
    {
        [HiddenInput(DisplayValue = false)]
        public T Id { get; set; }
    }
}

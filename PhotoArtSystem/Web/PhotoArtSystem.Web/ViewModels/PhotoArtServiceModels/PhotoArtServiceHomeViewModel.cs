namespace PhotoArtSystem.Web.ViewModels.PhotoArtServiceModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class PhotoArtServiceHomeViewModel : BaseViewModel<int>, IMapFrom<PhotoArtService>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

namespace PhotoArtSystem.Services.Data.Contracts
{
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IMultimediaService :
        IMultimediaGetService,
        IBaseCreateService<MultimediaTransitional>,
        IBaseUpdateService<MultimediaTransitional>,
        IBaseDeleteService<MultimediaTransitional>
    {
    }
}

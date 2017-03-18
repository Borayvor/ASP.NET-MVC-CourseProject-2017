namespace PhotoArtSystem.Services.PhotoArtServices.Contracts
{
    using Common.Contracts;
    using Data.Models;

    public interface IPhotoArtServiceService : IBaseCreateService<PhotoArtService>,
        IBaseGetService<PhotoArtService, int>,
        IBaseUpdateService<PhotoArtService>,
        IBaseDeleteService<PhotoArtService>
    {
    }
}

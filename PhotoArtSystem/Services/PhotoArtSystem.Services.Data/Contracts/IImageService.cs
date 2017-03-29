namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IImageService : IBaseCreateService<ImageTransitional>,
        IBaseGetService<ImageTransitional, Guid>,
        IBaseUpdateService<ImageTransitional>,
        IBaseDeleteService<ImageTransitional>
    {
    }
}

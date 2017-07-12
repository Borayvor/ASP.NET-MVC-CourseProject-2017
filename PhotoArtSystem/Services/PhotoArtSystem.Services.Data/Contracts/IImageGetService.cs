namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IImageGetService : IBaseGetService<ImageTransitional, Guid>
    {
    }
}

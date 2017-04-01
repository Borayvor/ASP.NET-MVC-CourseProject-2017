namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IImageService : IBaseCreateService<ImageTransitional>,
        IBaseGetService<ImageTransitional, Guid>,
        IBaseUpdateService<ImageTransitional>,
        IBaseDeleteService<ImageTransitional>
    {
        Task<ICollection<Image>> Create(IEnumerable<ImageTransitional> entities);
    }
}

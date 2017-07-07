namespace PhotoArtSystem.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.EnumTypes;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IImageService :
        IImageGetService,
        IBaseUpdateService<ImageTransitional>,
        IBaseDeleteService<ImageTransitional>
    {
        Task<Image> Create(ImageTransitional entity, ImageFormatType format);

        Task<IEnumerable<Image>> Create(IEnumerable<ImageTransitional> entities, ImageFormatType format);
    }
}

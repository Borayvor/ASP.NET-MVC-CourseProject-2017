namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IPhotocourseService :
        IBaseGetService<PhotocourseTransitional, Guid>,
        IBaseUpdateService<PhotocourseTransitional>,
        IBaseDeleteService<PhotocourseTransitional>
    {
        Photocourse Create(PhotocourseTransitional entity);
    }
}

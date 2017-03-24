namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IPhotocourseService : IBaseCreateService<PhotocourseTransitional>,
        IBaseGetService<PhotocourseTransitional, Guid>,
        IBaseUpdateService<PhotocourseTransitional>,
        IBaseDeleteService<PhotocourseTransitional>
    {
    }
}

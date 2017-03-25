namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IMainInfoService : IBaseCreateService<MainInfoTransitional>,
        IBaseGetService<MainInfoTransitional, Guid>,
        IBaseUpdateService<MainInfoTransitional>,
        IBaseDeleteService<MainInfoTransitional>
    {
    }
}

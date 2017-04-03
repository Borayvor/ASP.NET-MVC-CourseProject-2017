namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IInformationService : IBaseCreateService<InformationTransitional>,
        IBaseGetService<InformationTransitional, Guid>,
        IBaseUpdateService<InformationTransitional>,
        IBaseDeleteService<InformationTransitional>
    {
    }
}

namespace PhotoArtSystem.Services.Data.Contracts
{
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IInformationService :
        IInformationGetService,
        IBaseCreateService<InformationTransitional>,
        IBaseUpdateService<InformationTransitional>,
        IBaseDeleteService<InformationTransitional>
    {
    }
}

namespace PhotoArtSystem.Services.Web.Contracts
{
    public interface IAutoMapperService
    {
        TDestination Map<TDestination>(object source);
    }
}

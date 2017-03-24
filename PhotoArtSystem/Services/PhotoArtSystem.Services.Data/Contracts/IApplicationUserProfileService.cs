namespace PhotoArtSystem.Services.Data.Contracts
{
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IApplicationUserProfileService : IBaseGetService<ApplicationUserTransitional, string>
    {
    }
}

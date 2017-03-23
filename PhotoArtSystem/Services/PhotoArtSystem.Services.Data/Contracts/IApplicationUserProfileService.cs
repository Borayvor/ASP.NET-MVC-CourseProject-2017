namespace PhotoArtSystem.Services.Data.Contracts
{
    using Common.Contracts;
    using PhotoArtSystem.Data.Models;

    public interface IApplicationUserProfileService : IBaseGetService<ApplicationUser, string>
    {
    }
}

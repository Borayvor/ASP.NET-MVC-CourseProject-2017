namespace PhotoArtSystem.Services.Data.Contracts
{
    using Common.Contracts;
    using Common.Models;
    using PhotoArtSystem.Data.Models;

    public interface IApplicationUserProfileService : IBaseGetService<ApplicationUser, string, ApplicationUserModel>
    {
    }
}

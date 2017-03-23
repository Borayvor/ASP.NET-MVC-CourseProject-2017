namespace PhotoArtSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Contracts;
    using Contracts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;

    public class ApplicationUserProfileService : IApplicationUserProfileService,
        IBaseGetService<ApplicationUser, string>
    {
        private readonly IPhotoArtSystemEfDbRepository<ApplicationUser> users;

        public ApplicationUserProfileService(IPhotoArtSystemEfDbRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return this.users.GetAll().OrderByDescending(x => x.CreatedOn).ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}

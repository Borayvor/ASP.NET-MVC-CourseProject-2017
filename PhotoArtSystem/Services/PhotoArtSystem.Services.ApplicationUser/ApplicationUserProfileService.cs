namespace PhotoArtSystem.Services.ApplicationUser
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Contracts;
    using Contracts;
    using Data.Common.Repositories;
    using Data.Models;

    public class ApplicationUserProfileService : IApplicationUserProfileService,
        IBaseGetService<ApplicationUser, string>
    {
        private readonly IEfDbRepository<ApplicationUser> users;

        public ApplicationUserProfileService(IEfDbRepository<ApplicationUser> users)
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

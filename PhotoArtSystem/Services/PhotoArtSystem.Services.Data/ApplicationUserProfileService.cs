namespace PhotoArtSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using Web.Contracts;

    public class ApplicationUserProfileService : IApplicationUserProfileService
    {
        private readonly IAutoMapperService mapper;
        private readonly IPhotoArtSystemEfDbRepository<ApplicationUser> users;

        public ApplicationUserProfileService(IAutoMapperService mapper, IPhotoArtSystemEfDbRepository<ApplicationUser> users)
        {
            this.mapper = mapper;
            this.users = users;
        }

        public IEnumerable<ApplicationUserTransitional> GetAll()
        {
            var users = this.users.GetAll().OrderByDescending(x => x.CreatedOn);

            return this.mapper.Map<IEnumerable<ApplicationUserTransitional>>(users);
        }

        public ApplicationUserTransitional GetById(string id)
        {
            var user = this.users.GetById(id);

            return this.mapper.Map<ApplicationUserTransitional>(user);
        }
    }
}

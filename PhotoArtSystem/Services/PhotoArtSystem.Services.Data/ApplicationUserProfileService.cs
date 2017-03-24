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
            var applicationUsers = this.users.GetAll().ToList();
            var result = this.mapper.Map<IEnumerable<ApplicationUserTransitional>>(applicationUsers);

            return result;
        }

        public ApplicationUserTransitional GetById(string id)
        {
            var applicationUser = this.users.GetById(id);
            var result = this.mapper.Map<ApplicationUserTransitional>(applicationUser);

            return result;
        }
    }
}

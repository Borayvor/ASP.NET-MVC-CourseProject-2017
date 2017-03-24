namespace PhotoArtSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public class ApplicationUserProfileService : IApplicationUserProfileService
    {
        private readonly IMapper mapper;
        private readonly IPhotoArtSystemEfDbRepository<ApplicationUser> users;

        public ApplicationUserProfileService(IMapper mapper, IPhotoArtSystemEfDbRepository<ApplicationUser> users)
        {
            this.mapper = mapper;
            this.users = users;
        }

        public IEnumerable<ApplicationUserTransitional> GetAll()
        {
            var result = this.users
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .ProjectTo<ApplicationUserTransitional>(this.mapper.ConfigurationProvider)
                .ToList();

            return result;
        }

        public ApplicationUserTransitional GetById(string id)
        {
            var result = this.users
                .GetAll()
                .ProjectTo<ApplicationUserTransitional>(this.mapper.ConfigurationProvider)
                .FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}

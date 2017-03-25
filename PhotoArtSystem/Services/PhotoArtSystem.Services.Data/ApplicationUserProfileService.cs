namespace PhotoArtSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using Common.Constants;
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
            Guard.WhenArgument(
                mapper,
                GlobalConstants.MapperRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                 users,
                 GlobalConstants.EfDbRepositoryApplicationUserRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
            this.users = users;
        }

        public IEnumerable<ApplicationUserTransitional> GetAll()
        {
            var entityDbList = this.users.GetAll().ToList();
            var result = this.mapper.Map<IEnumerable<ApplicationUserTransitional>>(entityDbList);

            return result;
        }

        public ApplicationUserTransitional GetById(string id)
        {
            var entityDb = this.users.GetById(id);
            var result = this.mapper.Map<ApplicationUserTransitional>(entityDb);

            return result;
        }
    }
}

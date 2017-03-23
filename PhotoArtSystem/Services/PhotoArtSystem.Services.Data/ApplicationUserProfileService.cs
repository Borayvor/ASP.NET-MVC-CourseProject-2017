namespace PhotoArtSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;
    using Contracts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Web.Infrastructure.Mapping;
    using Web.Contracts;

    public class ApplicationUserProfileService : BaseService, IApplicationUserProfileService
    {
        private readonly IPhotoArtSystemEfDbRepository<ApplicationUser> users;

        public ApplicationUserProfileService(IAutoMapperService mapper, IPhotoArtSystemEfDbRepository<ApplicationUser> users)
             : base(mapper)
        {
            this.users = users;
        }

        public IEnumerable<ApplicationUserModel> GetAll()
        {
            return this.users.GetAll().OrderByDescending(x => x.CreatedOn).To<ApplicationUserModel>().ToList();
        }

        public ApplicationUserModel GetById(string id)
        {
            var user = this.users.GetById(id);

            return this.Mapper.Map<ApplicationUserModel>(user);
        }
    }
}

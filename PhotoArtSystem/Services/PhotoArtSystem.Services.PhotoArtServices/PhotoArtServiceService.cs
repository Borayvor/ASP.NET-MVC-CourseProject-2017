namespace PhotoArtSystem.Services.PhotoArtServices
{
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using Contracts;
    using Data.Common.EfDbContexts;
    using Data.Common.Repositories;
    using Data.Models;
    using PhotoArtSystem.Common.Constants;

    public class PhotoArtServiceService : IPhotoArtServiceService
    {
        private readonly IEfDbRepository<PhotoArtService> photoArtServicesRepo;
        private readonly IEfDbContext context;

        public PhotoArtServiceService(IEfDbContext context, IEfDbRepository<PhotoArtService> photoArtServicesRepo)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                photoArtServicesRepo,
                GlobalConstants.EfDbRepositoryPhotoArtServiceRequiredExceptionMessage).IsNull().Throw();

            this.photoArtServicesRepo = photoArtServicesRepo;
            this.context = context;
        }

        public IEnumerable<PhotoArtService> GetAll()
        {
            return this.photoArtServicesRepo.GetAll().OrderByDescending(x => x.CreatedOn).ToList();
        }

        public PhotoArtService GetById(int id)
        {
            return this.photoArtServicesRepo.GetById(id);
        }

        public void Create(PhotoArtService entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotoArtServiceRequiredExceptionMessage).IsNull().Throw();

            this.photoArtServicesRepo.Create(entity);
            this.context.Save();
        }

        public void Update(PhotoArtService entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotoArtServiceRequiredExceptionMessage).IsNull().Throw();

            this.photoArtServicesRepo.Update(entity);
            this.context.Save();
        }

        public void Delete(PhotoArtService entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotoArtServiceRequiredExceptionMessage).IsNull().Throw();

            this.photoArtServicesRepo.Delete(entity);
            this.context.Save();
        }
    }
}

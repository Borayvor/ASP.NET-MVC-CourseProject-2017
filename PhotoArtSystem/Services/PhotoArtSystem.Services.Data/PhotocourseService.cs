namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using Contracts;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IPhotoArtSystemEfDbRepository<Photocourse> photocourses;
        private readonly IEfDbContextSaveChanges context;

        public PhotocourseService(IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Photocourse> photocourses)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                photocourses,
                GlobalConstants.EfDbRepositoryPhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.photocourses = photocourses;
            this.context = context;
        }

        public IEnumerable<Photocourse> GetAll()
        {
            return this.photocourses.GetAll().OrderByDescending(x => x.CreatedOn).ToList();
        }

        public Photocourse GetById(Guid id)
        {
            return this.photocourses.GetById(id);
        }

        public void Create(Photocourse entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.photocourses.Create(entity);
            this.context.Save();
        }

        public void Update(Photocourse entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.photocourses.Update(entity);
            this.context.Save();
        }

        public void Delete(Photocourse entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.photocourses.Delete(entity);
            this.context.Save();
        }
    }
}

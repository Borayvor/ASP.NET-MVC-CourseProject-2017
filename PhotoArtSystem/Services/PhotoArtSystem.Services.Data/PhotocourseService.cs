namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using Common.Constants;
    using Contracts;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using Web.Contracts;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IAutoMapperService mapper;
        private readonly IPhotoArtSystemEfDbRepository<Photocourse> photocourses;
        private readonly IEfDbContextSaveChanges context;

        public PhotocourseService(IAutoMapperService mapper, IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Photocourse> photocourses)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                photocourses,
                GlobalConstants.EfDbRepositoryPhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
            this.photocourses = photocourses;
            this.context = context;
        }

        public IEnumerable<PhotocourseTransitional> GetAll()
        {
            var photocources = this.photocourses.GetAll().OrderByDescending(x => x.CreatedOn);

            return this.mapper.Map<IEnumerable<PhotocourseTransitional>>(photocources);
        }

        public PhotocourseTransitional GetById(Guid id)
        {
            var photocourse = this.photocourses.GetById(id);

            return this.mapper.Map<PhotocourseTransitional>(photocourse);
        }

        public void Create(PhotocourseTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            var photocourse = this.mapper.Map<Photocourse>(entity);

            this.photocourses.Create(photocourse);
            this.context.Save();
        }

        public void Update(PhotocourseTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            var photocourse = this.mapper.Map<Photocourse>(entity);

            this.photocourses.Update(photocourse);
            this.context.Save();
        }

        public void Delete(PhotocourseTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            var photocourse = this.mapper.Map<Photocourse>(entity);

            this.photocourses.Delete(photocourse);
            this.context.Save();
        }
    }
}

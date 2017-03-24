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
                mapper,
                GlobalConstants.MapperRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                photocourses,
                GlobalConstants.EfDbRepositoryPhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
            this.context = context;
            this.photocourses = photocourses;
        }

        public IEnumerable<PhotocourseTransitional> GetAll()
        {
            var photocoursesAll = this.photocourses.GetAll().ToList();
            var result = this.mapper.Map<IEnumerable<PhotocourseTransitional>>(photocoursesAll);

            return result;
        }

        public PhotocourseTransitional GetById(Guid id)
        {
            var photocourse = this.photocourses.GetById(id);
            var result = this.mapper.Map<PhotocourseTransitional>(photocourse);

            return result;
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

namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Bytes2you.Validation;
    using Common.Constants;
    using Contracts;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IMapper mapper;
        private readonly IPhotoArtSystemEfDbRepository<Photocourse> photocourses;
        private readonly IEfDbContextSaveChanges context;

        public PhotocourseService(IMapper mapper, IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Photocourse> photocourses)
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
            var result = this.photocourses
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .ProjectTo<PhotocourseTransitional>(this.mapper.ConfigurationProvider)
                .ToList();

            return result;
        }

        public PhotocourseTransitional GetById(Guid id)
        {
            var result = this.photocourses
                .GetAll()
                .ProjectTo<PhotocourseTransitional>(this.mapper.ConfigurationProvider)
                .FirstOrDefault(x => x.Id == id);

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

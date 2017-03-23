namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using Common;
    using Common.Models;
    using Contracts;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Web.Infrastructure.Mapping;
    using Web.Contracts;

    public class PhotocourseService : BaseService, IPhotocourseService
    {
        private readonly IPhotoArtSystemEfDbRepository<Photocourse> photocourses;
        private readonly IEfDbContextSaveChanges context;

        public PhotocourseService(IAutoMapperService mapper, IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Photocourse> photocourses)
            : base(mapper)
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

        public IEnumerable<PhotocourseModel> GetAll()
        {
            return this.photocourses.GetAll().OrderByDescending(x => x.CreatedOn).To<PhotocourseModel>().ToList();
        }

        public PhotocourseModel GetById(Guid id)
        {
            var photocourse = this.photocourses.GetById(id);

            return this.Mapper.Map<PhotocourseModel>(photocourse);
        }

        public void Create(PhotocourseModel entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            var photocourse = this.Mapper.Map<Photocourse>(entity);

            this.photocourses.Create(photocourse);
            this.context.Save();
        }

        public void Update(PhotocourseModel entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            var photocourse = this.Mapper.Map<Photocourse>(entity);

            this.photocourses.Update(photocourse);
            this.context.Save();
        }

        public void Delete(PhotocourseModel entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            var photocourse = this.Mapper.Map<Photocourse>(entity);

            this.photocourses.Delete(photocourse);
            this.context.Save();
        }
    }
}

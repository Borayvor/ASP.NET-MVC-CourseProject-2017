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
    using PhotoArtSystem.Data.Models.Factories;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Web.Infrastructure.Sanitizer;
    using Web.Contracts;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IModelDbFactory modelDbFactory;
        private readonly ISanitizer sanitizer;
        private readonly IAutoMapperService mapper;
        private readonly IEfDbContextSaveChanges context;
        private readonly IPhotoArtSystemEfDbRepository<Photocourse> photocourses;

        public PhotocourseService(
            IModelDbFactory modelDbFactory,
            ISanitizer sanitizer,
            IAutoMapperService mapper,
            IEfDbContextSaveChanges context,
            IPhotoArtSystemEfDbRepository<Photocourse> photocourses)
        {
            Guard.WhenArgument(
                modelDbFactory,
                GlobalConstants.ModelDbFactoryRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
               sanitizer,
               GlobalConstants.SanitizerRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                mapper,
                GlobalConstants.AutoMapperServiceRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                photocourses,
                GlobalConstants.PhotocourseEfDbRepositoryRequiredExceptionMessage).IsNull().Throw();

            this.modelDbFactory = modelDbFactory;
            this.sanitizer = sanitizer;
            this.mapper = mapper;
            this.context = context;
            this.photocourses = photocourses;
        }

        public IEnumerable<PhotocourseTransitional> GetAll()
        {
            var entityDbList = this.photocourses.GetAll().OrderBy(x => x.CreatedOn).ToList();
            var result = this.mapper.Map<IEnumerable<PhotocourseTransitional>>(entityDbList);

            return result;
        }

        public PhotocourseTransitional GetById(Guid id)
        {
            var entityDb = this.photocourses.GetById(id);
            var result = this.mapper.Map<PhotocourseTransitional>(entityDb);

            return result;
        }

        public Photocourse Create(PhotocourseTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseTransitionalRequiredExceptionMessage)
                .IsNull()
                .Throw();

            entity.Description = this.sanitizer.Sanitize(entity.Description);
            entity.DescriptionShort = this.sanitizer.Sanitize(entity.DescriptionShort);
            entity.OtherInfo = this.sanitizer.Sanitize(entity.OtherInfo);

            var entityImages = entity.Images as ICollection<Image>;
            var entityStudents = entity.Students as ICollection<Student>;

            Photocourse entityDb = this.modelDbFactory.CreatePhotocourse(
                entity.Name,
                entity.DescriptionShort,
                entity.Description,
                entity.OtherInfo,
                entity.Teacher,
                entity.DurationHours,
                entity.MaxStudents,
                entity.StartDate,
                entity.EndDate,
                entity.ImageCoverId,
                entity.ImageCover,
                entityImages,
                entityStudents);

            this.photocourses.Create(entityDb);
            this.context.Save();

            return entityDb;
        }

        public void Update(PhotocourseTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<Photocourse>(entity);

            this.photocourses.Update(entityDb);
            this.context.Save();
        }

        public void Delete(PhotocourseTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<Photocourse>(entity);

            this.photocourses.Delete(entityDb);
            this.context.Save();
        }
    }
}

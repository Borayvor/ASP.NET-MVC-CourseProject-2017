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
    using PhotoArtSystem.Web.Infrastructure.Sanitizer;
    using Web.Contracts;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly ISanitizer sanitizer;
        private readonly IAutoMapperService mapper;
        private readonly IEfDbContextSaveChanges context;
        private readonly IPhotoArtSystemEfDbRepository<Photocourse> photocourses;

        public PhotocourseService(ISanitizer sanitizer, IAutoMapperService mapper, IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Photocourse> photocourses)
        {
            Guard.WhenArgument(
               sanitizer,
               nameof(sanitizer)).IsNull().Throw();
            Guard.WhenArgument(
                mapper,
                GlobalConstants.AutoMapperServiceRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                photocourses,
                GlobalConstants.EfDbRepositoryPhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.sanitizer = sanitizer;
            this.mapper = mapper;
            this.context = context;
            this.photocourses = photocourses;
        }

        public IEnumerable<PhotocourseTransitional> GetAll()
        {
            var entityDbList = this.photocourses.GetAll().ToList();
            var result = this.mapper.Map<IEnumerable<PhotocourseTransitional>>(entityDbList);

            return result;
        }

        public PhotocourseTransitional GetById(Guid id)
        {
            var entityDb = this.photocourses.GetById(id);
            var result = this.mapper.Map<PhotocourseTransitional>(entityDb);

            return result;
        }

        public void Create(PhotocourseTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseTransitionalRequiredExceptionMessage)
                .IsNull()
                .Throw();

            entity.Description = this.sanitizer.Sanitize(entity.Description);
            entity.DescriptionShort = this.sanitizer.Sanitize(entity.DescriptionShort);
            entity.OtherInfo = this.sanitizer.Sanitize(entity.OtherInfo);

            ////var entityDb = this.mapper.Map<Photocourse>(entity);

            var entityDb = new Photocourse
            {
                Name = entity.Name,
                DescriptionShort = entity.DescriptionShort,
                Description = entity.Description,
                OtherInfo = entity.OtherInfo,
                DurationHours = entity.DurationHours,
                MaxStudents = entity.MaxStudents,
                Teacher = entity.Teacher,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Images = entity.Images.ToList(),
                MainImageId = entity.Images.FirstOrDefault().Id,
                Students = new List<Student>()
            };

            this.photocourses.Create(entityDb);
            this.context.Save();
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

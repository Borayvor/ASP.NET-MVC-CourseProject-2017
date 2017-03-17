namespace PhotoArtSystem.Services.Photocourses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using Contracts;
    using Data.Common.EfDbContexts;
    using Data.Common.Repositories;
    using Data.Models.PhotocourseModels;
    using PhotoArtSystem.Common.Constants;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IEfDbRepository<Photocourse> photocourses;
        private readonly IEfDbContext context;

        public PhotocourseService(IEfDbContext context, IEfDbRepository<Photocourse> photocourses)
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

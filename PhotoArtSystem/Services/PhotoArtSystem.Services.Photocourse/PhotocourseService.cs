namespace PhotoArtSystem.Services.Photocourse
{
    using System;
    using System.Linq;
    using Bytes2you.Validation;
    using Contracts;
    using Data.Common.EfDbContexts;
    using Data.Common.Repositories;
    using Data.Models.Contracts;
    using PhotoArtSystem.Common.Constants;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IEfDbRepository<IPhotocourse> photocourses;
        private readonly IEfDbContext context;

        public PhotocourseService(IEfDbContext context, IEfDbRepository<IPhotocourse> photocourses)
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

        public IQueryable<IPhotocourse> GetAll()
        {
            return this.photocourses.GetAll().OrderByDescending(x => x.CreatedOn);
        }

        public IPhotocourse GetById(Guid id)
        {
            return this.photocourses.GetById(id);
        }

        public void Create(IPhotocourse entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.photocourses.Create(entity);
            this.context.Save();
        }

        public void Update(IPhotocourse entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.photocourses.Update(entity);
            this.context.Save();
        }

        public void Delete(IPhotocourse entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.PhotocourseRequiredExceptionMessage).IsNull().Throw();

            this.photocourses.Delete(entity);
            this.context.Save();
        }
    }
}

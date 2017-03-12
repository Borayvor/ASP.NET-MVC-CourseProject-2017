namespace PhotoArtSystem.Services.Photocourse
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Common.EfDbContexts;
    using Data.Common.Repositories;
    using Data.Models;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IEfDbRepository<Photocourse> photocourses;
        private readonly IEfDbContext context;

        public PhotocourseService(IEfDbContext context, IEfDbRepository<Photocourse> photocourses)
        {
            this.photocourses = photocourses;
            this.context = context;
        }

        public IQueryable<Photocourse> GetAll()
        {
            return this.photocourses.All().OrderByDescending(x => x.CreatedOn);
        }

        public Photocourse GetById(Guid id)
        {
            return this.photocourses.GetById(id);
        }

        public void Create(Photocourse entity)
        {
            this.photocourses.Create(entity);
            this.context.Save();
        }

        public void Update(Photocourse entity)
        {
            this.photocourses.Update(entity);
            this.context.Save();
        }

        public void Delete(Photocourse entity)
        {
            this.photocourses.Delete(entity);
            this.context.Save();
        }
    }
}

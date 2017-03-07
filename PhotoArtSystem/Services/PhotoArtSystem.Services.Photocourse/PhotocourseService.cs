namespace PhotoArtSystem.Services.Photocourse
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Common.Repositories;
    using Data.Models;

    public class PhotocourseService : IPhotocourseService
    {
        private readonly IDbRepository<Photocourse> photocourses;

        public PhotocourseService(IDbRepository<Photocourse> photocourses)
        {
            this.photocourses = photocourses;
        }

        public void Create(Photocourse entity)
        {
            this.photocourses.Create(entity);
        }

        public IQueryable<Photocourse> GetAll()
        {
            return this.photocourses.All();
        }

        public Photocourse GetById(Guid id)
        {
            return this.photocourses.GetById(id);
        }

        public void Update(Photocourse entity)
        {
            this.photocourses.Update(entity);
        }

        public void Delete(Photocourse entity)
        {
            this.photocourses.Delete(entity);
        }
    }
}

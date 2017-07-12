namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using Contracts;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using Web.Contracts;

    public class StudentService : IStudentService
    {
        private readonly IAutoMapperService mapper;
        private readonly IEfDbContextSaveChanges context;
        private readonly IPhotoArtSystemEfDbRepository<Student> students;

        public StudentService(IAutoMapperService mapper, IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Student> students)
        {
            Guard.WhenArgument(
                mapper,
                GlobalConstants.AutoMapperServiceRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                students,
                GlobalConstants.StudentEfDbRepositoryRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
            this.context = context;
            this.students = students;
        }

        public IEnumerable<StudentTransitional> GetAll()
        {
            var entityDbList = this.students.GetAll().OrderBy(x => x.CreatedOn).ToList();
            var result = this.mapper.Map<IEnumerable<StudentTransitional>>(entityDbList);

            return result;
        }

        public StudentTransitional GetById(Guid id)
        {
            var entityDb = this.students.GetById(id);
            var result = this.mapper.Map<StudentTransitional>(entityDb);

            return result;
        }

        public void Create(StudentTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<Student>(entity);

            this.students.Create(entityDb);
            this.context.Save();
        }

        public void Update(StudentTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<Student>(entity);

            this.students.Update(entityDb);
            this.context.Save();
        }

        public void Delete(StudentTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<Student>(entity);

            this.students.Delete(entityDb);
            this.context.Save();
        }
    }
}

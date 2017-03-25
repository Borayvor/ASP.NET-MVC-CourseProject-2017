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
        private readonly IPhotoArtSystemEfDbRepository<Student> students;
        private readonly IEfDbContextSaveChanges context;

        public StudentService(IAutoMapperService mapper, IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Student> students)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                students,
                GlobalConstants.EfDbRepositoryStudentRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
            this.students = students;
            this.context = context;
        }

        public IEnumerable<StudentTransitional> GetAll()
        {
            var studentsAll = this.students.GetAll().ToList();
            var result = this.mapper.Map<IEnumerable<StudentTransitional>>(studentsAll);

            return result;
        }

        public StudentTransitional GetById(Guid id)
        {
            var student = this.students.GetById(id);
            var result = this.mapper.Map<StudentTransitional>(student);

            return result;
        }

        public void Create(StudentTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            var student = this.mapper.Map<Student>(entity);

            this.students.Create(student);
            this.context.Save();
        }

        public void Update(StudentTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            var student = this.mapper.Map<Student>(entity);

            this.students.Update(student);
            this.context.Save();
        }

        public void Delete(StudentTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            var student = this.mapper.Map<Student>(entity);

            this.students.Delete(student);
            this.context.Save();
        }
    }
}

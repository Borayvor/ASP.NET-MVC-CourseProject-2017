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

    public class StudentService : IStudentService
    {
        private readonly IPhotoArtSystemEfDbRepository<Student> students;
        private readonly IEfDbContextSaveChanges context;

        public StudentService(IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Student> students)
        {
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                students,
                GlobalConstants.EfDbRepositoryStudentRequiredExceptionMessage).IsNull().Throw();

            this.students = students;
            this.context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return this.students.GetAll().OrderByDescending(x => x.CreatedOn).ToList();
        }

        public Student GetById(Guid id)
        {
            return this.students.GetById(id);
        }

        public void Create(Student entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            this.students.Create(entity);
            this.context.Save();
        }

        public void Update(Student entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            this.students.Update(entity);
            this.context.Save();
        }

        public void Delete(Student entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            this.students.Delete(entity);
            this.context.Save();
        }
    }
}

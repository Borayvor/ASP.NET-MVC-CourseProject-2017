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

    public class StudentService : BaseService, IStudentService
    {
        private readonly IPhotoArtSystemEfDbRepository<Student> students;
        private readonly IEfDbContextSaveChanges context;

        public StudentService(IAutoMapperService mapper, IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<Student> students)
            : base(mapper)
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

        public IEnumerable<StudentModel> GetAll()
        {
            return this.students.GetAll().OrderByDescending(x => x.CreatedOn).To<StudentModel>().ToList();
        }

        public StudentModel GetById(Guid id)
        {
            var student = this.students.GetById(id);

            return this.Mapper.Map<StudentModel>(student);
        }

        public void Create(StudentModel entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            var student = this.Mapper.Map<Student>(entity);

            this.students.Create(student);
            this.context.Save();
        }

        public void Update(StudentModel entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            var student = this.Mapper.Map<Student>(entity);

            this.students.Update(student);
            this.context.Save();
        }

        public void Delete(StudentModel entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.StudentServiceRequiredExceptionMessage).IsNull().Throw();

            var student = this.Mapper.Map<Student>(entity);

            this.students.Delete(student);
            this.context.Save();
        }
    }
}

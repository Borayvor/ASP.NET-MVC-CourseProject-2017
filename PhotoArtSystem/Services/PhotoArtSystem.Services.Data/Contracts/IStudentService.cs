namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using Common.Contracts;
    using Common.Models;
    using PhotoArtSystem.Data.Models;

    public interface IStudentService : IBaseCreateService<Student, StudentModel>,
        IBaseGetService<Student, Guid, StudentModel>,
        IBaseUpdateService<Student, StudentModel>,
        IBaseDeleteService<Student, StudentModel>
    {
    }
}

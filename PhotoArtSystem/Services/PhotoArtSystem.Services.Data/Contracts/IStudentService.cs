namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using Common.Contracts;
    using PhotoArtSystem.Data.Models;

    public interface IStudentService : IBaseCreateService<Student>,
        IBaseGetService<Student, Guid>,
        IBaseUpdateService<Student>,
        IBaseDeleteService<Student>
    {
    }
}

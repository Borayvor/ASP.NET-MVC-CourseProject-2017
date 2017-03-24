namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IStudentService : IBaseCreateService<StudentTransitional>,
        IBaseGetService<StudentTransitional, Guid>,
        IBaseUpdateService<StudentTransitional>,
        IBaseDeleteService<StudentTransitional>
    {
    }
}

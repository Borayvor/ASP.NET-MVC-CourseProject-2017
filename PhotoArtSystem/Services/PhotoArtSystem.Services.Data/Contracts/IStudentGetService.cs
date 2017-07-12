namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IStudentGetService : IBaseGetService<StudentTransitional, Guid>
    {
    }
}

namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IPhotocourseGetService : IBaseGetService<PhotocourseTransitional, Guid>
    {
    }
}

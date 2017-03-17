namespace PhotoArtSystem.Services.Photocourses.Contracts
{
    using System;
    using Common.Contracts;
    using Data.Models.PhotocourseModels;

    public interface IPhotocourseService : IBaseCreateService<Photocourse>,
        IBaseGetService<Photocourse, Guid>,
        IBaseUpdateService<Photocourse>,
        IBaseDeleteService<Photocourse>
    {
    }
}

namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using Common.Contracts;
    using Common.Models;
    using PhotoArtSystem.Data.Models;

    public interface IPhotocourseService : IBaseCreateService<Photocourse, PhotocourseModel>,
        IBaseGetService<Photocourse, Guid, PhotocourseModel>,
        IBaseUpdateService<Photocourse, PhotocourseModel>,
        IBaseDeleteService<Photocourse, PhotocourseModel>
    {
    }
}

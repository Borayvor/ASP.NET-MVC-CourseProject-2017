namespace PhotoArtSystem.Services.Data.Contracts
{
    using System;
    using Common.Contracts;
    using PhotoArtSystem.Data.Models;

    public interface IPhotocourseService : IBaseCreateService<Photocourse>,
        IBaseGetService<Photocourse, Guid>,
        IBaseUpdateService<Photocourse>,
        IBaseDeleteService<Photocourse>
    {
    }
}

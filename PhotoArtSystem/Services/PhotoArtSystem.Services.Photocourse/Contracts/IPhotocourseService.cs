namespace PhotoArtSystem.Services.Photocourse.Contracts
{
    using System;
    using Common.Contracts;
    using Data.Models.Contracts;

    public interface IPhotocourseService : IBaseCreateService<IPhotocourse>,
        IBaseGetService<IPhotocourse, Guid>,
        IBaseUpdateService<IPhotocourse>,
        IBaseDeleteService<IPhotocourse>
    {
    }
}

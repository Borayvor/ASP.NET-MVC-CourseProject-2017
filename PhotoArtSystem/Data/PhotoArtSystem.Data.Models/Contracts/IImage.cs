namespace PhotoArtSystem.Data.Models.Contracts
{
    using System;
    using Common.Models;

    public interface IImage : IFileInfo, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        Guid PhotocourseId { get; set; }

        Photocourse Photocourse { get; set; }
    }
}

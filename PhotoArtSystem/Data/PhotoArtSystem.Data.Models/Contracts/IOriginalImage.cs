namespace PhotoArtSystem.Data.Models.Contracts
{
    using System;
    using Common.Models;

    public interface IOriginalImage : IFileInfo, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        byte[] Content { get; set; }
    }
}

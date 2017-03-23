namespace PhotoArtSystem.Data.Models.Contracts
{
    using System;
    using Common.Models;

    public interface IMainInfo : IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        string Title { get; set; }

        string Description { get; set; }
    }
}

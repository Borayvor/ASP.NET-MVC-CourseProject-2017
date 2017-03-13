namespace PhotoArtSystem.Data.Models.Contracts
{
    using System;
    using Common.Models;

    public interface IPhotocourse : IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        string Name { get; set; }
    }
}
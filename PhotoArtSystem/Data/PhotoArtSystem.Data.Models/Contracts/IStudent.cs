namespace PhotoArtSystem.Data.Models.Contracts
{
    using System;
    using Common.Models;

    public interface IStudent : IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        string FirstName { get; set; }

        string MiddleName { get; set; }

        string LastName { get; set; }

        Guid PhotocourseId { get; set; }

        Photocourse Photocourse { get; set; }
    }
}

namespace PhotoArtSystem.Data.Models.Contracts
{
    using System;
    using System.Collections.Generic;
    using Common.Models;

    public interface IPhotocourse : IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        string Name { get; set; }

        string DescriptionShort { get; set; }

        string Description { get; set; }

        string OtherInfo { get; set; }

        ushort DurationHours { get; set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        string Teacher { get; set; }

        ICollection<Image> Images { get; set; }

        ICollection<Student> Students { get; set; }
    }
}

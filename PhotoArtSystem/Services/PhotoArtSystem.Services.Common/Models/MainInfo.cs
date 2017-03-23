namespace PhotoArtSystem.Services.Common.Models
{
    using System;
    using Data.Common.Models;

    public class MainInfo : BaseModelModel<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

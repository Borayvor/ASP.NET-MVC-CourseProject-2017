namespace PhotoArtSystem.Services.Common.Models
{
    using System;
    using Data.Common.Models;

    public class ImageModel : FileInfoModel, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public PhotocourseModel Photocourse { get; set; }
    }
}

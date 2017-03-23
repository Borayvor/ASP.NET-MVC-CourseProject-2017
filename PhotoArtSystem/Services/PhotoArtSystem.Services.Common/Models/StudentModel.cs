namespace PhotoArtSystem.Services.Common.Models
{
    using System;
    using Data.Common.Models;

    public class StudentModel : BaseModelModel<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public PhotocourseModel Photocourse { get; set; }
    }
}

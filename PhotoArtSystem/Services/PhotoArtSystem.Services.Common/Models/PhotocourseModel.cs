namespace PhotoArtSystem.Services.Common.Models
{
    using System;
    using System.Collections.Generic;
    using Data.Common.Models;

    public class PhotocourseModel : BaseModelModel<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public string Name { get; set; }

        public string DescriptionShort { get; set; }

        public string Description { get; set; }

        public string OtherInfo { get; set; }

        public ushort DurationHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Teacher { get; set; }

        public int MaxStudents { get; set; }

        public IEnumerable<ImageModel> Images { get; set; }

        public IEnumerable<StudentModel> Students { get; set; }
    }
}

namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using Common.Models;
    using Models;
    using Web.Infrastructure.Mapping;

    public class StudentTransitional : BaseModelTransitional<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity,
        IMapFrom<Student>, IMapTo<Student>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Guid PhotocourseId { get; set; }

        public PhotocourseTransitional Photocourse { get; set; }
    }
}

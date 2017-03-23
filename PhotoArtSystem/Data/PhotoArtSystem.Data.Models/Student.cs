namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using Contracts;
    using PhotoArtSystem.Common.Constants;

    public class Student : BaseModelGuid, IStudent, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        [Index]
        [MaxLength(ModelConstants.ApplicationUserNamesMaxLength)]
        [MinLength(ModelConstants.ApplicationUserNamesMinLength)]
        public string FirstName { get; set; }

        [MaxLength(ModelConstants.ApplicationUserNamesMaxLength)]
        [MinLength(ModelConstants.ApplicationUserNamesMinLength)]
        public string MiddleName { get; set; }

        [Index]
        [MaxLength(ModelConstants.ApplicationUserNamesMaxLength)]
        [MinLength(ModelConstants.ApplicationUserNamesMinLength)]
        public string LastName { get; set; }

        public Guid PhotocourseId { get; set; }

        public virtual Photocourse Photocourse { get; set; }
    }
}

namespace PhotoArtSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class Photocourse : BaseModelGuid, IAuditInfo, IDeletableEntity
    {
        [Required]
        [MaxLength(ModelConstants.PhotocourseNameMaxLength)]
        [MinLength(ModelConstants.PhotocourseNameMinLength)]
        public string Name { get; set; }
    }
}

namespace PhotoArtSystem.Data.Models.PhotocourseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using PhotoArtSystem.Common.Constants;

    public class PhotocourseGroup : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public ushort DurationHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Teacher { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [MaxLength(ModelConstants.PhotocourseGroupOtherInfoMaxLength)]
        public string OtherInfo { get; set; }

        public Guid PhotocourseId { get; set; }

        public virtual Photocourse Photocourse { get; set; }

        public Guid ImageLinkId { get; set; }

        public virtual ImageLink ImageLink { get; set; }
    }
}

﻿namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Web.Infrastructure.Mapping;

    public class PhotocourseTransitional : BaseModelTransitional<Guid>,
        IMapFrom<Photocourse>, IMapTo<Photocourse>
    {
        public string Name { get; set; }

        public string DescriptionShort { get; set; }

        public string Description { get; set; }

        public string OtherInfo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DurationHours { get; set; }

        public string Teacher { get; set; }

        public int MaxStudents { get; set; }

        public Guid? ImageCoverId { get; set; }

        public Image ImageCover { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}

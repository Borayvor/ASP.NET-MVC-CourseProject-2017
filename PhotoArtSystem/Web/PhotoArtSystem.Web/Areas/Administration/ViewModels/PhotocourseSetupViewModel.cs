namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Filters;

    public class PhotocourseSetupViewModel
    {
        public PhotocourseCreateViewModel PhotocourseCreate { get; set; }

        [Required]
        [ValidateImageFile]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        [HiddenInput(DisplayValue = false)]
        [MaxLength(ModelConstants.FileInfoFileNameMaxLength + ModelConstants.FileInfoFileExtensionMaxLength)]
        public string ImageCoverFullName { get; set; }
    }
}

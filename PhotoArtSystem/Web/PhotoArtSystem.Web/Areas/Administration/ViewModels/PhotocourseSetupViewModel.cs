namespace PhotoArtSystem.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Infrastructure.Filters;

    public class PhotocourseSetupViewModel
    {
        public PhotocourseCreateViewModel PhotocourseCreate { get; set; }

        [Required]
        [ValidateImageFile]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}

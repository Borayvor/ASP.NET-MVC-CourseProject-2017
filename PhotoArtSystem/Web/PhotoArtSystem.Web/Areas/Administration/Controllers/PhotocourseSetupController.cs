namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Data.Models.TransitionalModels;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using ViewModels;

    public class PhotocourseSetupController : BaseAdminController
    {
        private readonly IImageService imageService;
        private readonly IPhotocourseService photocourseService;

        public PhotocourseSetupController(IImageService imageService, IPhotocourseService photocourseService, IAutoMapperService mapper)
            : base(mapper)
        {
            this.imageService = imageService;
            this.photocourseService = photocourseService;
        }

        [HttpGet]
        public ActionResult NewPhotocourse()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> NewPhotocourse(PhotocourseSetupViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var photocourseTransitional = this.Mapper
                .Map<PhotocourseTransitional>(model.PhotocourseCreate);

            var files = this.Mapper
                .Map<IEnumerable<HttpPostedFileBaseViewModel>>(model.Files);

            var imageTransitional = this.Mapper
                .Map<IEnumerable<ImageTransitional>>(files);

            photocourseTransitional.Images = await this.imageService.Create(imageTransitional);

            this.photocourseService.Create(photocourseTransitional);

            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}
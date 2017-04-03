namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Data.Models.EnumTypes;
    using Data.Models.TransitionalModels;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using ViewModels;
    using Web.Controllers;

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

        public async Task<ActionResult> CreateNewPhotocourse(PhotocourseSetupViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("NewPhotocourse");
            }

            var newFileList = new List<HttpPostedFileBase>(model.Files);

            var photocourseTransitional = this.Mapper
                .Map<PhotocourseTransitional>(model.PhotocourseCreate);

            var files = this.Mapper
                .Map<IEnumerable<HttpPostedFileBaseViewModel>>(model.Files);

            var imagesTransitional = this.Mapper
               .Map<IEnumerable<ImageTransitional>>(files);

            photocourseTransitional.Images = await this.imageService.Create(imagesTransitional, ImageFormatType.Ordinary);

            var coverImageFile = this.Mapper
                .Map<HttpPostedFileBaseViewModel>(model.CoverImage);

            var imageTransitional = this.Mapper
               .Map<ImageTransitional>(coverImageFile);

            photocourseTransitional.ImageCover = await this.imageService.Create(imageTransitional, ImageFormatType.Cover);

            var photocourse = this.photocourseService.Create(photocourseTransitional);

            return this.RedirectToAction<PhotocourseController>(c => c.Details(photocourse.Id), new { area = string.Empty });
        }
    }
}
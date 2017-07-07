namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Common.Constants;
    using Data.Models.EnumTypes;
    using Data.Models.TransitionalModels;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using ViewModels;
    using Web.Controllers;

    public class PhotocourseSetupController : BaseAdminController
    {
        private readonly ICacheService cache;
        private readonly IImageService imageService;
        private readonly IPhotocourseService photocourseService;

        public PhotocourseSetupController(
            ICacheService cache,
            IImageService imageService,
            IPhotocourseService photocourseService,
            IAutoMapperService mapper)
            : base(mapper)
        {
            this.cache = cache;
            this.imageService = imageService;
            this.photocourseService = photocourseService;
        }

        [HttpGet]
        public ActionResult NewPhotocourse()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNewPhotocourse(PhotocourseSetupViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("NewPhotocourse");
            }

            var photocourseTransitional = this.Mapper
               .Map<PhotocourseTransitional>(model.PhotocourseCreate);

            var imageFiles = this.Mapper
                .Map<IEnumerable<HttpPostedFileBaseViewModel>>(model.Files);

            var imagesTransitional = this.Mapper
               .Map<IEnumerable<ImageTransitional>>(imageFiles);

            photocourseTransitional.Images = await this.imageService
                .Create(imagesTransitional, ImageFormatType.Ordinary);

            var coverImageFile = this.Mapper
                .Map<HttpPostedFileBaseViewModel>(model.CoverImage);

            var imageTransitional = this.Mapper
               .Map<ImageTransitional>(coverImageFile);

            photocourseTransitional.ImageCover = await this.imageService
                .Create(imageTransitional, ImageFormatType.Cover);

            var photocourse = this.photocourseService.Create(photocourseTransitional);

            this.cache.Remove(GlobalConstants.CarouselDataCacheName);
            this.cache.Remove(GlobalConstants.PhotocoursesAllCacheName);

            return this.RedirectToAction<PhotocourseController>(
                c => c.Details(photocourse.Id),
                new { area = string.Empty });
        }
    }
}
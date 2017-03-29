namespace PhotoArtSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using ViewModels.InformationModels;

    public class HomeController : BaseController
    {
        private readonly IInformationService mainInfoService;
        private readonly IPhotocourseService photocourseService;
        private readonly ICacheService cache;

        public HomeController(
            IInformationService mainInfoService,
            IPhotocourseService photocourseService,
            ICacheService cache,
            IAutoMapperService mapper)
            : base(mapper)
        {
            this.mainInfoService = mainInfoService;
            this.photocourseService = photocourseService;
            this.cache = cache;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetCarouselData()
        {
            var photocourses = this.photocourseService.GetAll();

            var carouselDataViewModel = this.Mapper
                .Map<IEnumerable<CarouselDataViewModel>>(photocourses);

            var result = this.cache.Get(
                    GlobalConstants.CarouselDataCacheName,
                    () => this.PartialView("_CarouselDataPartial", carouselDataViewModel),
                    GlobalConstants.CarouselDataPartialCacheDuration);

            return result;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetPhotoArtInfos()
        {
            var mainInfoes = this.mainInfoService.GetAll();

            var mainInfoAllViewModel = this.Mapper
                .Map<IEnumerable<InformationViewModel>>(mainInfoes);

            var result = this.cache.Get(
                    GlobalConstants.InformationAllCacheName,
                    () => this.PartialView("_MainInfoAllPartial", mainInfoAllViewModel),
                    GlobalConstants.InformationAllPartialCacheDuration);

            return result;
        }
    }
}
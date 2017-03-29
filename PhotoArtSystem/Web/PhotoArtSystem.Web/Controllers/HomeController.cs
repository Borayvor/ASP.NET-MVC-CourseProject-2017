namespace PhotoArtSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using ViewModels.MainInfoModels;

    public class HomeController : BaseController
    {
        private readonly IMainInfoService mainInfoService;
        private readonly IPhotocourseService photocourseService;
        private readonly ICacheService cache;

        public HomeController(
            IMainInfoService mainInfoService,
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
                .Map<IEnumerable<MainInfoViewModel>>(mainInfoes);

            var result = this.cache.Get(
                    GlobalConstants.MainInfoAllCacheName,
                    () => this.PartialView("_MainInfoAllPartial", mainInfoAllViewModel),
                    GlobalConstants.MainInfoAllPartialCacheDuration);

            return result;
        }
    }
}
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
        private readonly IAutoMapperService mapper;

        public HomeController(IMainInfoService mainInfoService, IPhotocourseService photocourseService, IAutoMapperService mapper, ICacheService cache)
            : base(cache)
        {
            this.mainInfoService = mainInfoService;
            this.photocourseService = photocourseService;
            this.mapper = mapper;
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
            var result = this.ExceptionHandlerActionResult(
                () => this.mapper
                .Map<IEnumerable<CarouselDataViewModel>>(this.photocourseService.GetAll()),
                (carouselDataViewModel) => this.Cache.Get(
                    GlobalConstants.CarouselDataCacheName,
                    () => this.PartialView("_CarouselDataPartial", carouselDataViewModel),
                    GlobalConstants.CarouselDataPartialCacheDuration));

            return result;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetPhotoArtInfos()
        {
            var result = this.ExceptionHandlerActionResult(
                () => this.mapper
                .Map<IEnumerable<MainInfoViewModel>>(this.mainInfoService.GetAll()),
                (mainInfoAllViewModel) => this.Cache.Get(
                    GlobalConstants.MainInfoAllCacheName,
                    () => this.PartialView("_MainInfoAllPartial", mainInfoAllViewModel),
                    GlobalConstants.MainInfoAllPartialCacheDuration));

            return result;
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            ////throw new ArgumentException();

            return this.View();
        }
    }
}
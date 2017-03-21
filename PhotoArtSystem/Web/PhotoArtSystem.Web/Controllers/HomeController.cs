namespace PhotoArtSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.PhotoArtServices.Contracts;
    using Services.Web.Contracts;
    using ViewModels.PhotoArtServiceModels;

    public class HomeController : BaseController
    {
        private readonly IPhotoArtServiceService photoArtServiceService;

        public HomeController(IPhotoArtServiceService photoArtServiceService, IAutoMapperService mapper, ICacheService cache)
            : base(mapper, cache)
        {
            this.photoArtServiceService = photoArtServiceService;

            this.ViewBag.Slide1 = "/Images/cover14.jpg";
            this.ViewBag.Slide2 = "/Images/Photo_Kurs_Plovdiv.png";
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetPhotoArtServices()
        {
            var photoArtServices = this.photoArtServiceService.GetAll();

            return this.ExceptionHandlerActionResult(
                () => this.Mapper
                .Map<IEnumerable<PhotoArtServiceHomeViewModel>>(photoArtServices),
                (photoArtServiceModel) => this.Cache.Get(
                    GlobalConstants.PhotoArtServicesCacheName,
                    () => this.PartialView("_PhotoArtServicesPartial", photoArtServiceModel),
                    GlobalConstants.PhotoArtServicesPartialCacheDuration));
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
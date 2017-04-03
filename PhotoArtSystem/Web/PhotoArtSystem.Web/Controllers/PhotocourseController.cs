namespace PhotoArtSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using ViewModels.PhotocourseModels;

    public class PhotocourseController : BaseController
    {
        private readonly IPhotocourseService photocourseService;
        private readonly ICacheService cache;

        public PhotocourseController(
            IPhotocourseService photocourseService,
            ICacheService cache,
            IAutoMapperService mapper)
            : base(mapper)
        {
            this.cache = cache;
            this.photocourseService = photocourseService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return this.View(id);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetAllPhotocourses()
        {
            var photocourses = this.photocourseService.GetAll();

            var photocoursesAllViewModel = this.Mapper
                .Map<IEnumerable<PhotocourseViewModel>>(photocourses);

            var result = this.cache.Get(
                    GlobalConstants.PhotocoursesAllCacheName,
                    () => this.PartialView("_PhotocoursesAllPartial", photocoursesAllViewModel),
                    GlobalConstants.PhotocoursesAllPartialCacheDuration);

            return result;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetPhotocourse(Guid id)
        {
            var photocourse = this.photocourseService.GetById(id);

            var photocourseViewModel = this.Mapper
                .Map<PhotocourseDetailsViewModel>(photocourse);

            var result = this.cache.Get(
                    GlobalConstants.PhotocourseCacheName + id,
                    () => this.PartialView("_PhotocoursePartial", photocourseViewModel),
                    GlobalConstants.PhotocoursePartialCacheDuration);

            return result;
        }
    }
}
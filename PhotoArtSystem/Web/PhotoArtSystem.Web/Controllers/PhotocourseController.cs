namespace PhotoArtSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Photocourses.Contracts;
    using Services.Web.Contracts;
    using ViewModels.PhotocourseModels;

    public class PhotocourseController : BaseController
    {
        private readonly IPhotocourseService photocourseService;

        public PhotocourseController(
            IPhotocourseService photocourseService,
            IAutoMapperService mapper,
            ICacheService cache)
            : base(mapper, cache)
        {
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
        public ActionResult GetPhotocourse(Guid id)
        {
            var photocourse = this.photocourseService.GetById(id);

            var result = this.ExceptionHandlerActionResult(
                () => this.Mapper.Map<PhotocourseDetailsViewModel>(photocourse),
                (photocourseViewModel) => this.Cache.Get(
                    GlobalConstants.PhotocourseCacheName + id,
                    () => this.PartialView("_PhotocoursePartial", photocourseViewModel),
                    GlobalConstants.PhotocoursePartialCacheDuration));

            return result;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetAllPhotocourses()
        {
            var photocourses = this.photocourseService.GetAll();

            var result = this.ExceptionHandlerActionResult(
                () => this.Mapper.Map<IEnumerable<PhotocourseViewModel>>(photocourses),
                (photocoursesAllViewModel) => this.Cache.Get(
                    GlobalConstants.PhotocoursesAllCacheName,
                    () => this.PartialView("_PhotocoursesAllPartial", photocoursesAllViewModel),
                    GlobalConstants.PhotocoursesAllPartialCacheDuration));

            return result;
        }
    }
}
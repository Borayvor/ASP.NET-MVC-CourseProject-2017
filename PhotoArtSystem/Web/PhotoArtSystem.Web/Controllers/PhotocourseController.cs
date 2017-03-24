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
        private readonly IAutoMapperService mapper;
        private readonly IPhotocourseService photocourseService;

        public PhotocourseController(
            IPhotocourseService photocourseService,
            IAutoMapperService mapper,
            ICacheService cache)
            : base(cache)
        {
            this.mapper = mapper;
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
            var result = this.ExceptionHandlerActionResult(
                () => this.mapper
                .Map<PhotocourseDetailsViewModel>(this.photocourseService.GetById(id)),
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
            var result = this.ExceptionHandlerActionResult(
                () => this.mapper
                .Map<IEnumerable<PhotocourseViewModel>>(this.photocourseService.GetAll()),
                (photocoursesAllViewModel) => this.Cache.Get(
                    GlobalConstants.PhotocoursesAllCacheName,
                    () => this.PartialView("_PhotocoursesAllPartial", photocoursesAllViewModel),
                    GlobalConstants.PhotocoursesAllPartialCacheDuration));

            return result;
        }
    }
}
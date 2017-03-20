namespace PhotoArtSystem.Web.Controllers
{
    using System;
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
        public ActionResult Index(Guid id)
        {
            return this.View(id);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetPhotocourse(Guid id)
        {
            var photocourse = this.photocourseService.GetById(id);

            return this.ExceptionHandlerActionResult(
                () => this.Mapper.Map<PhotocourseViewModel>(photocourse),
                (photocourseViewModel) => this.Cache.Get(
                    GlobalConstants.PhotocourseCacheName + id,
                    () => this.PartialView("_PhotocoursePartial", photocourseViewModel),
                    GlobalConstants.PhotocoursePartialCacheDuration));
        }
    }
}
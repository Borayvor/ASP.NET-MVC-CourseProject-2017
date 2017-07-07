namespace PhotoArtSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Services.Data.Contracts;
    using PhotoArtSystem.Services.Web.Contracts;
    using PhotoArtSystem.Web.ViewModels.MultimediaModels;

    public class MultimediaController : BaseController
    {
        private readonly IMultimediaGetService multimediaGetService;
        private readonly ICacheService cache;

        public MultimediaController(
            IMultimediaGetService multimediaGetService,
            ICacheService cache,
            IAutoMapperService mapper)
            : base(mapper)
        {
            this.multimediaGetService = multimediaGetService;
            this.cache = cache;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetAllMultimedia()
        {
            var multimedia = this.multimediaGetService.GetAll();

            var multimediaAllViewModel = this.Mapper
                .Map<IEnumerable<MultimediaViewModel>>(multimedia);

            var result = this.cache.Get(
                    GlobalConstants.MultimediaAllCacheName,
                    () => this.PartialView("_MultimediaAllPartial", multimediaAllViewModel),
                    GlobalConstants.MultimediaAllPartialCacheDuration);

            return result;
        }
    }
}
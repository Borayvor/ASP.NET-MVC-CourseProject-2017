namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Services.Data.Contracts;
    using PhotoArtSystem.Services.Web.Contracts;
    using PhotoArtSystem.Web.Areas.Administration.ViewModels;

    public class MultimediaSetupController : BaseAdminController
    {
        private readonly IMultimediaService multimediaService;
        private readonly ICacheService cache;

        public MultimediaSetupController(
            IMultimediaService multimediaService,
            ICacheService cache,
            IAutoMapperService mapper)
            : base(mapper)
        {
            this.multimediaService = multimediaService;
            this.cache = cache;
        }

        [HttpGet]
        public ActionResult NewMultimedia()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewMultimedia(MultimediaCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("NewMultimedia");
            }

            var multimediaTransitional = this.Mapper
               .Map<MultimediaTransitional>(model);

            this.multimediaService.Create(multimediaTransitional);

            this.cache.Remove(GlobalConstants.MultimediaAllCacheName);

            // TODO: add model for partial view
            return this.PartialView("_MultimediaPartial");
        }
    }
}
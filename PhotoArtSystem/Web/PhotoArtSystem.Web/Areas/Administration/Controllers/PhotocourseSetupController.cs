namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Models.TransitionalModels;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using ViewModels;

    public class PhotocourseSetupController : BaseAdminController
    {
        private readonly IPhotocourseService photocourseService;

        public PhotocourseSetupController(IPhotocourseService photocourseService, IAutoMapperService mapper)
            : base(mapper)
        {
            this.photocourseService = photocourseService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View("Index");
        }

        [HttpPost]
        public ActionResult Create(PhotocourseCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Index");
            }

            var photocourseViewModel = this.Mapper
                .Map<PhotocourseExtendedTransitional>(model);

            this.photocourseService.Create(photocourseViewModel);

            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}
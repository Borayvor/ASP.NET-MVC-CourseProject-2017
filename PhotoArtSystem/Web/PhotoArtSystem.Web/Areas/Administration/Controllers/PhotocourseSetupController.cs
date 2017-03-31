namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Services.Web.Contracts;
    using ViewModels;

    public class PhotocourseSetupController : BaseAdminController
    {
        public PhotocourseSetupController(IAutoMapperService mapper)
            : base(mapper)
        {
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

            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}
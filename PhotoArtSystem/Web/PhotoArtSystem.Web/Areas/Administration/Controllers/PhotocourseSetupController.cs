namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Services.Web.Contracts;

    public class PhotocourseSetupController : BaseAdminController
    {
        public PhotocourseSetupController(ICacheService cache)
            : base(cache)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
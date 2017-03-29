namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Services.Web.Contracts;

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
    }
}
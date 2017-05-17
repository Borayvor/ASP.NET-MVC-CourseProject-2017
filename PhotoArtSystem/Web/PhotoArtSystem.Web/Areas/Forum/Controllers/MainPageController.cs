namespace PhotoArtSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Services.Web.Contracts;
    using Web.Controllers;

    public class MainPageController : BaseController
    {
        public MainPageController(IAutoMapperService mapper)
            : base(mapper)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
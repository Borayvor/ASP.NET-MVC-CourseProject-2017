namespace PhotoArtSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Web.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IAutoMapperService mapper, ICacheService cache)
            : base(mapper, cache)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
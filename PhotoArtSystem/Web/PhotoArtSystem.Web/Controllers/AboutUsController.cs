namespace PhotoArtSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class AboutUsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
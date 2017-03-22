namespace PhotoArtSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class EController : Controller
    {
        public ActionResult E500(string aspxerrorpath)
        {
            this.Response.StatusCode = 500;

            return this.View();
        }

        public ActionResult E400(string aspxerrorpath)
        {
            this.Response.StatusCode = 400;
            this.ViewBag.Path = aspxerrorpath;

            return this.View();
        }

        public ActionResult E404(string aspxerrorpath)
        {
            this.Response.StatusCode = 404;
            this.ViewBag.Path = aspxerrorpath;

            return this.View();
        }
    }
}
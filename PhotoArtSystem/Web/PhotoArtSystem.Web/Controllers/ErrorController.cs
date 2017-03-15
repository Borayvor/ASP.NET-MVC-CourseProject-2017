namespace PhotoArtSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult E500()
        {
            this.Response.StatusCode = 500;

            return this.View();
        }

        public ActionResult E400()
        {
            this.Response.StatusCode = 400;

            return this.View();
        }

        public ActionResult E404()
        {
            this.Response.StatusCode = 404;

            return this.View();
        }
    }
}
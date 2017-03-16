namespace PhotoArtSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Web.Contracts;

    public class EController : BaseController
    {
        public EController(IAutoMapperService mapper, ICacheService cache)
            : base(mapper, cache)
        {
        }

        public ActionResult E500()
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
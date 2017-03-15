namespace PhotoArtSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Photocourse.Contracts;
    using Services.Web.Contracts;
    using ViewModels.PhotocourseModels;

    public class HomeController : BaseController
    {
        private readonly IPhotocourseService photocourseService;

        public HomeController(IPhotocourseService photocourseService, IAutoMapperService mapper, ICacheService cache)
            : base(mapper, cache)
        {
            this.photocourseService = photocourseService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache(Duration = 600, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult GetPhotocourses()
        {
            var viewModel = this.Mapper
                .Map<
                    IEnumerable<Photocourse>,
                    IEnumerable<PhotocourseHomeViewModel>
                    >(this.photocourseService.GetAll());

            var result = this.Cache.Get(
                "Photocourses",
                () => this.PartialView("_PhotocourseTestPartial", viewModel),
                60);

            return result;
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
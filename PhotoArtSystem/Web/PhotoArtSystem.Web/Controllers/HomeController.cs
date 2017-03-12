namespace PhotoArtSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Photocourse.Contracts;
    using ViewModels.PhotocourseModels;

    public class HomeController : BaseController
    {
        private readonly IPhotocourseService photocourseService;

        public HomeController(IPhotocourseService photocourseService)
        {
            this.photocourseService = photocourseService;
        }

        public ActionResult Index()
        {
            var viewModel = this.photocourseService.GetAll().To<PhotocourseHomeViewModel>().ToList();

            return this.View(viewModel);
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
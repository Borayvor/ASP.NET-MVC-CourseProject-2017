namespace PhotoArtSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Models;
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
            var viewModel = this.Mapper
                .Map<IEnumerable<Photocourse>, IEnumerable<PhotocourseHomeViewModel>>(this.photocourseService.GetAll());

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
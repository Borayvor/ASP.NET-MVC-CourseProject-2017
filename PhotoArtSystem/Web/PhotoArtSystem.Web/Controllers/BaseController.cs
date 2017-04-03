namespace PhotoArtSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Web.Contracts;

    public abstract class BaseController : Controller
    {
        protected BaseController(IAutoMapperService mapper)
        {
            this.Mapper = mapper;
        }

        public IAutoMapperService Mapper { get; }
    }
}
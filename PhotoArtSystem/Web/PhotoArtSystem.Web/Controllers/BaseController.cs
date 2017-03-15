namespace PhotoArtSystem.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Services.Web.Contracts;

    public abstract class BaseController : Controller
    {
        protected BaseController(IAutoMapperService mapper, ICacheService cache)
        {
            this.Mapper = mapper.GetAutoMapper;
            this.Cache = cache;
        }

        public ICacheService Cache { get; }

        protected IMapper Mapper { get; }
    }
}
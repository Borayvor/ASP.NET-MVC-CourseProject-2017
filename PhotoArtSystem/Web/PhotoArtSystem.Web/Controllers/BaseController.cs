namespace PhotoArtSystem.Web.Controllers
{
    using System;
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

        protected ActionResult ExceptionHandlerActionResult<T>(Func<T> funcToPerform, Func<T, ActionResult> resultToReturn)
        {
            try
            {
                var result = funcToPerform();
                return resultToReturn(result);
            }
            catch (Exception e)
            {
                return this.HttpNotFound(e.Message);
            }
        }

        protected ActionResult ExceptionHandlerActionResult(Action actionToPerform, Func<ActionResult> resultToReturn)
        {
            try
            {
                actionToPerform();
                return resultToReturn();
            }
            catch (Exception e)
            {
                return this.HttpNotFound(e.Message);
            }
        }

        protected ActionResult ExceptionHandlerActionResult(Action actionToPerform, ActionResult resultToReturn)
        {
            try
            {
                actionToPerform();
                return resultToReturn;
            }
            catch (Exception e)
            {
                return this.HttpNotFound(e.Message);
            }
        }
    }
}
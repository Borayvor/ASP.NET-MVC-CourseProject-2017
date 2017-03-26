namespace PhotoArtSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Web.Contracts;
    using Web.Controllers;

    [Authorize(Roles = AuthConstants.AdministratorRoleName)]
    public abstract class BaseAdminController : BaseController
    {
        public BaseAdminController(ICacheService cache)
            : base(cache)
        {
        }
    }
}
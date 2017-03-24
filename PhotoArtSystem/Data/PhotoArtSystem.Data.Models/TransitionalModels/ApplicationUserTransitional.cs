namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using Common.Models;
    using Models;
    using Web.Infrastructure.Mapping;

    public class ApplicationUserTransitional : BaseModelTransitional<string>, IBaseModel<string>, IAuditInfo, IDeletableEntity,
        IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        public bool IsTeacher { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

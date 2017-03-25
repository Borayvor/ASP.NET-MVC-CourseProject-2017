namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using Models;
    using Web.Infrastructure.Mapping;

    public class ApplicationUserTransitional : BaseModelTransitional<string>,
        IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        public bool IsTeacher { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

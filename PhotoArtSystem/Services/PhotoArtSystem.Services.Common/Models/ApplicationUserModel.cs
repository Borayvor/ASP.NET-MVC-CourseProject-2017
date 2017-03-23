namespace PhotoArtSystem.Services.Common.Models
{
    using Data.Common.Models;

    public class ApplicationUserModel : BaseModelModel<string>, IBaseModel<string>, IAuditInfo, IDeletableEntity
    {
        public bool IsTeacher { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

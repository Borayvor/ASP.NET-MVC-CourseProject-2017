namespace PhotoArtSystem.Data.Models.Contracts
{
    using Common.Models;

    public interface IApplicationUser : IBaseModel<string>, IAuditInfo, IDeletableEntity
    {
        bool IsTeacher { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}

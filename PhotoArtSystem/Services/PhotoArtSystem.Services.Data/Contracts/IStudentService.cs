namespace PhotoArtSystem.Services.Data.Contracts
{
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IStudentService :
        IStudentGetService,
        IBaseCreateService<StudentTransitional>,
        IBaseUpdateService<StudentTransitional>,
        IBaseDeleteService<StudentTransitional>
    {
    }
}

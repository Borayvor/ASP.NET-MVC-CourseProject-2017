namespace PhotoArtSystem.Services.Data.Contracts
{
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;

    public interface IPhotocourseService :
        IPhotocourseGetService,
        IBaseUpdateService<PhotocourseTransitional>,
        IBaseDeleteService<PhotocourseTransitional>
    {
        Photocourse Create(PhotocourseTransitional entity);
    }
}

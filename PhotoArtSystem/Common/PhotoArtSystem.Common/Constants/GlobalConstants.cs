namespace PhotoArtSystem.Common.Constants
{
    public class GlobalConstants
    {
        public const string StringEmpty = "";

        public const int PhotoArtServicesPartialCacheDuration = 60 * 60 * 24; // sec * min * hours

        public const string DbContextRequiredExceptionMessage = "An instance of DbContext is required !";
        public const string EfDbContextRequiredExceptionMessage = "An instance of EfDbContext is required !";

        // PhotocourseService
        public const string EfDbRepositoryPhotocourseRequiredExceptionMessage = "An instance of EfDbRepository of Photocourse is required !";
        public const string PhotocourseRequiredExceptionMessage = "An instance of Photocourse is required !";

        // PhotoArtServiceService
        public const string EfDbRepositoryPhotoArtServiceRequiredExceptionMessage = "An instance of EfDbRepository of PhotoArtService is required !";
        public const string PhotoArtServiceRequiredExceptionMessage = "An instance of PhotoArtService is required !";
    }
}

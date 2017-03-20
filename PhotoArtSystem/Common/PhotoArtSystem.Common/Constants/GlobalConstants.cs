namespace PhotoArtSystem.Common.Constants
{
    public class GlobalConstants
    {
        public const string StringEmpty = "";

        // Cache duration
        public const int PhotoArtServicesPartialCacheDuration = 60 * 60 * 24; // sec * min * hours
        public const int PhotocoursePartialCacheDuration = 60 * 60 * 24; // sec * min * hours

        // Cache item names
        public const string PhotoArtServicesCacheName = "PhotoArtServices";
        public const string PhotocourseCacheName = "Photocourse_";

        // Exception messages
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

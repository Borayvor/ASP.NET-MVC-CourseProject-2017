namespace PhotoArtSystem.Common.Constants
{
    public class GlobalConstants
    {
        public const string StringEmpty = "";

        // Cache duration
        public const int PhotoArtServicesPartialCacheDuration = 0; //// * 60 * 24; // sec * min * hours
        public const int PhotocoursePartialCacheDuration = 0; //// * 60 * 24; // sec * min * hours
        public const int PhotocoursesAllPartialCacheDuration = 0; //// * 60 * 24; // sec * min * hours

        // Cache item names
        public const string PhotoArtServicesCacheName = "PhotoArtServices";
        public const string PhotocoursesAllCacheName = "PhotocoursesAll";
        public const string PhotocourseCacheName = "Photocourse_";

        // Exception messages
        public const string DbContextRequiredExceptionMessage = "An instance of DbContext is required !";
        public const string EfDbContextRequiredExceptionMessage = "An instance of EfDbContext is required !";

        // PhotocourseService
        public const string EfDbRepositoryPhotocourseRequiredExceptionMessage = "An instance of EfDbRepository of Photocourse is required !";
        public const string PhotocourseRequiredExceptionMessage = "An instance of Photocourse is required !";
        public const string MapperRequiredExceptionMessage = "An instance of Mapper is required !";

        // StudentService
        public const string EfDbRepositoryStudentRequiredExceptionMessage = "An instance of EfDbRepository of Student is required !";
        public const string StudentServiceRequiredExceptionMessage = "An instance of StudentService is required !";
    }
}
